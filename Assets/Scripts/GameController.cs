using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController controller;
    public int level;
    public int cherriesTotalAmount;

    // Start is called before the first frame update
    void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    int GetLevel()
    {
        return level;
    }

    int GetTotalAmountOfCherries()
    {
        return cherriesTotalAmount;
    }

    void SetLevel(int level)
    {
        this.level = level;
    }

    void SetTotalAmountOfCherries(int cherries)
    {
        this.cherriesTotalAmount = cherries;
    }
}
