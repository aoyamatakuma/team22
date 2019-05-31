using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static List<int> scores=new List<int>();

    public List<int> obj = new List<int>();


    public static int scoreEndCount;
    bool isEndScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreEndCount = 0;
        isEndScore = false;
    }

    // Update is called once per frame
    void Update()
    {

        obj = scores;

        ScoreEnd();
    }

    public static void AddScore(int score)
    {
        scores.Add(score);
    }

    void ScoreEnd()
    {

        Debug.Log(scoreEndCount);
        if (scoreEndCount==4)
        {
            
            isEndScore = true;
            scoreEndCount = 0;
        }

        if(isEndScore && Input.GetButton("GamePad1_Jump"))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public static void EndCount()
    {
        scoreEndCount+=1;
    }
}
