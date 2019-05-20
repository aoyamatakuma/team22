using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody2D rigidPlayer;//物理演算
    Animator anim;//アニメーター

    private float speed = 3.0f;//地上での移動速度
    private float airSpeed = 1.5f;//空中での移動速度
    private float jumpForce = 250.0f;//ジャンプの力
    public float stamina = 100;//体力
    private bool isJump;//ジャンプ判定
    private bool isGround;//地面衝突判定
    public bool isAppeal;//アピール判定
    public bool isAttack;//攻撃状態判定
    public bool isOn;
    public bool islight;
    public bool isBound;

    string inputHorizontal;//コントローラースティック
    string inputJump;//コントローラーA
    string inputAppeal;//コントローラーX
    string inputAttack;//コントローラーB

    public bool isLeft;//左半身あたり判定
    public bool isRight;//右半身あたり判定

    public bool isLeftDir;//左向き
    public bool isRightDir;//右向き


    void Start()
    {
        float playerStamina = 100;
        rigidPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isJump = false;
        isGround = false;
        isAppeal = false;
        isOn = false;
        isLeft = false;
        isRight = false;

        isLeftDir = false;
        isRightDir = false; ;//右向き




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
            if (isAttack == false)
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
            }

            if (hh != 0)
            {

                rigidPlayer.velocity = new Vector2(speed * hh, rigidPlayer.velocity.y);

            }
            anim.SetFloat("run", Mathf.Abs(h));//runパラメーター         


            if (Input.GetAxis(inputHorizontal) > 0f && transform.localScale.x < 0 || Input.GetAxis(inputHorizontal) < 0f && transform.localScale.x > 0)
            {
                Vector2 pos = transform.localScale;
                pos.x *= -1;
                if (pos.x == 1)
                {
                    isLeftDir = false;
                    isRightDir = true;
                    Debug.Log("→");
                    transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, 1, 1);
                    transform.GetChild(1).gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                if (pos.x == -1)
                {
                    isLeftDir = true;
                    isRightDir = false;
                    Debug.Log("←");
                    transform.GetChild(0).gameObject.transform.localScale = new Vector3(-1, 1, 1);
                    transform.GetChild(1).gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }
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
        }
        if (col.gameObject.tag == "RightBody")
        {
            isRight = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        anim.SetTrigger("stand");
        if (col.gameObject.tag == "head")
        {
            isBound = true;
        }

        if (col.gameObject.tag == "RightAttack")
        {
            rigidPlayer.velocity = new Vector2(3, 5);
        }
        if (col.gameObject.tag == "LeftAttack")
        {
            rigidPlayer.velocity = new Vector2(-3, 5);
        }
    }


    void Jump()
    {
        if (Input.GetButton(inputJump) && (isJump == true) || isBound == true)
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
            transform.GetChild(1).gameObject.SetActive(true);
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
            transform.GetChild(1).gameObject.SetActive(false);
            isAttack = false;
        }
    }
}
