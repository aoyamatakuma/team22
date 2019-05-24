using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlyerSet : MonoBehaviour
{
    [SerializeField]
    private GameObject Player1;
    [SerializeField]
    private GameObject Player1End;
    [SerializeField]
    private GameObject Player1Info;
    [SerializeField]
    private GameObject Player2;
    [SerializeField]
    private GameObject Player2End;
    [SerializeField]
    private GameObject Player2Info;
    [SerializeField]
    private GameObject Player3;
    [SerializeField]
    private GameObject Player3End;
    [SerializeField]
    private GameObject Player3Info;
    [SerializeField]
    private GameObject Player4;
    [SerializeField]
    private GameObject Player4End;
    [SerializeField]
    private GameObject Player4Info;
    void Start()
    {
    }

 void Update() {
        if (Player1.tag == "Player1")
        {
            if (Input.GetButton("GamePad1_Jump"))
            {
                Debug.Log("uofdiuvsdfvhsei");
                Player1.SetActive(true);
                Player1End.SetActive(true);
                Player1Info.SetActive(false);
            }
        }
         if (Player2.tag == "Player2")
        {
            if (Input.GetButton("GamePad2_Jump"))
            {
                Debug.Log("ああああああ");
                Player2.SetActive(true);
                Player2End.SetActive(true);
                Player2Info.SetActive(false);
            }
        }
        if (Player3.tag == "Player3")
        {
            if (Input.GetButton("GamePad3_Jump"))
            {
                Player3.SetActive(true);
                Player3End.SetActive(true);
                Player3Info.SetActive(false);
            }
        }
        if (Player4.tag == "Player4")
        {
            if (Input.GetButton("GamePad4_Jump"))
            {
                Player4.SetActive(true);
                Player4End.SetActive(true);
                Player4Info.SetActive(false);
            }
        }


        if(Player1.activeSelf&&
        Player2.activeSelf&&
        Player3.activeSelf&&
        Player4.activeSelf)
        {
         SceneManager.LoadScene("Star");
        }

 
}
}
