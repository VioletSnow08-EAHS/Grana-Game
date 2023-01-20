using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class SubmitManager : MonoBehaviour
{
    [SerializeField] private GameObject submitButton;


    // Start is called before the first frame update
    void Start()
    {
        submitButton.GetComponent<Button>().onClick.AddListener(() => SubmitPressedCallback());
    }

    public void SubmitPressedCallback()
    {
        var text = GameObject.Find("TextOutput").GetComponent<TextMeshProUGUI>();

        bool guess = GameObject.Find("GameManager").GetComponent<GameManager>().submitWord(text.text);

        if (guess)
        {
            StartCoroutine(FadeOutCR(text, new Color(0.09803922f, .6666667f, 0, 1)));
        }
        else if (!guess)
        {
            StartCoroutine(FadeOutCR(text, new Color(1, 0, 0.0361886f, 1)));
        }
    }
    private IEnumerator FadeOutCR(TextMeshProUGUI text, Color color)
    {
        float duration = .5f; //.5 secs
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            text.GetComponent<TextMeshProUGUI>().color = color;
            text.GetComponent<TextMeshProUGUI>().alpha = alpha;
            color.a -= 0.1f;
            currentTime += Time.deltaTime;
            yield return null;
        }
        text.text = "";
        text.color = new Color(0, 0, 0.2078432f, 1);
        yield break;
    }
}
