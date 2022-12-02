using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuGUI : MonoBehaviour
{
    [Header("Title Settings")]
    [SerializeField] private Vector2 Position;
    [SerializeField] private Vector2 Size;
    [SerializeField] private string TitleText;

    private GUIManager MainMenuGUIManager = new();
    void Start()
    {
        SetUpGUI();
    }

    public void SetUpGUI()
    {
        MainMenuGUIManager.GenerateGUICanvas();
        MainMenuGUIManager.GenerateEventSystem();
        MainMenuGUIManager.GenerateBackgroundCanvas();
        MainMenuGUIManager.GenerateBackground();
        GenerateTitleText();
        MainMenuGUIManager.GenerateDailyPuzzleButton();


    }
    public void GenerateTitleText()
    {
        GameObject title = new GameObject();
        title.name = "Title Text";
        title.AddComponent<TextMeshProUGUI>();

        title.GetComponent<TextMeshProUGUI>().text = TitleText;

        title.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;

        Position = new Vector2(GameObject.Find("GUICanvas").GetComponent<RectTransform>().localPosition.x, GameObject.Find("GUICanvas").GetComponent<RectTransform>().localPosition.y * 1.65f);
        title.transform.localPosition = Position;

        title.transform.SetParent(GameObject.Find("GUICanvas").GetComponent<Transform>());

        MainMenuGUIManager.GenerateTextBoxBackground(title, 1);
    }

}
