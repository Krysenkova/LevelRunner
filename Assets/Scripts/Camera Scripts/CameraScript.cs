using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private Quaternion oldRotation;
    Vector3 position;

    // private Quaternion rotationOffset;
    //public PathCreator pathCreator;

    void Awake()
    {
        position = target.position;
        offset = transform.position - target.position;
        //let camera be behind the player while going along the path
        // offset  = new Vector3(0f, 0.5f, 0f);
        // offset = transform.position - target.transform.position;
        //rotationOffset = transform.rotation * target.rotation;
    }

    void FixedUpdate()
    {
        Vector3 currentPos = target.position + (target.rotation * offset);
       
        transform.position = currentPos;
       
        transform.LookAt(target);
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = target.transform.position + offset;

    }
    
}