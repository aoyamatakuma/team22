using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]
    GameObject spotLight;

    [SerializeField]
    List<GameObject> indications = new List<GameObject>();


    System.Random rand = new System.Random();

    private GameObject time;

    int count=0, oldCount;

    int timer;
    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.Find("Time");
        oldCount = count;
        spotLight.SetActive(true);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time.GetComponent<Timer>().GetTime())
        {
            timer++;
            if (timer >= 120 && oldCount == count)
            {
                while (oldCount == count)
                {
                    count = rand.Next(indications.Count);
                }

                indications[count].SetActive(true);
            }

            if (timer >= 180)
            {
                indications[count].SetActive(false);
                spotLight.transform.position = indications[count].transform.position-new Vector3(0,0.6f,0);
                //spotLights[oldCount].SetActive(false);
                //spotLights[count].SetActive(true);

                oldCount = count;
                timer = 0;
            }
        }


    }
}
