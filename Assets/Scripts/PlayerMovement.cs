using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerMovement : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 0.01f;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player follows the path
        distance += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distance);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distance);
    }
}
