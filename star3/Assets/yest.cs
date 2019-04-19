using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yest : MonoBehaviour {
    Rigidbody2D rigidPlayer;
    //public GameObject GameOverSE;
    //public GameObject JumpSE;
    public float speed = 3.0f;
    public float jumpForce = 250.0f;
    public LayerMask groundLayer;
    public bool isDead;
    public bool isJump;
    // Use this for initialization

    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //mainManager = GetComponent<MainManager>();

        isDead = false;
        isJump = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            Debug.Log("ジャンプ可能");
            isJump = false;
            rigidPlayer.velocity = Vector2.zero;
            rigidPlayer.AddForce(Vector2.up * jumpForce);
        }
        float h = Input.GetAxis("Horizontal");

        rigidPlayer.velocity = new Vector2(speed * h, rigidPlayer.velocity.y);
        //anim.SetFloat("run", Mathf.Abs(h));//runパラメーター
        if (Input.GetKey(KeyCode.LeftArrow) && transform.localScale.x > 0 || Input.GetKey(KeyCode.RightArrow) && transform.localScale.x < 0)
        {
            Vector2 pos = transform.localScale;
            pos.x *= -1;
            transform.localScale = pos;
        }

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("ジャンプ可能");
            if (isDead) { return; }
            isJump = true;
            //if (Input.GetKeyDown(KeyCode.Space) && isJump)
            //{
            //    isJump = false;
            //    rigidPlayer.velocity = Vector2.zero;
            //    rigidPlayer.AddForce(Vector2.up * jumpForce);
            //    //JumpSE.GetComponent<AudioSource>().Play();
            //    //anim.SetTrigger("jump");
            //}
        }
    }
}
