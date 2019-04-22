using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    Rigidbody2D rigidPlayer;
    public float speed = 3.0f;
    public float jumpForce = 250.0f;
    public bool isDead;
    public bool isJump;
    public bool isGround;
    public bool isSimultaneous;
    Animator anim;
    float test = 0;
    float count;
    //public GameObject GameOverSE;
    //public GameObject JumpSE;
    // Use this for initialization

    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isDead = false;
        isJump = false;
        isGround = false;
        isSimultaneous = false;
    }

    void Update()
    {
        //count += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)&&(isJump==true))
        {
            Jump();
        }


        float h = Input.GetAxis("Horizontal");

        rigidPlayer.velocity = new Vector2(speed * h, rigidPlayer.velocity.y);
        anim.SetFloat("run", Mathf.Abs(h));//runパラメーター
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            isSimultaneous = true;
        }
        else
        {
            isSimultaneous = false;
        }


        if (Input.GetKey(KeyCode.LeftArrow) && transform.localScale.x > 0&& isSimultaneous == false|| Input.GetKey(KeyCode.RightArrow) && transform.localScale.x < 0&&isSimultaneous == false)
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
            if (isDead) { return; }
            isJump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        anim.SetTrigger("stand");
    }


    void Jump()
    {
        anim.SetTrigger("jump");
        rigidPlayer.velocity = Vector2.zero;
        rigidPlayer.AddForce(Vector2.up * jumpForce);
        isJump = false;
    }
}
