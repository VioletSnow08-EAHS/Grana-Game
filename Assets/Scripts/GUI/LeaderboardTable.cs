using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LeaderboardTable : MonoBehaviour
{

    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject Header;
    /*[SerializeField] private GameObject UsernameTitle;
    [SerializeField] private GameObject ScoreTitle;*/
    
    // Start is called before the first frame update
    void Update()
    {
        Background.GetComponent<RectTransform>().localPosition = new Vector2(0f, Screen.height * 0.5f * -1 * 0.1f);
        Background.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 0.8f, Screen.height * 0.7f);
    }

   
}
