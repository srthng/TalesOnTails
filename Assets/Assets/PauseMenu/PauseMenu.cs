using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject PausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
    }
    void PauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
        }

        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
        }
    }
    void onMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("StartMenu");
    }
}
