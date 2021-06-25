using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingMenuPlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private PlayerAnimation _playerAnimation;
    float moveHorizontal;
    float moveVertical;
    float angle;

    // Start is called before the first frame update
    void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        angle += moveVertical * 0.01f * Time.deltaTime;

        Vector3 forwardDirection = Vector3.forward * _speed;
        Vector3 rightDirection = Vector3.right * _speed;
                            
        transform.Translate(forwardDirection * Time.deltaTime * moveVertical * _speed);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.rotation *= rotation;
            angle += 0.5f * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle -= 0.5f * _speed * Time.deltaTime;
            //transform.rotation *= rotation;
        }

        Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Quaternion rotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = rotation;

    }

}
