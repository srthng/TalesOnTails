using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartMenu : MonoBehaviour
{
    private UIDocument document;
    private Button botao;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        botao = document.rootVisualElement.Q<Button>("PlayButton");
        botao.RegisterCallback<ClickEvent>(onPlay);
        botao = document.rootVisualElement.Q<Button>("ConfigButton");
        botao.RegisterCallback<ClickEvent>(onConfig);
        botao = document.rootVisualElement.Q<Button>("ExitButton");
        botao.RegisterCallback<ClickEvent>(onExit);
    }
    void onPlay(ClickEvent evt)
    {
        SceneManager.LoadScene("MainGame");
    }

    void onConfig(ClickEvent evt)
    {
        SceneManager.LoadScene("ConfigMenu");
    }

    void onExit(ClickEvent evt)
    {
        Application.Quit();
    }
}
