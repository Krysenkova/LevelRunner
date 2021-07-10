using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController controller;
    private int level = 0;
    private int cherriesTotalAmount = 0;
    private int cherriesInLevel;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        controller = this;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetLevel()
    {
        return level;
    }

    public int GetTotalAmountOfCherries()
    {
        return cherriesTotalAmount;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public void SetTotalAmountOfCherries(int cherries)
    {
        this.cherriesTotalAmount += cherries;
    }

    public void SetCherriesInLevel(int cherries)
    {
        this.cherriesInLevel = cherries;
    }
}
