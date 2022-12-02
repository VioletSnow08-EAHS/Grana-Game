using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DailyPuzzleButtonManager : MonoBehaviour
{
    [Header("Transform Settings")]
    [SerializeField] private Vector2 position;
    [SerializeField] private Vector2 size;
    [SerializeField] private RectTransform currentRectTransform;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    [Header("Misc. Settings")]
    [SerializeField] private string Text;

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
        textMeshProUGUI.text = Text;

        currentButton.onClick.AddListener(() => ButtonPressedCallback());
    }

    public void SetCurrentButton(Button newButton)
    {
        currentButton = newButton;
    }

    public void ButtonPressedCallback()
    {
        Debug.Log("ButtonPressedCallback tripped");
        SceneManager.LoadScene("GameScreen");
    }
}
