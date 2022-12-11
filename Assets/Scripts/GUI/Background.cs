using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private RectTransform rectTransform;
    void Start()
    {
        UpdateTransform();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateTransform()
    {
        rectTransform.position = new Vector3(Screen.width / 2, Screen.height / 2, 1);

        rectTransform.localScale = new Vector3(Screen.width, Screen.height, 1);
    }

    /*    public void SetBackgroundImage(Sprite image)
        {
            background.GetComponent<Image>().sprite = image;
        }*/
}
