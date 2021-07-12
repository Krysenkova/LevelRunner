using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Material activeMaterial;
    public Material closedMaterial;
    private GameObject[] levels;
    private int level;
    void Start()
    {
        levels = GameObject.FindGameObjectsWithTag("Level");
        levels[0].layer = 10; //active level
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        level = GameController.level;
        for(int i = 0; i <= level; i++)
        {
            levels[i].layer = 10; //active
            levels[i].GetComponent<MeshRenderer>().material = activeMaterial;
        }
    }
}
