using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSelect : MonoBehaviour
{
    public Image startImage;
    public Image endImage;
    int cntPause;
    // Start is called before the first frame update
    void Start()
    {
        cntPause = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("GamePad_Vertical") < -0.9f)
        {
            cntPause++;
            if (cntPause >= 1)
            {
                cntPause = 1;
            }
        }
        if (Input.GetAxis("GamePad_Vertical") > 0.9f)
        {
            cntPause--;
            if (cntPause <= 0)
            {
                cntPause = 0;
            }
        }

        //if (Input.GetAxis("GamePad2_Vertical") < -0.9f)
        //{
        //    cntPause++;
        //    if (cntPause >= 1)
        //    {
        //        cntPause = 1;
        //    }
        //}
        //if (Input.GetAxis("GamePad2_Vertical") > 0.9f)
        //{
        //    cntPause--;
        //    if (cntPause <= 0)
        //    {
        //        cntPause = 0;
        //    }
        //}
    }
    void DrawPauseSelect()
    {
        if (cntPause == 0)
        {

        }
        else
        {

        }
    }
}
