using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseScript : MonoBehaviour
{

    private UIDocument document;
    private Button botao;
    public bool isPaused;
    public PauseMenu pauseMenuscript;

    void Awake()
    {
        pauseMenuscript = FindObjectOfType<PauseMenu>();
        document = GetComponent<UIDocument>();
    }

    void OnEnable()
    {
        botao = document.rootVisualElement.Q<Button>("ResumeButton");
        botao.RegisterCallback<ClickEvent>(onResume);

        botao = document.rootVisualElement.Q<Button>("MainButton");
        botao.RegisterCallback<ClickEvent>(onMenu);

        botao = document.rootVisualElement.Q<Button>("ExitButton");
        botao.RegisterCallback<ClickEvent>(onExit);
    }


    void onResume(ClickEvent evt)
    {
        Debug.Log("Resume");
        pauseMenuscript.ResumeGame();
        Debug.Log("Resume");
    }
    void onMenu(ClickEvent evt)
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("StartMenu");
    }
    void onExit(ClickEvent evt) 
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
