using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float speed = 0.01f;
    private float distance = 1f;
    private Vector3 offset;
   // private Quaternion rotationOffset;
    public PathCreator pathCreator;

    void Start()
    {
        //let camera be behind the player while going along the path
        offset  = new Vector3(0f, 0.3f, 0f);
       
        //rotationOffset = transform.rotation * target.rotation;
    }

    void Update()
    {
        //camera follows the path
        distance += speed * Time.deltaTime ;
       // transform.position = target.position + offset; 
       // transform.rotation = target.rotation;
        transform.position = pathCreator.path.GetPointAtDistance(distance - 1.8f) + offset;
        transform.rotation = pathCreator.path.GetRotationAtDistance(distance-1.8f);

    }
}