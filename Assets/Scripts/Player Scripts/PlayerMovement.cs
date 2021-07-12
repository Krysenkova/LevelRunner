using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private GameObject _directionPosition;

    private CapsuleCollider foxCollider;
    private Vector3 usualColliderPosition;

    private bool jumped;
    private bool stumped = false;
    private bool isRunning;

    private Vector3 currentPosition;
    private Quaternion currentRotation;

    public Text cherriesCountText;
    private int cherriesCount;

    private PlayerAnimation playerAnimation;
    [SerializeField] private Animator _animator;

    private bool endAnim;
    private bool caught;
    private bool roll;

    void Awake()
    {
        foxCollider = GetComponent<CapsuleCollider>();
        cherriesCount = 0;
        isRunning = true;
        playerAnimation = GetComponent<PlayerAnimation>();
        endAnim = false;
        jumped = false;
        caught = false;
        roll = false;
        _directionPosition = GameObject.Find("DirectionPosition");
        usualColliderPosition = foxCollider.center;
    }

    void Update()
    {
        cherriesCountText.text = "" + cherriesCount;

        if (isRunning)
        {
            PlayerRun();
        }

        //update animator values to stop/start animations
        _animator.SetBool("endAnim", endAnim);
        _animator.SetBool("jump", jumped);
        _animator.SetBool("stumped", stumped);
        _animator.SetBool("caught", caught);
        _animator.SetBool("roll", roll);
    }

    //waiter for jump animation
    IEnumerator StopJumping()
    {
        yield return new WaitForSeconds(0.8f);
        jumped = false;
        foxCollider.center = usualColliderPosition;
        roll = false;
    }

    //manage player position on paths
    void PlayerRun()
    {
        PlayerJump();
        PlayerRoll();
        if (inTheMiddle)
        {

            Debug.Log("In the middle");
            currentPosition = MiddlePosition.transform.position;
            currentRotation = MiddlePosition.transform.rotation;
        }
        else if (onLeftSide)
        {

            Debug.Log("On the left");
            currentPosition = LeftPosition.transform.position;
            currentRotation = LeftPosition.transform.rotation;
        }
        else if (onRightSide)
        {

            Debug.Log("On the right");
            currentPosition = RightPosition.transform.position;
            currentRotation = RightPosition.transform.rotation;
        }

        transform.position = currentPosition;
        transform.rotation = currentRotation;

        CheckPath();

    }

    //control jump when space is clicked
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;
            foxCollider.center = new Vector3(0f, 1.2f, 0f);
            //just 0.8 sec for fox to jump
            StartCoroutine(StopJumping());
        }

    }

    void PlayerRoll()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            roll = true;
            StartCoroutine(StopJumping());
        }
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

    //manage collisions with collectables/obstacles, etc...
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stump"))
        {
            isRunning = false;
            stumped = true;
            Controller.menuController.AktivateStumpedMenu();
            //Time.timeScale = 0;
            Debug.Log("Stumped");
        }
        if (other.gameObject.CompareTag("Cherry"))
        {
            other.gameObject.SetActive(false);
            cherriesCount++;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!roll)
            {
                isRunning = false;
                caught = true;
              
                Controller.menuController.AktivateStumpedMenu();
            }
            if(roll)
            {
                other.gameObject.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("Stop"))
        {

            isRunning = false;
            endAnim = true;
            Controller.menuController.LevelEnded(cherriesCount);
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == Tags.LEVEL_ONE_SCENE)
            {
                GameController.level = 1;

            }
            if (scene.name == Tags.LEVEL_TWO_SCENE)
            {
                GameController.level = 2;

            }
        }
    }

}


