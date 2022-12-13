using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private GUIManager manager;

    void Start()
    {
        PauseMenuInit();
    }

    public void PauseMenuInit()
    {
        GenerateMenuExitButton(pauseMenu);
        GenerateMainMenuButton();
    }

    public void GenerateMenuExitButton(GameObject Parent)
    {
        GameObject exitButton = Instantiate((GameObject)Resources.Load("Prefabs/ExitButtonPrefab"), new Vector3(0, 0, 0), Quaternion.identity);
        exitButton.name = "ExitButton";
        exitButton.GetComponent<ExitButton>().SetParentGameObject(Parent);
        exitButton.GetComponent<RectTransform>().position = new Vector3(Screen.width * .815f, Screen.height * .715f, 0); //needs to be optimized to account for all screen sizes
        exitButton.transform.SetParent(Parent.transform);
    }

    public void GenerateMainMenuButton()
    {
        GameObject mainMenuButton = Instantiate((GameObject)Resources.Load("Prefabs/MainMenuButtonPrefab"), new Vector3(0, 0, 0), Quaternion.identity);
        mainMenuButton.name = "MainMenuButton";

        mainMenuButton.transform.SetParent(pauseMenu.transform);

        mainMenuButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }
}
