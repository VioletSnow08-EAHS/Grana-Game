using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUIManager : MonoBehaviour
{
    [Header(" GUI Elements Prefabs ")]      //Move to ScreenGUIElements
    [SerializeField] private GameObject ScreenGUI;
    [SerializeField] private GameObject GUICanvasPrefab;
    [SerializeField] private GameObject EventSystemPrefab;
    [SerializeField] private GameObject KeyboardPrefab;
    [SerializeField] private TextInput TextInputPrefab;

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
        /*GenerateTextInputBox();*/
    }

    private void GenerateGUICanvas()
    {
        GUICanvas = Instantiate(GUICanvasPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        GUICanvas.name = "GUICanvas";
        GUICanvas.transform.parent = ScreenGUI.transform;
    }

    private void GenerateEventSystem()
    {
        EventSystem = Instantiate(EventSystemPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        EventSystem.name = "GUIEventSystem";
        EventSystem.transform.SetParent(GUICanvasPrefab.transform);
    }

    public void GenerateKeyboard()
    {
        Keyboard = Instantiate(KeyboardPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        Keyboard.name = "Keyboard";
        Keyboard.transform.SetParent(GUICanvas.transform);
    }
}
