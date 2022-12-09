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

    [Header("GUI")]
    [SerializeField] private GUIManager MainMenuGUIManager;
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
        MainMenuGUIManager.GenerateTitleText(new Vector2(0, 0), Size, TitleText);
        MainMenuGUIManager.GenerateMenuButton("DPB", "DAILY", new Vector2(0, 100));       //Commented until daily puzzle implementation
        MainMenuGUIManager.GenerateMenuButton("LVM", "LEVELS", new Vector2(0, -100));
    }
}
