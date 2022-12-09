using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectGUI : MonoBehaviour
{
    [SerializeField] private GUIManager LevelSelectGUIManager;

    // Start is called before the first frame update
    void Start()
    {
        SetUpGUI();
    }

    public void SetUpGUI()
    {
        LevelSelectGUIManager.GenerateGUICanvas();
        LevelSelectGUIManager.GenerateBackgroundCanvas();
        LevelSelectGUIManager.GenerateEventSystem();
        LevelSelectGUIManager.GenerateBackground();
        LevelSelectGUIManager.GeneratePauseButton(1);
        LevelSelectGUIManager.GenerateTitleText(new Vector2(0, 0), new Vector2(0, 0), "Levels");
    }

}
