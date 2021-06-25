using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvelChoosingMenuCameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3 offsetRotated;

    void Start()
    {

        offset = transform.position - target.position;

    }

    void Update()
    {
        transform.position = target.position + (target.rotation * offset);
        transform.LookAt(target);
    }
}
