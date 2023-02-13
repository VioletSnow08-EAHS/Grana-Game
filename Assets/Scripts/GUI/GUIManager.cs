using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    private GameObject GUICanvas;
    private GameObject BackgroundCanvas;
    private GameObject Keyboard;
    private GameObject GameManager;

    public void GenerateGUICanvas()
    {
        GameObject empty = new GameObject();
        empty.name = "Canvas Container";
        GUICanvas = Instantiate((GameObject)Resources.Load("Prefabs/GUICanvasPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        GUICanvas.name = "GUICanvas";
        GUICanvas.transform.parent = empty.transform;
    }

    public void GenerateBackgroundCanvas()
    {
        GameObject empty = new GameObject();
        empty.name = "Background Canvas";
        empty.AddComponent<Canvas>();
        empty.AddComponent<CanvasScaler>();
        empty.AddComponent<GraphicRaycaster>();

        empty.GetComponent<RectTransform>().localPosition = new Vector3(GUICanvas.GetComponent<RectTransform>().transform.position.x, GUICanvas.GetComponent<RectTransform>().transform.position.y, 0);
        empty.GetComponent<RectTransform>().sizeDelta = GUICanvas.GetComponent<RectTransform>().sizeDelta;

        empty.transform.SetParent(GUICanvas.transform);
        BackgroundCanvas = empty;
    }

    public void GenerateEventSystem()
    {
        GameObject EventSystem = Instantiate((GameObject)Resources.Load("Prefabs/EventSystemPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        EventSystem.name = "GUIEventSystem";
        EventSystem.transform.SetParent(GUICanvas.transform);
    }

    public void GenerateKeyboard()
    {
        Keyboard = Instantiate((GameObject)Resources.Load("Prefabs/KeyboardPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);

        Keyboard.name = "Keyboard";
        Keyboard.transform.SetParent(GUICanvas.transform);
    }

    public void GenerateTextInputBox(int index)
    {
        GameObject newTextBox = Instantiate((GameObject)Resources.Load("Prefabs/TextOutputPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        newTextBox.name = $"TextOutput";
        newTextBox.GetComponent<TextInput>().SetCurrentTextBox(newTextBox);
        Keyboard.GetComponent<Keyboard>().TextOutPut = newTextBox;
        newTextBox.transform.SetParent(GUICanvas.transform);
        GenerateTextBoxBackground(newTextBox, 1);
    }

    public void GenerateTextBoxBackground(GameObject newTextBox, int index)
    {
        GameObject newTextBoxBackground = Instantiate((GameObject)Resources.Load("Prefabs/TextOutputBackground"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        newTextBoxBackground.name = $"TextOutputBackground {index}";
        newTextBoxBackground.GetComponent<TextOutputBackground>().ParentGameObject = newTextBox;
        newTextBoxBackground.GetComponent<TextOutputBackground>().currentOutputBackground = newTextBoxBackground;
        newTextBoxBackground.GetComponent<TextOutputBackground>().SetImage(index);
        newTextBoxBackground.transform.SetParent(BackgroundCanvas.transform);
    }

    public void GenerateBackground(/*Sprite image*/)
    {
        GameObject background = Instantiate((GameObject)Resources.Load("Prefabs/Backgrounds/Background"));
        background.name = "Background";

        /*background.GetComponent<Background>().SetBackgroundImage(image);*/
        background.transform.SetParent(BackgroundCanvas.transform);
        background.transform.SetSiblingIndex(0);
    }

    public void GeneratePauseButton()
    {
        GameObject pauseButton = Instantiate((GameObject)Resources.Load("Prefabs/PauseButtonPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        pauseButton.name = "Pause Button";
        pauseButton.GetComponent<PauseButton>().SetCurrentButton(pauseButton);
        pauseButton.transform.SetParent(GUICanvas.transform);
        GenerateTextBoxBackground(pauseButton, 0);
    }

    public void GenerateMenuButton(string type, string text, Vector2 position)
    {
        GameObject newButton = Instantiate((GameObject)Resources.Load("Prefabs/MenuButtonPrefab"), position, Quaternion.identity);
        newButton.name = "default_menu_button";
        newButton.GetComponent<MenuButtonManager>().SetCurrentButton(newButton.GetComponent<Button>());
        newButton.GetComponent<MenuButtonManager>().SetType(type);
        /*        newButton.GetComponent<MenuButtonManager>().SetPosition(position);*/
        newButton.GetComponent<MenuButtonManager>().SetButtonText(text);
        newButton.transform.SetParent(GUICanvas.transform);
    }

    public void GenerateTitleText(Vector2 Position, Sprite TitleImage)
    {
        Position = new Vector2(GameObject.Find("GUICanvas").GetComponent<RectTransform>().localPosition.x, GameObject.Find("GUICanvas").GetComponent<RectTransform>().localPosition.y * 1.6f);

        GameObject title = Instantiate((GameObject)Resources.Load("Prefabs/TitlePrefab"), Position, Quaternion.identity);
        title.name = "Title Image";

        title.GetComponent<Image>().sprite = TitleImage;

        title.transform.localPosition = Position;

        title.transform.SetParent(GUICanvas.transform);
    }

    public void GenerateTextBox(Vector2 position, string name, Vector2 size, int fontSize, string text)
    {
        GameObject newTextBox = new GameObject();
        newTextBox.AddComponent<TextMeshProUGUI>();
        newTextBox.transform.SetParent(GUICanvas.transform);

        newTextBox.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
        newTextBox.GetComponent<TextMeshProUGUI>().text = text;
        newTextBox.GetComponent<TextMeshProUGUI>().fontSize = fontSize;
        newTextBox.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
        newTextBox.transform.localPosition = position;
        newTextBox.name = name;
        newTextBox.GetComponent<RectTransform>().sizeDelta = size;
    }

    public void GenerateSubmitButton()
    {
        GameObject newSubmitButton = Instantiate((GameObject)Resources.Load("Prefabs/SubmitButton"), new Vector2(Screen.width / 2, Screen.height * 0.4f), Quaternion.identity);
        newSubmitButton.transform.SetParent(GUICanvas.transform);
    }

    public void GenerateTimer(float time)
    {
        GameObject timer = new GameObject();
        timer.transform.SetParent(GUICanvas.transform);
        timer.name = "GameTimer";
        timer.AddComponent<GameTimer>();
        timer.AddComponent<Image>();
        timer.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        timer.GetComponent<GameTimer>().timer = timer;
        timer.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height * 0.02f);
        timer.GetComponent<RectTransform>().localPosition = new Vector3(Screen.width * -0.5f, Screen.height * 0.45f, 0);
        timer.GetComponent<GameTimer>().gameTime = time;

    }
    
    public void StartGame(string word)
    {
        GameManager = Instantiate((GameObject)Resources.Load("Prefabs/GameManagerPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        GameManager.name = $"GameManager";
        GameManager.GetComponent<GameManager>().SetWord(word);

        //Unnecessary; we already have a way of checking
        /*//read JSON file of anagramsList and send it to GameManager
        var stream = File.ReadAllText("./Assets/Resources/anagramsDefault.json");
        var anagramsList = JsonConvert.DeserializeObject<List<string>>(stream);
        GameManager.GetComponent<GameManager>().SetAnagramsList(anagramsList);
        */

    }
}
