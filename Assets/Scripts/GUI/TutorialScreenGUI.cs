using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreenGUI : MonoBehaviour
{
    [SerializeField] private GUIManager _guiManager;
    // Start is called before the first frame update
    void Start()
    {
        string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."; // read JSON code is in GUIManager under StartGame
        
        _guiManager.GenerateGUICanvas();
        _guiManager.GenerateBackgroundCanvas();
        _guiManager.GenerateEventSystem();
        _guiManager.GenerateBackground();
        _guiManager.GeneratePauseButton();
        _guiManager.GenerateTextBox(new Vector2(0, 0), "TutorialText", new Vector2(350,700),35, text);
        _guiManager.StartGame("testing");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
