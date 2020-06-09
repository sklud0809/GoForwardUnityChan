using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    private float scrollSpeed = -0.03f;
    private float deadLine = -16;
    private float startLine = 15.8f;

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        // 背景を移動する
        transform.Translate(this.scrollSpeed, 0, 0);

        // 画面外に出たら、画面右端に移動する
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}
