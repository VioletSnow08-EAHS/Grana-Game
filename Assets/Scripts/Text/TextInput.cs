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
    [Range(0f, 15f)]
    [SerializeField] private float width;
    [Range(0f, 15f)]
    [SerializeField] private float height;

    [Header(" Box Position ")]
    [Range(0f, 2f)]
    [SerializeField] private float X;
    [Range(0, 2f)]
    [SerializeField] private float Y;
    [Range(0f, 1f)]
    [SerializeField] private float Z;

    public void Start()
    {
        UpdateRectTransform();
    }

    public void UpdateRectTransform()
    {
        rectTransform.sizeDelta = new Vector2(width * Screen.width / 3, height * Screen.height / 5);

        float xPos = Screen.width * X;
        float yPos = Screen.height * Y;

        currentTextBox.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, Z);
    }

    public void SetText(string newText)
    {
        currentTextBox.GetComponent<TextMeshProUGUI>().text = newText;
    }

    public void SetCurrentTextBox(GameObject newTextBox)
    {
        currentTextBox = newTextBox;
    }

    public void SetPosition(Vector2 newPos)
    {
        currentTextBox.transform.localPosition = newPos;
    }
}
