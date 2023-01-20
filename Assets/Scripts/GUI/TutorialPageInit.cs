using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialPageInit : MonoBehaviour
{
    private string pgText = File.ReadAllText("./Assets/Resources/tutorialPGs.json");
    /*private List<string> pages = JsonConvert.DeserializeObject<List<string>>(pgText);*/

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForNextFrameUnit();
        PageMenuInit();
    }

    private void PageMenuInit()
    {
        var pages = JsonConvert.DeserializeObject<List<string>>(pgText);
        var spacingFactor = .5f;
        var pgNum = 0;

        var PageHolder = new GameObject();
        PageHolder.name = "PageHolder";
        PageHolder.transform.SetParent(GameObject.Find("GUICanvas").transform);

        foreach (var page in pages)
        {
            var textPage = new GameObject();
            textPage.name = $"TextPage {pgNum}";
            textPage.AddComponent<TextMeshProUGUI>();
            textPage.GetComponent<TextMeshProUGUI>().text = pages[pgNum];
            textPage.GetComponent<TextMeshProUGUI>().fontSize = 55;
            textPage.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            textPage.GetComponent<RectTransform>().sizeDelta = new Vector3(Screen.width * .65f, Screen.height * .45f, 0);
            textPage.GetComponent<RectTransform>().localPosition = new Vector3(Screen.width * spacingFactor, Screen.height / 2, 0);

            textPage.transform.SetParent(PageHolder.transform, false);
            textPage.transform.SetAsLastSibling();

            spacingFactor++;
            pgNum++;
        }
    }

}
