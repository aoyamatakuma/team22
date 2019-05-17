using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	//　トータル制限時間
	private float totalTime;
	
	//　制限時間（秒）
	[SerializeField]
	private float seconds;

         
	//　前回Update時の秒数
	private float oldSeconds;
	private Text timerText;

	Animator anim;

    private bool timeup = false;
    private bool tim ;

	void Start () {
		totalTime = seconds;
		oldSeconds = 0f;
		timerText = GetComponentInChildren<Text>();
		anim=GetComponent<Animator>();


        timeup = false;


        tim = true;
	}

	void Update () {

        //　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        if (timeup)
        {
            Debug.Log("制限時間終了");
            SceneManager.LoadScene("Ending");
        }

        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f) {
			return;
		}
		if(totalTime<=10f)
		{
			timerText.color = new Color(255f / 255f, 93f / 255f, 93f / 255f);
anim.SetTrigger("Trigger");
		}
		
		//　一旦トータルの制限時間を計測；
		totalTime = seconds;
		totalTime -= Time.deltaTime;

		//　再設定
		
		seconds = totalTime;

		//　タイマー表示用UIテキストに時間を表示する
		if((int)seconds != (int)oldSeconds) {
			timerText.text = ((int) seconds).ToString("00");
		}
		oldSeconds = seconds;

        //　制限時間以下になったらtimeupをtrueにする
        if (totalTime <= 0f)
        {
            timeup = true;

        }

        if(totalTime<=10f)
        {
            tim = false;
        }
    }


    public bool GetTimeUp()
    {
        return timeup;
    }

    public bool GetTime()
    {
        return tim;
    }
    }