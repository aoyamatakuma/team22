using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    Rigidbody2D rigidPlayer;
    public float speed = 3.0f;
    public float jumpForce = 250.0f;
    private float airSpeed = 1.5f;





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
    string inputAppeal;
    string inputAttack;

    public bool isLeft;
    public bool isRight;

    public bool isAttack;//攻撃状態


    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isJump = false;
        isGround = false;
        isSimultaneous = false;
        isAppeal = false;
        isOn = false;
        isLeft = false;
        isRight = false;






        isBound = false;
        isAttack = false;

        if (gameObject.tag == "Player1")
        {
            inputHorizontal = "GamePad1_Horizontal";
            inputJump = "GamePad1_Jump";
            inputAppeal = "GamePad1_X";
            inputAttack = "GamePad1_B";
        }
        else if (gameObject.tag == "Player2")
        {
            inputHorizontal = "GamePad2_Horizontal";
            inputJump = "GamePad2_Jump";
            inputAppeal = "GamePad2_X";
            inputAttack = "GamePad2_B";
        }
        else if (gameObject.tag == "Player3")
        {
            inputHorizontal = "GamePad3_Horizontal";
            inputJump = "GamePad3_Jump";
            inputAppeal = "GamePad3_X";
            inputAttack = "GamePad3_B";
        }
        else
        {
            inputHorizontal = "GamePad4_Horizontal";
            inputJump = "GamePad4_Jump";
            inputAppeal = "GamePad4_X";
            inputAttack = "GamePad4_B";
        }
        islight = false;
    }

    void Update()
    {
        Jump();

        float h = Input.GetAxis(inputHorizontal);
        float hh = Input.GetAxis("PlayerHorizontal");


        if (isAppeal != true)
        {
            if (h != 0)
            {
                if (isJump == true)//地上時のスピード
                    if (isLeft == true)//左に当たている時
                    {
                        if (h < 0)
                        {
                            rigidPlayer.velocity = new Vector2(speed * h, rigidPlayer.velocity.y);
                        }
                        else if (h > 0)
                        {
                            rigidPlayer.velocity = new Vector2(0, rigidPlayer.velocity.y);
                        }
                    }
                if (isRight == true)//左に当たている時
                {
                    if (h > 0)
                    {
                        rigidPlayer.velocity = new Vector2(speed * h, rigidPlayer.velocity.y);
                    }
                    else if (h < 0)
                    {
                        rigidPlayer.velocity = new Vector2(0, rigidPlayer.velocity.y);
                    }
                }

                if (isLeft == false && isRight == false)
                {

                    rigidPlayer.velocity = new Vector2(speed * h, rigidPlayer.velocity.y);
                }
            }

            if (isJump == false)
            {
                if (isLeft == true)//左に当たている時
                {
                    if (h < 0)
                    {
                        rigidPlayer.velocity = new Vector2(airSpeed * h, rigidPlayer.velocity.y);
                    }
                    else if (h > 0)
                    {
                        rigidPlayer.velocity = new Vector2(0, rigidPlayer.velocity.y);
                    }
                }
                if (isRight == true)//左に当たている時
                {
                    if (h > 0)
                    {
                        rigidPlayer.velocity = new Vector2(airSpeed * h, rigidPlayer.velocity.y);
                    }
                    else if (h < 0)
                    {
                        rigidPlayer.velocity = new Vector2(0, rigidPlayer.velocity.y);
                    }
                }

                if (isLeft == false && isRight == false)
                {

                    rigidPlayer.velocity = new Vector2(airSpeed * h, rigidPlayer.velocity.y);
                }

            }
            if (isJump == false)
            {
                if (isLeft == true)//左に当たている時
                {
                    if (h < 0)
                    {
                        rigidPlayer.velocity = new Vector2(airSpeed * h, rigidPlayer.velocity.y);
                    }
                    else if (h > 0)
                    {
                        rigidPlayer.velocity = new Vector2(0, rigidPlayer.velocity.y);
                    }
                }
                if (isRight == true)//左に当たている時
                {
                    if (h > 0)
                    {
                        rigidPlayer.velocity = new Vector2(airSpeed * h, rigidPlayer.velocity.y);
                    }
                    else if (h < 0)
                    {
                        rigidPlayer.velocity = new Vector2(0, rigidPlayer.velocity.y);
                    }
                }

                if (isLeft == false && isRight == false)
                {

                    rigidPlayer.velocity = new Vector2(airSpeed * h, rigidPlayer.velocity.y);
                }

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


            if (Input.GetAxis(inputHorizontal) > 0f && transform.localScale.x < 0 || Input.GetAxis(inputHorizontal) < 0f && transform.localScale.x > 0)
            {
                Vector2 pos = transform.localScale;
                pos.x *= -1;
                transform.localScale = pos;
            }
        }


        if (Input.GetButton(inputAppeal) && isJump == true)
        {
            isJump = false;
            isAppeal = true;

        }
        if (Input.GetButtonUp(inputAppeal) && isAppeal == true)
        {
            isJump = true;
            isAppeal = false;
        }

        if (isAppeal == true)
        {

            anim.SetTrigger("Appeal");
            isOn = true;
        }
        if (isAppeal == false)
        {
            isOn = false;
            anim.SetTrigger("Appealend");
        }
        StartCoroutine("Attack");//コルーチンスタート
    }
    

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {          
            isJump = true;            
        }

        if (col.gameObject.tag == "LeftBody")
        {
            isLeft = true;
        }
        if (col.gameObject.tag == "RightBody")
        {
            isRight = true;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "LeftBody")
        {
            isLeft = false;
            Debug.Log("jfdshfihsai");
        }
        if (col.gameObject.tag == "RightBody")
        {
            isRight = false;
            Debug.Log("jfdshfihsai");
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

    public IEnumerator Attack()
    {
        if (Input.GetButtonDown(inputAttack) && isAttack == false && isJump == true)
        {
            isAttack = true;
            if (transform.localScale.x > 0)
            {
                rigidPlayer.velocity = new Vector2(7, rigidPlayer.velocity.y);
            }
            if (transform.localScale.x < 0)
            {
                rigidPlayer.velocity = new Vector2(-7, rigidPlayer.velocity.y);
            }
            yield return new WaitForSeconds(0.3f);
            isAttack = false;
        }
    }
}
