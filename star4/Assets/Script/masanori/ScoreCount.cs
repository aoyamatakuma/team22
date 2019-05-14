using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    private int score,count,runk;

    private Text scoreText;

    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private GameObject gold;
    [SerializeField]
    private GameObject silver;
    [SerializeField]
    private GameObject bronze;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        if (obj.name=="4")
        {
            score = Score.scores[0];
        }
        else if (obj.name=="3")
        {
            score = Score.scores[1];
        }
        else if (obj.name == "2")
        {
            score = Score.scores[2];
        }
        else if (obj.name == "1")
        {
            score = Score.scores[3];
        }
        scoreText = GetComponent<Text>();

        foreach(int a in Score.scores)
        {
            if(score<a)
            {
                runk++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(count<score)
        count++;

        if(count==score)
        {
            if(runk==0)
            {
                gold.SetActive(true);
            }
            else if(runk==1)
            {
                silver.SetActive(true);
            }
            else if(runk==2)
            {
                bronze.SetActive(true);
            }
        }

        scoreText.text = ""+count;
    }
}
