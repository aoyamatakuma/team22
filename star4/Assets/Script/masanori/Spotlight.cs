using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public LayerMask layermask;
    public GameObject spotLight;
    int time ,lightNum;

    
    public List<GameObject> Players = new List<GameObject>();

    public List<GameObject> lightPos = new List<GameObject>();
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
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(pos.x,pos.y+(-1)), 100,layermask);

        // 可視化
        Debug.DrawRay(pos, new Vector3(0, 0, 100), Color.black, 1);

        // コンソールにhitしたGameObjectを出力
        if (hit.collider)
        {
            //他に誰もスポットライトに触ってなければislightをtrueにする
            if (Players.Count==0)
            {
                Players.Add(hit.collider.gameObject);
                Players[0].GetComponent<CharacterController>().islight = true;
                Debug.Log(Players.Count);
            }
            Debug.Log(hit.collider);
        }
        else 
        {
            if (Players.Count >= 1)
            {
                Players[0].GetComponent<CharacterController>().islight = false;
            }
            Players.Clear();
        }

        //スポットライトの位置を一定時間ごとに変更する
        //if(time>=30)
        //{
        //    spotLight.transform.position = lightPos[lightNum].transform.position;
        //    lightNum++;
        //    time = 0;
        //    if(lightNum>2)
        //    {
        //        lightNum = 0;
        //    }
        //}
    }

    
}
