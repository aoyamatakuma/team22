using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public int score;
    public float time;
    private Spotlight spotLight;
    private Text scoreText;
    public GameObject obj;
    [SerializeField]
    private GameObject player;

    public GameObject tim;

    // Start is called before the first frame update
    void Start()
    {
        tim = GameObject.Find("Time");
        player = GameObject.Find(obj.name);
        //scoreText = GameObject.Find(obj.name).GetComponent<Text>();
        scoreText = GetComponent<Text>();
        score = 0;
        spotLight = GetComponent<Spotlight>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ;
        if (tim.GetComponent<Timer>().TimeUp())
        {
            Debug.Log("uwa----------i");
            Score.AddScore(score);
        }

        if (player.GetComponent<CharacterController>().isOn&&
            player.GetComponent<CharacterController>().islight)
            score++;
        if(player.name==obj.name)
        scoreText.text = "" + score;
    }
}
