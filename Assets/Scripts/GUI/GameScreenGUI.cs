using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenGUI : MonoBehaviour
{
    [SerializeField] private GUIManager GameScreenGUIManager;

    [SerializeField] private string gameWord;

    void Start()
    {
        gameWord = "LEMONS";
        
        GameScreenGUIManager.GenerateGUICanvas();
        GameScreenGUIManager.GenerateSafeArea();
        GameScreenGUIManager.GenerateBackgroundCanvas();
        GameScreenGUIManager.GenerateEventSystem();
        GameScreenGUIManager.GenerateKeyboard();
        GameScreenGUIManager.GenerateTextInputBox(1);
        GameScreenGUIManager.GenerateBackground(/*Resources.Load<Sprite>("Images/backgroundBlue")*/);
        GameScreenGUIManager.GeneratePauseButton();
        GameScreenGUIManager.StartGame(gameWord);
        GameScreenGUIManager.GenerateTextBox(new Vector2(0, 200), "GameWordDisplay", new Vector2(Screen.width * .8f, Screen.height * .075f), 100, gameWord);
        GameScreenGUIManager.GenerateSubmitButton();
        GameScreenGUIManager.GenerateTextBox(new Vector2(Screen.width * .25f, Screen.height * .40f), "ScoreBox", new Vector2(Screen.width * .4f, Screen.height * .025f), 50, "Score: ");
        GameScreenGUIManager.GenerateTimer(60);
    }
}
