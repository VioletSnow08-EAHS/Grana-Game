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
        Debug.Log("ButtonPressedCallback tripped");
    }
}
