using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonManager : MonoBehaviour
{
    [Header("Transform Settings")]
    [SerializeField] private Vector2 position;
    [SerializeField] private Vector2 size;
    [SerializeField] private string type;
    [SerializeField] private RectTransform currentRectTransform;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private Button currentButton;

    void Start()
    {
        UpdateRectTransform();
    }

    public void UpdateRectTransform()
    {
        position = GetComponentInParent<RectTransform>().transform.position;
        currentRectTransform.transform.localPosition = position;

        size = GetComponentInParent<RectTransform>().transform.localScale;

        currentButton.onClick.AddListener(() => ButtonPressedCallback());
    }

    public void SetPosition(Vector2 newPosition)
    {
        position = newPosition;
    }

    public void SetSize(Vector2 newSize)
    {
        position = newSize;
    }

    public void SetType(string newType)
    {
        type = newType;
    }

    public void SetButtonText(string newText)
    {
        textMeshProUGUI.text = newText;
    }

    public void SetCurrentRectTransform(RectTransform rectTransform)
    {
        currentRectTransform = rectTransform;
    }

    public void SetCurrentButton(Button newButton)
    {
        currentButton = newButton;
    }

    public void ButtonPressedCallback()
    {
        switch (type)
        {
            case "DPB":
                RedirectToScene("GameScreen");
                break;
            case "LVL":
                break;
            case "LVM":
                RedirectToScene("LevelSelect");
                break;
            case "PSE":
                break;
        }
    }

    public void RedirectToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


}
