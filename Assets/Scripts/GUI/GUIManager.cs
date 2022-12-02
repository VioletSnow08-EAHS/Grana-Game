using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    private GameObject GUICanvas;
    private GameObject BackgroundCanvas;
    private GameObject Keyboard;

    // Start is called before the first frame update
    void Start()
    {

    }

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
        newTextBox.name = $"TextOutput {index}";
        newTextBox.GetComponent<TextInput>().SetCurrentTextBox(newTextBox);
        Keyboard.GetComponent<Keyboard>().TextOutPut = newTextBox;
        newTextBox.transform.SetParent(GUICanvas.transform);
        GenerateTextBoxBackground(newTextBox, index);
    }

    public void GenerateTextBoxBackground(GameObject newTextBox, int index)
    {
        GameObject newTextBoxBackground = Instantiate((GameObject)Resources.Load("Prefabs/TextOutputBackground"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        newTextBoxBackground.name = $"TextOutputBackground {index}";
        newTextBoxBackground.GetComponent<TextOutputBackground>().ParentGameObject = newTextBox;
        newTextBoxBackground.transform.SetParent(BackgroundCanvas.transform);
    }

    public void GenerateBackground()
    {
        GameObject background = Instantiate((GameObject)Resources.Load("Prefabs/Backgrounds/Background-Gray"));
        background.name = "Background";

        background.transform.SetParent(BackgroundCanvas.transform);
        background.transform.SetSiblingIndex(0);
    }

    public void GenerateDailyPuzzleButton()
    {
        GameObject newButton = Instantiate((GameObject)Resources.Load("Prefabs/DailyButtonPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        newButton.name = "DailyPuzzleButton";
        newButton.GetComponent<DailyPuzzleButtonManager>().SetCurrentButton(newButton.GetComponent<Button>());
        newButton.transform.SetParent(GUICanvas.transform);
    }
}
