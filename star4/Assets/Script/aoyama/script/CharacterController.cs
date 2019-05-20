using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    Slider staminaSlider;
    Rigidbody2D rigidPlayer;//物理演算
    Animator anim;//アニメーター
    private float speed = 2.0f;//地上での移動速度
    private float airSpeed = 1.5f;//空中での移動速度
    private float jumpForce = 250.0f;//ジャンプの力
    public float stamina = 100;//体力
    private float playerStamina;//体力代入
    public float fallStamina=20;//体力減少
    public float attackMove;//攻撃の移動範囲
    public float damageMoveY;//ダメージを受けたときの移動範囲Y
    public float damageMoveX;//ダメージを受けたときの移動範囲X
    private bool isJump;//ジャンプ判定
    public bool isAppeal;//アピール判定
    public bool isAttack;//攻撃状態判定
    public bool isOn;
    public bool islight;
    public bool isBound;//頭の上でバウンド中か？
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
        playerStamina = stamina;//スタミナ初期値
        rigidPlayer = GetComponent<Rigidbody2D>();//物理演算取得
        anim = GetComponent<Animator>();//アニメーション取得
        
        isJump = false;
        isAppeal = false;
        isOn = false;
        isLeft = false;
        isRight = false;
        isLeftDir = false;
        isRightDir = false;
        isBound = false;
        isAttack = false;
        islight = false;

        //ここから先はゲームパッドの取得に使います。
        if (gameObject.tag == "Player1")
        {
            inputHorizontal = "GamePad1_Horizontal";
            inputJump = "GamePad1_Jump";
            inputAppeal = "GamePad1_X";
            inputAttack = "GamePad1_B";
            staminaSlider = GameObject.Find("StaminaSlider1").GetComponent<Slider>();//スライダー取得
            
        }
        else if (gameObject.tag == "Player2")
        {
            inputHorizontal = "GamePad2_Horizontal";
            inputJump = "GamePad2_Jump";
            inputAppeal = "GamePad2_X";
            inputAttack = "GamePad2_B";
            staminaSlider = GameObject.Find("StaminaSlider2").GetComponent<Slider>();//スライダー取得
        }
        else if (gameObject.tag == "Player3")
        {
            inputHorizontal = "GamePad3_Horizontal";
            inputJump = "GamePad3_Jump";
            inputAppeal = "GamePad3_X";
            inputAttack = "GamePad3_B";
            staminaSlider = GameObject.Find("StaminaSlider3").GetComponent<Slider>();//スライダー取得
        }
        else
        {
            inputHorizontal = "GamePad4_Horizontal";
            inputJump = "GamePad4_Jump";
            inputAppeal = "GamePad4_X";
            inputAttack = "GamePad4_B";
            staminaSlider = GameObject.Find("StaminaSlider4").GetComponent<Slider>();//スライダー取得
        }
        //ここまで
        staminaSlider.maxValue = playerStamina;
    }
    void Update()
    {
        Jump();
        Move();
        Attack();        
        
        if (Input.GetButton(inputAppeal) && isJump == false)
        {
            isJump = true;
            isAppeal = true;
        }
        if (Input.GetButtonUp(inputAppeal) && isAppeal == true)
        {
            isJump = false;
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
    }
    void Jump()//ジャンプ系
    {
        if (Input.GetButton(inputJump) && (isJump == false) || isBound == true)//ジャンプボタンを押してなおかつジャンプ中じゃないとき
        {
            anim.SetTrigger("jump");
            rigidPlayer.velocity = Vector2.zero;
            rigidPlayer.AddForce(Vector2.up * jumpForce);
            isJump = true;
            isBound = false;
        }
    }
    void Move()//移動系
    {
        float h = Input.GetAxis(inputHorizontal);
        #region//移動
        if (isAppeal != true)
        {
            if (isAttack == false)
            {
                if (h != 0)
                {
                    if (isJump == false)//地上時のスピード
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

                if (isJump == true)
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
                if (isJump == true)
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
            #endregion
            #region//向き判定
            if (Input.GetAxis(inputHorizontal) > 0f && transform.localScale.x < 0 || Input.GetAxis(inputHorizontal) < 0f && transform.localScale.x > 0)
            {
                Vector2 pos = transform.localScale;
                pos.x *= -1;
                if (pos.x == 1)
                {
                    isLeftDir = false;
                    isRightDir = true;
                    transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, 1, 1);
                    transform.GetChild(1).gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                if (pos.x == -1)
                {
                    isLeftDir = true;
                    isRightDir = false;
                    transform.GetChild(0).gameObject.transform.localScale = new Vector3(-1, 1, 1);
                    transform.GetChild(1).gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }
                transform.localScale = pos;
            }
            #endregion
        }
        anim.SetFloat("run", Mathf.Abs(h));//runパラメーター         
    }
    void Attack()
    {
        staminaSlider.value = playerStamina;
        if (playerStamina<100)
        {
            playerStamina += 0.1f;
        }
        if (playerStamina >= fallStamina&&Input.GetButtonDown(inputAttack) && isAttack == false&&isJump==false&&isBound==false)
        {
            isAttack = true;
            StartCoroutine("AttackStart");//コルーチンスタート
        }
        Debug.Log(playerStamina);
    }
    public IEnumerator AttackStart()//アタック（コルーチン使用）
    {
            transform.GetChild(1).gameObject.SetActive(true);//攻撃オブジェクトを出す
            #region//スタミナ減少
            if (playerStamina < fallStamina)
            {
                playerStamina = 0;
            }
            else
            {
                playerStamina = playerStamina - fallStamina;
            }
            #endregion
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
    void OnTriggerStay2D(Collider2D col)//常に当たっている時
    {
        if (col.gameObject.tag == "Ground")
        {
            isJump = false;
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
    void OnTriggerExit2D(Collider2D col)//離れたか時
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
    void OnTriggerEnter2D(Collider2D col)//当たった時
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
}
