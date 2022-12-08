using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header(" Game Details ")]
    [SerializeField] public string gameWord;
    [SerializeField] private int totalPoints;
    [SerializeField] private List<string> wordsUsed;

    [SerializeField]
    private Dictionary<string, int> pointValues;
    private Dictionary<string, int> anagramsList;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeGame();

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeGame()
    {
        totalPoints = 0;
        pointValues = new Dictionary<string, int>()
        {
            {"a", 1}, {"e", 1}, {"i", 1}, {"l", 1}, {"n", 1}, {"o", 1}, {"r", 1}, {"s", 1}, {"t", 1}, {"u", 1},
            {"d", 2}, {"g", 2},
            {"b", 3}, {"c", 3}, {"m", 3}, {"p", 3},
            {"f", 4}, {"h", 4}, {"v", 4}, {"w", 4}, {"y", 4},
            {"k", 5},
            {"j", 8}, {"x", 8},
            {"q", 10}, {"z", 10},
        };
        
        Debug.Log($"Game has begun with the word: {gameWord}");
        
        
    }
    
    public void addWord(TextInput textInput)
    {
        textInput.GetComponent<TextInput>();
    }
    
    //Sets the word for this game. Must be called separately so far (can you give the class/script a parameter upon instantiation?)
   public void SetWord(string word)
    {
        gameWord = word;
        Debug.Log($"gameWord has been updated to: \"{word}\".");
    }

   public void SetAnagramsList(List<string> anagramslist)
   {
       this.anagramsList = anagramsList;
       foreach (string word in anagramslist)
       {
           Debug.Log(word);
       }
   }
}
