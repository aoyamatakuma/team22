using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static List<int> scores=new List<int>();

    public List<int> obj = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        obj = scores;
    }

    public static void AddScore(int score)
    {
        scores.Add(score);
    }
}
