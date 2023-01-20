using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst.Intrinsics;
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
            {'a', 1}, {'e', 1}, {'i', 1}, {'l', 1}, {'n', 1}, {'o', 1}, {'r', 1}, {'s', 1}, {'t', 1}, {'u', 1},
            {'d', 2}, {'g', 2},
            {'b', 3}, {'c', 3}, {'m', 3}, {'p', 3},
            {'f', 4}, {'h', 4}, {'v', 4}, {'w', 4}, {'y', 4},
            {'k', 5},
            {'j', 8}, {'x', 8},
            {'q', 10}, {'z', 10},
        };

        Debug.Log($"Game has begun with the word: {gameWord}");


    }

    public void DisplayGameWord()
    {

    }
    //check if the inputted word Can or Cannot be submitted and adjust the point values accordingly.
    public bool submitWord(string word)
    {
        Debug.Log($"attempting to use word: {word}");
        Debug.Log($"Is {word} an anagram?: {isAnagram(word)}");

        if (isAnagram(word) && !wordsUsed.Contains(word)) //later, check if its an actual word in the dictionary
        {
            word = word.ToLower();
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
            return true;
        }
        else
        {
            //false, output error msg --> need to define specific errors later
            Debug.Log($"\"{word}\" is not a valid word/has already been used.");
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

    //load in the anagrams for the current word
    public void SetAnagramsList(List<string> anagrams)
    {
        this.anagramsList = anagrams;
        foreach (string word in anagrams)
        {
            Debug.Log($"added \"{word}\"");
        }
    }
}
