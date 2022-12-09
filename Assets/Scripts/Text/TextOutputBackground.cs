using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOutputBackground : MonoBehaviour
{
    [SerializeField] private RectTransform RectTransform;
    [SerializeField] private RectTransform ParentRectTransform;
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
        RectTransform.sizeDelta = new Vector2(ParentRectTransform.sizeDelta.x, ParentRectTransform.sizeDelta.y);
        RectTransform.localScale = new Vector2(ParentRectTransform.sizeDelta.x, ParentRectTransform.sizeDelta.y);
    }
}
