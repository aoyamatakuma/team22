using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public LayerMask layermask;
    public GameObject obj;
    private List<Vector2> pos = new List<Vector2>();
    public int time ,a=0;
    private List<GameObject> objs = new List<GameObject>();

    public List<GameObject> light = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time++;
        Vector3 pos = obj.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(pos.x,pos.y+(-1)), 100,layermask);

        // 可視化
        Debug.DrawRay(pos, new Vector3(0, 0, 100), Color.black, 1);

        // コンソールにhitしたGameObjectを出力
        if (hit.collider)
        {
            if (objs.Count==0)
            {
                objs.Add(hit.collider.gameObject);

                Debug.Log(objs.Count);
            }
            Debug.Log(hit.collider);
        }
        else
        {
            objs.Clear();
        }

        if(time>=30)
        {
            
            obj.transform.position = light[a].transform.position;
            a++;
            time = 0;
            if(a>2)
            {
                a = 0;
            }
        }
    }

    
}
