﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
   
    Animator animator; //アニメーションするためのコンポーネントを入れる
    Rigidbody2D rigid2D;

    private float groundLevel = -3.0f;   // 地面の位置
    private float dump = 0.8f; // ジャンプの速度の減衰
    float jumpVelocity = 20;// ジャンプの速度


    private float deadLine = -9;// ゲームオーバになる位置

    void Start ()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }
	
	
	void Update ()
    {
        // 走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // 着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // 上方向の力をかける）
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // クリックをやめたら上方向への速度を減速する
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        if (transform.position.x < this.deadLine)
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // ユニティちゃんを破棄する
            Destroy(gameObject);
        }
    }
}
