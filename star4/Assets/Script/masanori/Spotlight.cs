using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public LayerMask layermask;
    public GameObject obj;
    private float a,b;
    private Vector2 vec1, vec2, vec3,vec4;
    int i,j;
    private List<Vector2> pos = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        pos.Add(new Vector2(-4, 1));
        pos.Add(new Vector2(2, 7));
        pos.Add(new Vector2(4, 0));
        pos.Add(new Vector2(5, 3));

        

        for(i=0;i<pos.Count;i++)
        {
            vec1 = pos[i];
            for(j=i+1;j<pos.Count;j++)
            {
                vec2 = pos[j];
                a = Vector2.Distance(vec1,vec2);
                if (a >= b)
                {
                    b = a;
                    vec3 = vec1;
                    vec4 = vec2;
                }

            }

            
        }
        Debug.Log(b);
        Debug.Log(vec3);
        Debug.Log(vec4);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = obj.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(pos.x,pos.y+(-1)), 100,layermask);

        // 可視化
        Debug.DrawRay(pos, new Vector3(0, 0, 100), Color.black, 1);

        // コンソールにhitしたGameObjectを出力
        if (hit.collider)
        {
            Debug.Log(hit.collider);
        }
    }

    
}
