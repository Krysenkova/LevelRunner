using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Movement : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 0.01f;
    private float distance;
    private Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distance);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distance);
    }
}
