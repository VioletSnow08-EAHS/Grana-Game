using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [Header("Transform Settings")]
    [SerializeField] private RectTransform currentRectTransform;

    private GameObject currentButton;

    void Start()
    {
        UpdateRectTransform();
    }

    public void UpdateRectTransform()
    {
        currentRectTransform.position = new Vector3(Screen.width * .1f, Screen.height * .9f, 0);
        currentButton.GetComponent<Button>().onClick.AddListener(() => ButtonPressedCallback());
    }

    public void SetCurrentButton(GameObject newButton)
    {
        currentButton = newButton;
    }

    public void ButtonPressedCallback()
    {
        if (GameObject.Find("GameTimer") != null)
        {
            GameObject.Find("GameTimer").GetComponent<GameTimer>().isPaused = true;
        }

        RenderPauseMenu();
    }
    public void RenderPauseMenu()
    {
        GameObject pauseMenu = Instantiate((GameObject)Resources.Load("Prefabs/PauseMenuPrefab"), new Vector3(0, 0, 0), Quaternion.identity);
        pauseMenu.name = "PauseMenu";

        pauseMenu.transform.SetAsLastSibling();
    }
}
