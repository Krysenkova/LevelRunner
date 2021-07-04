using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 2f;
    private bool onLeftSide = false;
    private bool onRightSide = false;
    private bool inTheMiddle = true;

    public Transform MiddlePosition;
    public Transform RightPosition;
    public Transform LeftPosition;

    private Rigidbody body;
    private Vector3 jump;
    public float jumpPower = 2f;
    private bool landed;

    private bool runs = true;
    private bool jumped = false;
    private bool stumped = false;
    private bool isRunning;
    private bool isJumping;

    private int currentPath = 1; //0 - left, 1 - middle, 2- right
    private Vector3 currentPosition;
    private Quaternion currentRotation;
    public Transform groundPosition;
    [SerializeField] private LayerMask layerMask;
    private bool canDoubleJump;

    public Text cherriesCountText;
    private int cherriesCount = 0;
    private PlayerAnimation playerAnimation;

    private float jumpTime;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        groundPosition = transform.GetChild(3).transform;
        jump = new Vector3(0.0f, 0.2f, 0.0f);
        jumpTime = 0;
        isRunning = true;
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

        cherriesCountText.text = "" + cherriesCount;
        if (isRunning)
        {
            PlayerRun();
        }
        if (jumpTime <= 0)
        {
            isJumping = false;
        }
    }


    void PlayerRun()
    {
        PlayerJump();
        //if (!stumped)
        //{
        playerAnimation.Run();
        //player follows the path
        if (inTheMiddle)
        {
            currentPath = 1;
            Debug.Log("In the middle");
            currentPosition = MiddlePosition.transform.position;
            currentRotation = MiddlePosition.transform.rotation;
          

        }
        else if (onLeftSide)
        {
            currentPath = 0;
            Debug.Log("On the left");
            currentPosition = LeftPosition.transform.position;
            currentRotation = LeftPosition.transform.rotation;

        }
        else if (onRightSide)
        {
            currentPath = 2;
            Debug.Log("On the right");
            currentPosition = RightPosition.transform.position;
            currentRotation = RightPosition.transform.rotation;
        }
        if (isJumping)
        {
            playerAnimation.Jumped();
            Debug.Log("I AM IN JUMP");
            SetJumpTime();
            jumpTime = jumpTime -= Time.deltaTime;
            Debug.Log("Time: " + jumpTime);
           // body.velocity = Vector3.up * jumpPower;
            //body.AddForce(jump, ForceMode.Impulse);
            currentPosition = new Vector3(currentPosition.x, 1f, currentPosition.z);
                if (currentPath == 1)
                {
                    Debug.Log("GettingBack to 1");
                    inTheMiddle = true;

                }

        }

        transform.position = currentPosition;
        transform.rotation = currentRotation;
        
        CheckPath();
       



    }

    void SetJumpTime()
    {
        jumpTime = 0.008f;
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            onRightSide = false;
            onLeftSide = false;
            inTheMiddle = false;

            //  transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
        }
        // if (Input.GetKeyDown(KeyCode.Space))
        //  {
        //if (CheckLanded())
        //     isRunning = false;

        //    canDoubleJump = true;
        // currentPosition = new Vector3(currentPosition.x, currentPosition.y + jumpPower, currentPosition.z);
        //        body.AddForce(new Vector3(0f, 10f, 0f), ForceMode.Impulse);
        //  }
        // isRunning = false;
        // body.velocity = Vector3.up * jumpPower;
        //    Debug.Log("JUMP");

        // }
        // if(Input.GetKeyUp(KeyCode.Space) && !landed)
        // {
        //     isRunning = true;

    }


    bool CheckLanded()
    {
        landed = Physics.OverlapSphere(groundPosition.position, 0.1f, layerMask).Length > 0;
        return landed;
    }

    //manage right/left paths
    void CheckPath()
    {
        //implement smooth pathchange
        if (Input.GetKeyDown(KeyCode.LeftArrow))
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
        if (Input.GetKeyDown(KeyCode.RightArrow))
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stump"))
        {
            // stumped = true;
            Time.timeScale = 0;
            Debug.Log("Stumped");
        }
        if (other.gameObject.CompareTag("Cherry"))
        {
            other.gameObject.SetActive(false);
            cherriesCount++;
        }
        if (other.gameObject.CompareTag("Stop"))
        {
            isRunning = false;
            playerAnimation.RunLeft();
        }
    }

}


