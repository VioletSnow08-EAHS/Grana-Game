using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectGUI : MonoBehaviour
{
    [SerializeField] private GUIManager LevelSelectGUIManager;
    [SerializeField] private Sprite TitleImage;

    private List<Course> courses = new List<Course>();
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
        LevelSelectGUIManager.GenerateSafeArea();
        LevelSelectGUIManager.GenerateBackground(/*Resources.Load<Sprite>("Images/backgroundBlue")*/);
        LevelSelectGUIManager.GeneratePauseButton();
    }
}
