using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSelect : MonoBehaviour
{
    Animator anim;
    int cntPause;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cntPause = 0;
        anim.SetTrigger("Off");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("GamePad_Vertical") > 0.9f)
        {
            cntPause--;
            if (cntPause == 0)
            {
                anim.SetTrigger("Off");
            }
            if (cntPause <= 0)
            {
                cntPause = 0;
            }
        }
        if (Input.GetAxis("GamePad_Vertical") < -0.9f)
        {
            cntPause++;

            if (cntPause == 1)
            {
                anim.SetTrigger("On");
            }
            if (cntPause >= 1)
            {
                cntPause = 1;
            }
        }

        if (cntPause == 1 && Input.GetButton("GamePad_A"))
        {
            Application.Quit();
        }
    }
}
