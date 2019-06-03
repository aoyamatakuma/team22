using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public LayerMask layermask;
    public GameObject spotLight;
    int time ,lightNum;

    
    public List<GameObject> Players = new List<GameObject>();

    //public List<GameObject> lightPos = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        lightNum = 0;

    }

    // Update is called once per frame
    void Update()
    {

        time++;
        Vector3 pos = spotLight.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector2(0, - 1f), 1, layermask);

        // 可視化
        Debug.DrawRay(pos, new Vector3(0, -1, 0), Color.black, 1);
        Debug.Log(hit.collider);
        Debug.Log(Players.Count);
        // コンソールにhitしたGameObjectを出力
        if (hit.collider)
        {
            //他に誰もスポットライトに触ってなければislightをtrueにする
            if (Players.Count == 0)
            {
                Players.Add(hit.collider.gameObject);
                Players[0].GetComponent<CharacterController>().islight = true;

            }
            if(hit.collider.name==Players[0].name)
            return;
        }


        Players[0].GetComponent<CharacterController>().islight = false;
        Players.Clear();
    }

    
}
