using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosingMenuPlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private PlayerAnimation _playerAnimation;
    float moveHorizontal;
    float moveVertical;
    float angle;

    void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

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
            angle += 0.5f * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle -= 0.5f * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _playerAnimation.Go();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _playerAnimation.GoBack();
        }

        Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Quaternion rotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = rotation;

    }

    //manage collisions with levels
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Level"))
        {
            var goName = other.gameObject.name;
            Debug.Log(goName);
            switch (goName)
            {
                case "LevelOne":
                    SceneManager.LoadScene(Tags.LEVEL_ONE_SCENE);
                    break;
                case "LevelTwo":
                    SceneManager.LoadScene(Tags.LEVEL_TWO_SCENE);
                    break;
            }
        }
    }

}
