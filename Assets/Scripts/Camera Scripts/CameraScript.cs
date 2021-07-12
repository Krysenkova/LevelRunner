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

    void Start()
    {
        position = target.position;
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {

        Vector3 currentPos = target.position + (target.rotation * offset);
        transform.position = currentPos;
        transform.LookAt(target);

    }

}