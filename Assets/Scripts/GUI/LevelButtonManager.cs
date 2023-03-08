using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject currentButton;
    // Start is called before the first frame update
    void Start()
    {
        currentButton.GetComponent<Button>().onClick.AddListener(() => ButtonPressedCallback(int.Parse(currentButton.GetComponent<TextMeshProUGUI>().text))); //Failing to find TextMeshPro component from button
    }

    private void ButtonPressedCallback(int levelNum)
    {
        SceneManager.LoadScene("GameScreen");
        Debug.Log(levelNum);
        GameObject.Find("GameManager").GetComponent<GameManager>().gameWordIndex = levelNum;
    }
}
