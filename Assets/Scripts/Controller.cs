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

    void Start()
    {
        Time.timeScale = 0;
        startMenu.SetActive(true);
    }

    public void StartLevel()
    {
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
    // Update is called once per frame
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
}
