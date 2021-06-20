using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 0.01f;
    private bool onLeftSide = false;
    private bool onRightSide = false;
    private bool inTheMiddle = true;

    public Transform MiddlePosition;
    public Transform RightPosition;
    public Transform LeftPosition;

    private Rigidbody body;
    public float jumpPower = 100f;
    private bool runs = true;
    private bool jumped = false;
    private bool landed;
    private bool stumped = false;
    private bool readyToJump = true;
    public Transform groundPosition;
    public LayerMask layerMask;
    public Text cherriesCountText;
    private int cherriesCount = 0;
    private PlayerAnimation playerAnimation;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        cherriesCountText.text = ""+ cherriesCount; 
        PlayerRun();

        // PlayerLand();

    }

    void PlayerRun()
    {
        //if (!stumped)
        //{
            playerAnimation.Run();
            //player follows the path

            if (inTheMiddle)
            {
            Debug.Log("In the middle");
            transform.position = MiddlePosition.transform.position;
            transform.rotation = MiddlePosition.transform.rotation;
            }
            else if (onLeftSide)
            {
            Debug.Log("On the left");
            transform.position = LeftPosition.transform.position;
            transform.rotation = LeftPosition.transform.rotation;
        }
            else if (onRightSide)
            {
            Debug.Log("On the right");
            transform.position = RightPosition.transform.position;
            transform.rotation = RightPosition.transform.rotation;
        }
            if (jumped)
            {

                Debug.Log("Jump!");
                playerAnimation.Jumped();
                body.AddForce(new Vector3(0f, jumpPower, 0f));
                // readyToJump = false;
                jumped = false;
            }

            CheckPath();
            CheckLanded();
            CheckJump();
      

    }

    void CheckJump()
    {
        if (Input.GetKeyUp(KeyCode.Space) )
        {
           // readyToJump = true;
            Debug.Log("Check jump");
            jumped = true;
           
        }
      
    }

    void CheckLanded()
    {

        landed = Physics.OverlapSphere(groundPosition.position, 0.1f, layerMask).Length > 0;
       // Debug.Log("Grounded " + landed);
    }

    //manage right/left paths
    void CheckPath()
    {

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
    }


}
