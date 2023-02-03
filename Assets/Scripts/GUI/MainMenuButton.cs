using System.Collections;
using System.Collections.Generic;
/*using UnityEditor.SearchService;*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private Button currentButton;

    // Start is called before the first frame update
    void Start()
    {
        currentButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }
}
