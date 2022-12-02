using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenGUI : MonoBehaviour
{
    private GUIManager GameScreenGUIManager = new GUIManager();
    void Start()
    {
        GameScreenGUIManager.GenerateGUICanvas();
        GameScreenGUIManager.GenerateBackgroundCanvas();
        GameScreenGUIManager.GenerateEventSystem();
        GameScreenGUIManager.GenerateKeyboard();
        GameScreenGUIManager.GenerateTextInputBox(1);
        GameScreenGUIManager.GenerateBackground();
    }
}
