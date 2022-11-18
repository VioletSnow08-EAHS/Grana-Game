using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;

public class TextInput : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GameObject currentTextBox;

    [Header(" Raw Dimension Settings ")]
    [Range(0f, 2f)]
    [SerializeField] private float width;
    [Range(0f, 2f)]
    [SerializeField] private float height;

    [Header(" Box Position ")]
    [Range(0f, 2f)]
    [SerializeField] private float X;
    [Range(0f, 2f)]
    [SerializeField] private float Y;
    [Range(0f, 1f)]
    [SerializeField] private float Z;
    private string text = "";

    public void Start()
    {
        /*UpdateRectTransform();*/
    }

    public void Update()
    {
        UpdateRectTransform();
    }

    public void UpdateRectTransform()
    {
        rectTransform.sizeDelta = new Vector2(width, height);

        float xPos = GetComponentInParent<RectTransform>().position.x * X;
        float yPos = GetComponentInParent<RectTransform>().position.y * Y;

        rectTransform.localPosition = new Vector3(xPos, yPos, Z);
    }

    public void SetText(string newText)
    {
        currentTextBox.GetComponent<TextMeshProUGUI>().text = newText;
    }

    public void SetCurrentTextBox(GameObject newTextBox)
    {
        currentTextBox = newTextBox;
    }
    public GameObject GenerateTextInputBox()
    {
        GameObject newTextBox = new GameObject();
        newTextBox.AddComponent<TextInput>();
        newTextBox.AddComponent<TextMeshProUGUI>();

        newTextBox.GetComponent<TextInput>().SetCurrentTextBox(newTextBox);

        return newTextBox;
    }
}
