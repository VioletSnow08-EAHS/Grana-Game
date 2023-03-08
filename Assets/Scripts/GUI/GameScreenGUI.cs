using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenGUI : MonoBehaviour
{
    [SerializeField] private GUIManager GameScreenGUIManager;

    [SerializeField] private string gameWord;

     IEnumerator Start()
    {
        gameWord = "LEMONS";
        
        GameScreenGUIManager.GenerateGUICanvas();
        GameScreenGUIManager.GenerateBackgroundCanvas();
        GameScreenGUIManager.GenerateEventSystem();
        GameScreenGUIManager.GenerateKeyboard();
        GameScreenGUIManager.GenerateTextInputBox(1);
        GameScreenGUIManager.GenerateBackground(/*Resources.Load<Sprite>("Images/backgroundBlue")*/);
        GameScreenGUIManager.GeneratePauseButton();
        GameScreenGUIManager.GenerateSubmitButton();
        GameScreenGUIManager.GenerateTextBox(new Vector2(Screen.width * .25f, Screen.height * .40f), "ScoreBox", new Vector2(Screen.width * .4f, Screen.height * .025f), 50, "Score: ");

        AddBackgroundBlur();
        yield return Countdown();
        Destroy(GameObject.Find("BackgroundBlur(Clone)"));
        
        GameScreenGUIManager.StartGame(gameWord);
        GameScreenGUIManager.GenerateTextBox(new Vector2(0, 200), "GameWordDisplay", new Vector2(Screen.width * .8f, Screen.height * .075f), 100, gameWord);
        GameScreenGUIManager.GenerateTimer(60);
    }
    
    public IEnumerator DisplayAlert(String name, String text, float duration1, float duration2, int fontSize, float inBetween = 0)
    {
        Vector2 size = new Vector2(Screen.width * 0.8f, Screen.height * 0.1f);
        Vector2 position = new Vector2(0, Screen.height * 0.20f);
        GameObject.Find("GUIManager").GetComponent<GUIManager>().GenerateTextBox(position, name, size, fontSize, text);
        GameObject.Find(name).AddComponent<GameAlert>();
        GameObject.Find(name).GetComponent<GameAlert>().thisAlert = GameObject.Find(name);
        GameObject.Find(name).GetComponent<GameAlert>().duration1 = duration1;
        GameObject.Find(name).GetComponent<GameAlert>().duration2 = duration2;
        GameObject.Find(name).GetComponent<GameAlert>().inBetween = inBetween;
        yield return new WaitForSeconds(duration1 + duration2 + inBetween);

    }

    IEnumerator Countdown()
    {
        yield return DisplayAlert("3", "3", 0.7f, 0.1f, 200, 0.3f);
        yield return DisplayAlert("2", "2", 0.7f, 0.1f, 200, 0.3f);
        yield return DisplayAlert("1", "1", 0.7f, 0.1f, 200, 0.3f);
        yield return DisplayAlert("Start", "Start!", 0.5f, 0.4f, 150, 0.3f);
    }
    void AddBackgroundBlur()
    {
        GameObject BackgroundBlur = Instantiate((GameObject)Resources.Load("Prefabs/BackgroundBlur"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        BackgroundBlur.transform.SetParent(GameObject.Find("GUICanvas").GetComponent<Transform>());
        BackgroundBlur.transform.SetAsLastSibling();
    }
    
}
