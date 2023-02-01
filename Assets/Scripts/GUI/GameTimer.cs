using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] public float gameTime;
    [SerializeField] public float timeRemaining;
    private bool timerRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = gameTime;
        
        //don't start the timer until the game is ready.. like to a 3, 2 , 1 countdown and then set timerRunning to true.
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            
            //only update image here cause otherwise we're gonna have a divide by 0 error and we don't want that
        } 
        else if (timerRunning)
        {
            timeRemaining = 0;
            timerRunning = false;
        }
    }
}
