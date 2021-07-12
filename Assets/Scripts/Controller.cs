using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject quitMenu;
    public GameObject levelCompleted;
    public GameObject stumpedMenu;
    public GameObject camera;
    public Text cherriesCount;

    public static Controller menuController;
    void Awake()
    {
        menuController = this;
        startMenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("awake");
    }

    public void StartLevel()
    {
        Debug.Log("start level called");
        startMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Tags.LEVEL_CHOOSING_MENU_SCENE);
    }

    public void QuitQuestion()
    {
        pauseMenu.SetActive(false);
        quitMenu.SetActive(true);
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        quitMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void StartAfterStumped()
    {
        stumpedMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AktivateStumpedMenu()
    {
        stumpedMenu.SetActive(true);
    }
    void Update()
    {
        Pause();
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void LevelEnded(int cherries)
    {
        levelCompleted.SetActive(true);
        cherriesCount.text = "You collected " + cherries + " cherries";
        GameController.cherriesTotalAmount += cherries;
    }
}
