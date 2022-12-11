using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenGUI : MonoBehaviour
{
    [SerializeField] private GUIManager GameScreenGUIManager;

    void Start()
    {
        GameScreenGUIManager.GenerateGUICanvas();
        GameScreenGUIManager.GenerateBackgroundCanvas();
        GameScreenGUIManager.GenerateEventSystem();
        GameScreenGUIManager.GenerateKeyboard();
        GameScreenGUIManager.GenerateTextInputBox(1);
        GameScreenGUIManager.GenerateBackground(/*Resources.Load<Sprite>("Images/backgroundBlue")*/);
        GameScreenGUIManager.GeneratePauseButton(1);
    }
}
