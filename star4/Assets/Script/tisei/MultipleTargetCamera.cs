using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    //public Camera cam;
    public List<Transform> targets;


    private Vector3 velocity;
    public float smoothTime =0.5f;

    public float minZoom = 40;

    public float maxZoom = 10;

    public float ZoomLimter = 50;

    public Vector3 offset;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
       
        if (targets.Count == 0)

            return;

        Move();
        Zoom();


    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGretestDistance()/50f);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position,newPosition,ref velocity,smoothTime); 

    }

    float GetGretestDistance()
    {
        var bouds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bouds.Encapsulate(targets[i].position);
        }
            return bouds.size.x;
    }
    

    Vector3 GetCenterPoint()
    {
        if(targets.Count ==1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i<targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }

   
}