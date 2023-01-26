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
    private GameObject PageHolder;
    
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

        PageHolderInit();
        
        /*GameObject swipeArea = new GameObject();
        swipeArea.AddComponent<RectTransform>();
        swipeArea.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        swipeArea.transform.SetParent(PageHolder.transform, true);
        swipeArea.GetComponent<RectTransform>().localPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);*/
        
        foreach (var page in pages)
        {

            var textPage = new GameObject();
            textPage.name = $"TextPage {pgNum}";
            textPage.AddComponent<TextMeshProUGUI>();
            textPage.GetComponent<TextMeshProUGUI>().text = pages[pgNum];
            textPage.GetComponent<TextMeshProUGUI>().fontSize = 55;
            textPage.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            textPage.GetComponent<TextMeshProUGUI>().margin = new Vector4(70, (int)(Screen.height * 0) /*temp*/ , 70, 70);
            textPage.GetComponent<RectTransform>().sizeDelta = new Vector3(Screen.width, Screen.height * (float)0.90, 0);
            textPage.GetComponent<RectTransform>().localPosition = new Vector3(Screen.width * spacingFactor, Screen.height / (float)2.5, 0);

            textPage.transform.SetParent(PageHolder.transform, false);
            textPage.transform.SetAsLastSibling();

            spacingFactor++;
            pgNum++;
        }
    }

    private void PageHolderInit()
    {
        PageHolder = new GameObject();
        PageHolder.name = "PageHolder";
        PageSwiper swiper = PageHolder.AddComponent<PageSwiper>();
        swiper.totalPages = 4; //I WILL FIX THIS SO IT'S DYNAMIC EVENTUALLY
        PageHolder.transform.SetParent(GameObject.Find("GUICanvas").transform);
    }

}
