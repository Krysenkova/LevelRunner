using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerMovement : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 0.01f;
    private float distance;
    private bool onLeftSide = false;
    private bool onRightSide = false;
    private bool inTheMiddle = true;
    public PathCreator rightPath;
    public PathCreator leftPath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //player follows the path

        distance += speed * Time.deltaTime;
        if (inTheMiddle)
        {
            Debug.Log("In the middle");
            transform.position = pathCreator.path.GetPointAtDistance(distance);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distance);
        }
        else if (onLeftSide)
        {
            Debug.Log("On the left");
            transform.position = leftPath.path.GetPointAtDistance(distance);
            transform.rotation = leftPath.path.GetRotationAtDistance(distance);
        }
        else if (onRightSide)
        {
            Debug.Log("On the right");
            transform.position = rightPath.path.GetPointAtDistance(distance); 
            transform.rotation = rightPath.path.GetRotationAtDistance(distance);
        }
        checkPath();

    }

    //manage right/left paths
    void checkPath()
    {
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (inTheMiddle)
            {
                inTheMiddle = false;
                onRightSide = false;
                onLeftSide = true;
            }
            else if (onRightSide)
            {
                onRightSide = false;
                onLeftSide = false;
                inTheMiddle = true;
            }
            else if (onLeftSide)
            {
                return;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (inTheMiddle)
            {
                inTheMiddle = false;
                onLeftSide = false;
                onRightSide = true;
            }
            else if (onLeftSide)
            {
                onLeftSide = false;
                onRightSide = false;
                inTheMiddle = true;
            }
            else if (onRightSide)
            {
                return;
            }

        }
    }
}
