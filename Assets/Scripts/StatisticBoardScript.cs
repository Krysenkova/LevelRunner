using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticBoardScript : MonoBehaviour
{

    Text text;
    Text number;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GameObject levelText = GameObject.Find("LevelText");
        text = levelText.GetComponent<Text>();
        text.text = "Welcome!";
        GameObject cherrieslText = GameObject.Find("Cherries");
        number = cherrieslText.GetComponent<Text>();
        number.text = "Your cherries: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = " You completed " + GameController.level + " level";
        number.text = "Your cherries: " + GameController.cherriesTotalAmount;

    }

}
