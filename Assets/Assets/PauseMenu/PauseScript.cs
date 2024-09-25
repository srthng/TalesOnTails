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

    void Awake()
    {
        document = GetComponent<UIDocument>();
        botao = document.rootVisualElement.Q<Button>("MainButton");
        botao.RegisterCallback<ClickEvent>(onMenu);
    }

    public void onMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("StartMenu");
    }
}
