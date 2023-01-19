using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuGUI : MonoBehaviour
{
    [Header("Title Settings")]
    [SerializeField] private Vector2 Position;
    [SerializeField] private Vector2 Size;
    [SerializeField] private Sprite TitleImage;

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
        MainMenuGUIManager.GenerateBackground(/*Resources.Load<Sprite>("Images/backgroundBlue")*/);
        MainMenuGUIManager.GenerateTitleText(new Vector2(0, 0), TitleImage);
        /*MainMenuGUIManager.GenerateMenuButton("DPB", "DAILY", new Vector2(0, 100));       */ //Commented until daily puzzle implementation
        MainMenuGUIManager.GenerateMenuButton("LVM", "LEVELS", new Vector2(0, -100));
        MainMenuGUIManager.GenerateMenuButton("TUT", "TUTORIAL", new Vector2(0, -300));
    }
}
