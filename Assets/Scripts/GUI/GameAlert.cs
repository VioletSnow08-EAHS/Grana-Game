using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameAlert : MonoBehaviour
{
    [SerializeField] public GameObject thisAlert;
    [SerializeField] public float duration;

    // Start is called before the first frame update
    void Start()
    {
        Color currentColor = thisAlert.GetComponent<TextMeshProUGUI>().color;
        thisAlert.GetComponent<TextMeshProUGUI>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
        StartCoroutine(AnimateFade());

    }

    private IEnumerator AnimateFade()
    {
        float duration = this.duration; 
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            thisAlert.GetComponent<TextMeshProUGUI>().alpha = alpha;
            currentTime += Time.deltaTime;
            yield return null;
        }
        DestroyObject(thisAlert);
        yield break;
    }
}
