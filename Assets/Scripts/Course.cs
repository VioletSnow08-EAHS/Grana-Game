using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour
{
    private List<string> wordList = new List<string> { "engagement", "explicit", "contradiction", "association", "parachute", "meeting", "comprehensive", "reduction", "delivery", "arrange" };
    private string courseID;
    private string currentWord;
    private bool isCompleted;

    // Start is called before the first frame update
    void Start()
    {
        currentWord = "hello";
        List<string> list = new List<string>();
    }


}
