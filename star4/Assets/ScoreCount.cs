using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    private int score,count;

    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = Score.scores[3];
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(count<=score)
        count++;

        scoreText.text = ""+count;
    }
}
