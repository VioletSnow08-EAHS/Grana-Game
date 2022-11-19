using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUIManager : MonoBehaviour
{
    [Header(" Element Settings ")]
    [SerializeField] private Color keyColor;


    private GameObject GUICanvas;
    private GameObject EventSystem;
    private GameObject Keyboard;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGUICanvas();
        GenerateEventSystem();
        GenerateKeyboard();
        GenerateTextInputBox();
        GenerateBackground();
    }

    private void GenerateGUICanvas()
    {
        GameObject empty = new GameObject();
        empty.name = "Canvas Container";
        GUICanvas = Instantiate((GameObject)Resources.Load("Prefabs/GUICanvasPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        GUICanvas.name = "GUICanvas";
        GUICanvas.transform.parent = empty.transform;
    }

    private void GenerateEventSystem()
    {
        EventSystem = Instantiate((GameObject)Resources.Load("Prefabs/EventSystemPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        EventSystem.name = "GUIEventSystem";
        EventSystem.transform.SetParent(GUICanvas.transform);
    }

    public void GenerateKeyboard()
    {
        Keyboard = Instantiate((GameObject)Resources.Load("Prefabs/KeyboardPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);

        Keyboard.name = "Keyboard";
        Keyboard.transform.SetParent(GUICanvas.transform);
    }
    public void GenerateTextInputBox()
    {
        GameObject newTextBox = Instantiate((GameObject)Resources.Load("Prefabs/TextOutputPrefab"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        newTextBox.name = "TextOutput";
        newTextBox.GetComponent<TextInput>().SetCurrentTextBox(newTextBox);
        Keyboard.GetComponent<Keyboard>().TextOutPut = newTextBox;
    }

    public void GenerateBackground()
    {
        GameObject background = Instantiate((GameObject)Resources.Load("Prefabs/Backgrounds/Background-Gray"));
        background.name = "Background";
        background.transform.SetParent(GUICanvas.transform);
    }
}
