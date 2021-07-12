using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public Transform target;

    void Update()
    {
        //always look at the fox direction
        transform.LookAt(target);
    }
}
