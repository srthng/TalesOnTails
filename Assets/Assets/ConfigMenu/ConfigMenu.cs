using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ConfigMenu : MonoBehaviour
{
    private UIDocument document;
    private Button botao;
    private void Awake()
    {
        document = GetComponent<UIDocument>();
        botao = document.rootVisualElement.Q<Button>("returnButton");
        botao.RegisterCallback<ClickEvent>(onReturn);
    }
    void onReturn(ClickEvent evt)
    {
        SceneManager.LoadScene("StartMenu");
    }
}
