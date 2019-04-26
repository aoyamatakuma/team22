using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    //Animator anim;
    //GameObject pauseObject;//追加
    //Pause script;//追加
    //bool isEnd;
    int cntPause;


    // Start is called before the first frame update
    void Start()
    {
        cntPause = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("GamePad_Vertical") > 0.9f)
        {
            cntPause--;
            if (cntPause == 0)
            {
                //anim.SetTrigger("Start");
            }
            if (cntPause <= 0)
            {
                cntPause = 0;
            }
        }
        if (Input.GetAxis("GamePad_Vertical") < -0.9f)
        {
            cntPause++;
            if (cntPause >= 1)
            {
                cntPause = 1;
                //anim.SetTrigger("Off");
            }
        }

        if (Input.GetAxis("GamePad2_Vertical") > 0.9f)
        {
            cntPause--;
            if (cntPause == 0)
            {
                //anim.SetTrigger("Start");
            }
            if (cntPause <= 0)
            {
                cntPause = 0;
            }
        }
        if (Input.GetAxis("GamePad2_Vertical") < -0.9f)
        {
            cntPause++;
            if (cntPause >= 1)
            {
                cntPause = 1;
               // anim.SetTrigger("Off");
            }
        }
    }
}
