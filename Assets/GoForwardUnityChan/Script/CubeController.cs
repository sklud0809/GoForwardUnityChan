using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    private float speed = -12; // キューブの移動速度
    private float deadLine = -10;  // 消滅位置
    private AudioSource block_PileUpSE;


    void Start ()
    {
        block_PileUpSE = GetComponent<AudioSource>();
	}
	
	
	void Update ()
    {
        // キューブを移動
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cube" || collision.gameObject.tag == "Ground") 
        {
            // Debug.Log("Cube,Ground判定");
            block_PileUpSE.Play();
        }
       
    }
}
