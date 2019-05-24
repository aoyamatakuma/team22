using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlyerSet : MonoBehaviour
{
    [SerializeField]
    private GameObject Player1;
    [SerializeField]
    private GameObject Player2;
    [SerializeField]
    private GameObject Player3;
    [SerializeField]
    private GameObject Player4; 
    void Start()
    {
    }

 void Update() {   
      if (Player1.tag == "Player1")
        {
                Debug.Log("uofdiuvsdfvhsei");
           if(Input.GetButton("GamePad1_Jump"))
      {
            Player1.SetActive (true);
      } 
        }
         else if(Player2.tag == "Player2")
        {
           if(Input.GetButton("GamePad2_Jump"))
      {
            Player2.SetActive (true);
      } 
        }
         else if(Player3.tag  == "Player3")
        {
           if(Input.GetButton("GamePad3_Jump"))
      {
            Player3.SetActive (true);
      } 
        }
    else if (Player4.tag == "Player4")
        {
           if(Input.GetButton("GamePad4_Jump"))
      {
            Player4.SetActive (true);
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
