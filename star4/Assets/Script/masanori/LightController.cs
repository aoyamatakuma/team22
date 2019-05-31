using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]
    GameObject spotLight;
    //[SerializeField]
    //List<GameObject> spotLights = new List<GameObject>();
    //[SerializeField]
    //GameObject [] obj = new GameObject[3];

    [SerializeField]
    List<GameObject> indications = new List<GameObject>();


    System.Random rand = new System.Random();

    private GameObject time;

    int count=0, oldCount;

    [SerializeField]
    int timer;


    // Start is called before the first frame update
    void Start()
    {
        Sound.LoadSe("lightup", "スポットライトA");
        time = GameObject.Find("Time");
        oldCount = count;
        spotLight.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (time.GetComponent<Timer>().GetTime())
        {
            if (Timer.lightTime<timer-8 && oldCount == count)
            {
                while (oldCount == count)
                {
                    count = rand.Next(indications.Count);
                }

                indications[count].SetActive(true);
            }

            if (Timer.lightTime<timer-9)
            {
                indications[count].SetActive(false);
                spotLight.transform.position = indications[count].transform.position - new Vector3(0, 0.6f, 0);
                Sound.PlaySe("lightup");
                oldCount = count;
                timer = (int)Timer.lightTime;
            }
        }


    }
}
