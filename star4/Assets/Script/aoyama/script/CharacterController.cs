﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    Rigidbody2D rigidPlayer;
    public float speed = 3.0f;
    public float jumpForce = 250.0f; 
    public bool isJump;
    public bool isGround;
    public bool isSimultaneous;
    public bool isAppeal;
    public bool isOn;


    public bool islight;


    Animator anim;
    float count;



    public bool isBound;

    string inputHorizontal;
    string inputJump;


    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isJump = false;
        isGround = false;
        isSimultaneous = false;
        isAppeal = false;
        isOn = false;

        isBound = false;


        if (gameObject.tag == "Player1")
        {
            inputHorizontal = "GamePad1_Horizontal";
            inputJump = "GamePad1_Jump";
        }
        else if (gameObject.tag == "Player2")
        {
            inputHorizontal = "GamePad2_Horizontal";
            inputJump = "GamePad2_Jump";
        }
        else if (gameObject.tag == "Player3")
        {
            inputHorizontal = "GamePad3_Horizontal";
            inputJump = "GamePad3_Jump";
        }
        else
        {
            inputHorizontal = "GamePad4_Horizontal";
            inputJump = "GamePad4_Jump";
        }
        islight = false;
    }

    void Update()
    {
        Jump();

        float h = Input.GetAxis(inputHorizontal);
        float hh = Input.GetAxis("PlayerHorizontal");

        if (h !=0)
        {
        rigidPlayer.velocity = new Vector2(speed * h, rigidPlayer.velocity.y);

        }
        if (hh != 0)
        {
            
        rigidPlayer.velocity = new Vector2(speed * hh, rigidPlayer.velocity.y);

        }
        anim.SetFloat("run", Mathf.Abs(h));//runパラメーター
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            isSimultaneous = true;
        }
        else
        {
            isSimultaneous = false;
        }


        if(Input.GetAxis(inputHorizontal) > 0f && transform.localScale.x < 0|| Input.GetAxis(inputHorizontal) < 0f && transform.localScale.x > 0)     
        {
            Vector2 pos = transform.localScale;
            pos.x *= -1;
            transform.localScale = pos;
        }


        if (Input.GetKey(KeyCode.B)&&isJump==true)
        {
            isAppeal = true;
        }
        else
        {
            isAppeal = false;
        }
        
        if(isAppeal==true)
        {
            if (isOn == false)
            {

            anim.SetTrigger("Appeal");

                
            }
            isOn = true;
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            anim.SetTrigger("Appealend");
            isOn = false;
        }

        if(isOn==true&&islight==true)
        {
            ScoreText.score++;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {          
            isJump = true;            
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        anim.SetTrigger("stand");
        if(col.gameObject.tag=="head")
            {
            isBound=true;
        }
    }


    void Jump()
    {
        if (Input.GetButton(inputJump) && (isJump == true)||isBound==true)
        {
            anim.SetTrigger("jump");
            rigidPlayer.velocity = Vector2.zero;
            rigidPlayer.AddForce(Vector2.up * jumpForce);
            isJump = false;
            isBound = false;
        }
    }
}
