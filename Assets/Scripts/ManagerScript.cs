using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
  public void StartGame()
    {
        SceneManager.LoadScene(Tags.LEVEL_CHOOSING_MENU_SCENE);
    }
}
