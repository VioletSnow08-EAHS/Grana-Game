using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //initialize unity details
    [Header(" Game Details ")]
    [SerializeField] public string gameWord;
    [SerializeField] private List<string> anagramsList; //might not be necessary;  we can just check if the inputWord is an anagram of the base word -- also check if its a real word
    [SerializeField] private Dictionary<char, int> pointValues;

    [Header("Live Data")]
    [SerializeField] private int totalPoints;
    [SerializeField] private List<string> wordsUsed;
    [SerializeField] private TextMeshProUGUI scoreBox;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        InitializeGame();
        yield return new WaitForEndOfFrame();
        scoreBox = GameObject.Find("ScoreBox").GetComponent<TextMeshProUGUI>();
    }

    //initialize all variables and signal the start of the course with a selected word
    private void InitializeGame()
    {
        totalPoints = 0;
        pointValues = new Dictionary<char, int>()
        {
            {'A', 1}, {'E', 1}, {'I', 1}, {'L', 1}, {'N', 1}, {'O', 1}, {'R', 1}, {'S', 1}, {'T', 1}, {'U', 1},
            {'D', 2}, {'G', 2},
            {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
            {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
            {'K', 5},
            {'J', 8}, {'X', 8},
            {'Q', 10}, {'Z', 10},
        };

        Debug.Log($"Game has begun with the word: {gameWord}");
        wordsUsed.Add(gameWord);


    }

  
    //check if the inputted word Can or Cannot be submitted and adjust the point values accordingly.
    public bool submitWord(string word)
    {
        Debug.Log($"attempting to use word: {word}");
        Debug.Log($"Is {word} an anagram?: {isAnagram(word)}");
        
        Debug.Log($"Is {word} in wordsUsed?: {wordsUsed.Contains(word)}");

        if (isAnagram(word) && !wordsUsed.Contains(word)) //later, check if its an actual word in the dictionary
        {
            
            //true -> calculate points earned and increase totalPoints
            int pointsReceived = 0;
            wordsUsed.Add(word);
            foreach (char a in word.ToCharArray())
            {
                pointsReceived += pointValues[a];
            }

            totalPoints += pointsReceived;
            scoreBox.GetComponent<TextMeshProUGUI>().text = $"Score: {totalPoints}";
            Debug.Log($"Points received for word \"{word}\": {pointsReceived} points.");
            Debug.Log($"Total points now: {totalPoints}");

            DisplayAlert(word + "Success", $"+{pointsReceived} for {word}", 1f);
            
            return true;
        }
        else
        {
            //false, output error msg --> need to define specific errors later
            Debug.Log($"\"{word}\" is not a valid word/has already been used.");
            
            DisplayAlert(word + "Fail", $"{word} is invalid.", 2);
            
            return false;
        }
    }

    // check if the word is an anagram of the base word
    private bool isAnagram(string inputWord)
    {
        var inputArray = inputWord.ToCharArray().ToList();
        var baseArray = gameWord.ToCharArray().ToList();
        int matches = 0;

        baseArray.Sort((char a, char b) =>
        {
            return b.CompareTo(a);
        });

        foreach (char character in inputArray)
        {
            if (baseArray.IndexOf(character) >= 0)
            {
                matches++;
                baseArray.Remove(character);
            }
        }
        //sees if the number of character matches is equivalent to all the characters in the inputWord
        return matches == inputWord.Length;
    }



    //Sets the word for this game. Must be called separately so far (can you give the class/script a parameter upon instantiation?)
    public void SetWord(string word)
    {
        gameWord = word;
        Debug.Log($"gameWord has been updated to: \"{word}\".");
    }


    public void DisplayAlert(String name, String text, float duration)
    {
        Vector2 size = new Vector2(Screen.width * 0.8f, Screen.height * 0.1f);
        Vector2 position = new Vector2(0, Screen.height * 0.20f);
        int fontSize = 60;
        GameObject.Find("GUIManager").GetComponent<GUIManager>().GenerateTextBox(position, name, size, fontSize, text);
        GameObject.Find(name).AddComponent<GameAlert>();
        GameObject.Find(name).GetComponent<GameAlert>().thisAlert = GameObject.Find(name);
        GameObject.Find(name).GetComponent<GameAlert>().duration = duration;
    }
}
