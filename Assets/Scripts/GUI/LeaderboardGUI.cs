using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardGUI : MonoBehaviour
{
    [SerializeField] private int LevelID;
    [SerializeField] private GUIManager LeaderboardGUIManager;
    [SerializeField] private GameObject LeaderboardPrefab;
    [SerializeField] private GameObject LBCellPrefab;
    [SerializeField] private string GameWord = "TEMPORARY";
    
    //temporary, will be derived from current player information.
    [SerializeField] private int currentPlayerIndex;
    
    //List of players and their scores will be sorted before being pulled from the backend.
    [SerializeField] private List<tempPlayer> playerList = new List<tempPlayer>
    {
        new tempPlayer{ playerName = "aaaaaaa", highScore = 1400},
        new tempPlayer{ playerName = "bbbbbbb", highScore = 1300},
        new tempPlayer{ playerName = "ccccccc", highScore = 1200},
        new tempPlayer{ playerName = "ddddddd", highScore = 1100},
        new tempPlayer{ playerName = "eeeeeee", highScore = 1000},
        new tempPlayer{ playerName = "fffffff", highScore = 900},
        new tempPlayer{ playerName = "ggggggg", highScore = 800},
        new tempPlayer{ playerName = "hhhhhhh", highScore = 700},
        new tempPlayer{ playerName = "iiiiiii", highScore = 600},
        new tempPlayer{ playerName = "jjjjjjj", highScore = 500},
        new tempPlayer{ playerName = "aaaaaaa", highScore = 400},
        new tempPlayer{ playerName = "bbbbbbb", highScore = 300},
        new tempPlayer{ playerName = "ccccccc", highScore = 200},
        new tempPlayer{ playerName = "ddddddd", highScore = 100},
        new tempPlayer{ playerName = "eeeeeee", highScore = 90},
        new tempPlayer{ playerName = "fffffff", highScore = 80},
        new tempPlayer{ playerName = "ggggggg", highScore = 70},
        new tempPlayer{ playerName = "hhhhhhh", highScore = 60},
        new tempPlayer{ playerName = "iiiiiii", highScore = 50},
        new tempPlayer{ playerName = "jjjjjjj", highScore = 40},
        new tempPlayer{ playerName = "eeeeeee", highScore = 90},
        new tempPlayer{ playerName = "fffffff", highScore = 80},
        new tempPlayer{ playerName = "ggggggg", highScore = 70},
        new tempPlayer{ playerName = "hhhhhhh", highScore = 60},
        new tempPlayer{ playerName = "iiiiiii", highScore = 50},
        new tempPlayer{ playerName = "jjjjjjj", highScore = 40},
    };
    
    // Start is called before the first frame update
    void Start()
    {
        LeaderboardGUIManager.GenerateGUICanvas();
        LeaderboardGUIManager.GenerateSafeArea();
        LeaderboardGUIManager.GenerateBackgroundCanvas();
        LeaderboardGUIManager.GenerateEventSystem();
        
        LeaderboardGUIManager.GenerateBackground(/*Resources.Load<Sprite>("Images/backgroundBlue")*/);
        LeaderboardGUIManager.GenerateTextBox(new Vector2(0f, Screen.height*0.4f), "Title", new Vector2(Screen.width*0.8f, Screen.height*0.08f), 80, "Leaderboard");
        LeaderboardGUIManager.GenerateTextBox(new Vector2(0f, Screen.height*0.35f), name: "GameWord", new Vector2(Screen.width*0.6f, Screen.height*0.8f), 50, "\"" + GameWord + "\"");
        
        //Instantiate leaderboard frame
        Instantiate(LeaderboardPrefab, GameObject.Find("GUICanvas").transform);
        
        //Instantiate cells using PlayerList
        GenerateList();

    }

    void GenerateList()
    {
        //set position and height
        RectTransform contentRect = GameObject.Find("Content").GetComponent<RectTransform>();
        int top = currentPlayerIndex * 70;
        int bottom = (playerList.Count - currentPlayerIndex) * -70;

        contentRect.offsetMax = new Vector2(contentRect.offsetMax.x, top);
        contentRect.offsetMin = new Vector2(contentRect.offsetMin.x, bottom);
        

        for (int i = 0; i < playerList.Count; i++)
        {
            GameObject cell = Instantiate(LBCellPrefab, GameObject.Find("Content").transform);
            cell.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i+1) + "  " + playerList[i].playerName;
            cell.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playerList[i].highScore + "";

            if (i == currentPlayerIndex)
            {
                cell.GetComponent<Image>().color = new Color(1f, 0.55f, 0.2f);
            }
        }
    }

    private class tempPlayer
    {
        public string playerName { get; set; }
        public int highScore { get; set; }
    }
}