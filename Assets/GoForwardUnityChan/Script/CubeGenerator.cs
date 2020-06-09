using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {
    public GameObject cubePrefab;
    private float delta = 0;
    private float span = 1.0f; // キューブの生成間隔
    private float genPosX = 12;// キューブの生成位置：X座標
    private float offsetX = 0.5f; // キューブの生成位置オフセット
    private float spaceX =  0.4f; // キューブの横方向の間隔


    private float offsetY = 0.3f;// キューブの生成位置オフセット
    private float spaceY = 6.9f; // キューブの縦方向の間隔

    private int maxBlockNum = 4; // 生成個数の上限    


    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        this.delta += Time.deltaTime;

        // span秒以上の時間が経過したかを調べる
        if (this.delta > this.span)
        {
            this.delta = 0;
            // 生成するキューブ数をランダムに決める
            int n = Random.Range(1, maxBlockNum + 1);

            // 指定した数だけキューブを生成する
            for (int i = 0; i < n; i++)
            {
                // キューブの生成
                GameObject go = Instantiate(cubePrefab) as GameObject;
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            // 次のキューブまでの生成時間を決める
            this.span = this.offsetX + this.spaceX * n;
        }
    }
}
