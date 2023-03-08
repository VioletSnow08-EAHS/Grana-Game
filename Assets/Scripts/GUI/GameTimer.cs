using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] public float gameTime;
    [SerializeField] public GameObject timer;
    [SerializeField] public float duration;
    public bool isPaused = false;
    private Color endColor = Color.red;
    
    // Start is called before the first frame update
    void Start()
    {
        timer.GetComponent<Image>().color = Color.green;
        duration = gameTime;
        StartCoroutine(UpdateColorCR());
    }

    public IEnumerator UpdateColorCR()
    {
        Color startColor = timer.GetComponent<Image>().color;
        float duration = gameTime;
        
        while (gameTime > 0 && !isPaused)
        {
            gameTime -= Time.deltaTime;
            
            //update color
            timer.GetComponent<Image>().color = Color.Lerp(endColor, startColor, gameTime / duration);
            //update size
            float width = gameTime / this.duration * Screen.width;
            timer.GetComponent<RectTransform>().sizeDelta = new Vector2(width, Screen.height * 0.02f);
            yield return null;
        }
        
    }
    
    
    

}