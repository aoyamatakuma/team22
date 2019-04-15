using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidPlayer;
    public float speed = 3.0f;
    public float jumpForce = 250.0f;
    //Animator anim;
    public LayerMask groundLayer;
    public bool isDead;
    public bool isJump;
    //public GameObject refObj;
    //public GameObject GameOverSE;
    //public GameObject JumpSE;
    //public GameObject return1;
    //public GameObject return2;
    //public GameObject return3;

    //MainManager mainManager;
    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        ////mainManager = GetComponent<MainManager>();

        isDead = false;
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position,
            transform.position - (transform.up * 2f), groundLayer);

        //LoadManager3 loadManager3 = return3.GetComponent<LoadManager3>();
        //loadManager3.Return3();
        //SceneManager.LoadScene("Stage1");

        if (isDead) { return; }
        //死んでいたらこの先処理しない
        if (hit.collider && Input.GetButtonDown("Jump"))
        {
            rigidPlayer.AddForce(Vector2.up * jumpForce);
            //JumpSE.GetComponent<AudioSource>().Play();
            //anim.SetTrigger("jump");
            //MainManager mainManager = GetComponent<MainManager>();
           // mainManager.Restart();
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
    //void OnCollisionEnter2D(Collision2D col)//トラップに当たった時死ぬ
    //{
    //    if (col.gameObject.tag == "Enemy")
    //    {

    //        //if (isDead) { return; }
    //        //anim.SetTrigger("damage");
    //        //Debug.Log("死んだ");
    //        //isDead = true;
    //        //GameOverManager a = refObj.GetComponent<GameOverManager>();
    //        //a.PopUp();
    //        ////SceneManager.LoadScene("GameOver");
    //        //GameOverSE.GetComponent<AudioSource>().Play();

    //        ////MainManager mainManager = GetComponent<MainManager>();
    //        ////mainManager.Restart();
    //        ////anim.SetTrigger("damage");

    //    }
    //}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "ground")
        {
             Debug.Log("ジャンプ可能");
            if (isDead) { return; }
            isJump = true;
            if (Input.GetKeyDown(KeyCode.A) && isJump)
            {
                isJump = false;
               rigidPlayer.velocity = Vector2.zero;
               rigidPlayer.AddForce(Vector2.up * jumpForce);
                Debug.Log("ジャンプした");
                //JumpSE.GetComponent<AudioSource>().Play();
                //anim.SetTrigger("jump");
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isJump = false;
        }
    }
}
