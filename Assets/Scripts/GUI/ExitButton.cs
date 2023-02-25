using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject ParentGameObject;

    [SerializeField] private RectTransform RectTransform;
    [SerializeField] private Button currentButton;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        currentButton.onClick.AddListener(() => ButtonPressedCallback());
    }

    private void ButtonPressedCallback()
    {
        Debug.Log("Exit Button Pressed");
        GameTimer gameTimer = GameObject.Find("GameTimer").GetComponent<GameTimer>();
        gameTimer.isPaused = false;
        gameTimer.StartCoroutine(gameTimer.UpdateColorCR());
        Destroy(ParentGameObject, 0);
    }

    public void SetParentGameObject(GameObject gameObject)
    {
        ParentGameObject = gameObject;
    }
}

