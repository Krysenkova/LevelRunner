using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticBoardScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject levelText = GameObject.Find("LevelText");
        Text text = levelText.GetComponent<Text>();
        text.text = "Welcome!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
