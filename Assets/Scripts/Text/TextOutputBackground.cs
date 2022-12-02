using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOutputBackground : MonoBehaviour
{
    [SerializeField] private RectTransform RectTransform;
    public GameObject ParentGameObject;


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
}
