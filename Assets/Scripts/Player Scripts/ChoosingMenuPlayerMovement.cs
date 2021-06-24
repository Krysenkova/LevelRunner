using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingMenuPlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private PlayerAnimation playerAnimation;

    // Start is called before the first frame update
    void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveY;
        transform.position += move * Time.deltaTime * _speed;
        
        if(Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            playerAnimation.Go();
        }
    }
}
