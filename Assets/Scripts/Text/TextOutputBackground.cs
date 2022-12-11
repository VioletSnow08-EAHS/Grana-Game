using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOutputBackground : MonoBehaviour
{
    [SerializeField] private Sprite menuButtonBackground, textBoxBackground;
    [SerializeField] private RectTransform RectTransform;
    public GameObject ParentGameObject;
    public GameObject currentOutputBackground;

    // Start is called before the first frame update
    void Start()
    {
        UpdateRectTransform();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRectTransform();
    }

    public void UpdateRectTransform()
    {
        RectTransform.sizeDelta = new Vector2(ParentGameObject.GetComponent<RectTransform>().sizeDelta.x, ParentGameObject.GetComponent<RectTransform>().sizeDelta.y);
        RectTransform.localPosition = ParentGameObject.GetComponent<RectTransform>().localPosition;
    }

    public void SetImage(int type)
    {
        switch (type)
        {
            case 0:
                currentOutputBackground.GetComponent<Image>().sprite = menuButtonBackground;
                break;
            case 1:
                currentOutputBackground.GetComponent<Image>().sprite = textBoxBackground;
                break;
        }
    }
}
