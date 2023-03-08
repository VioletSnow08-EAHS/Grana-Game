using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelButtonGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private GUIManager _manager;
    private int _levels = 150;
    private int _levelsOnPage;
    private int _columnsPerPage = 3;
    private int _rowsPerPage = 5;


    IEnumerator Start()
    {
        yield return null;
        _levelsOnPage = _columnsPerPage * _rowsPerPage;
        _manager.PageHolderInit(_levels / _levelsOnPage);
        GenerateLevels();
    }

    private void GenerateLevels()
    {
        float startY = (Screen.height * .9f) - (Screen.height / _rowsPerPage);
        float startX = (Screen.width / 2) - ((_columnsPerPage - 1) * .75f * _buttonPrefab.GetComponent<RectTransform>().rect.width);
        int levelNum = 1;

        float pageSpacingFactor = 0;

        for (int i = 0; i < _levels / _levelsOnPage; i++) //check
        {
            for (int y = 0; y < _rowsPerPage; y++)
            {
                if (i > 0)
                {
                    startX += Screen.width * i; //Spaces according to page number
                }
                for (int x = 0; x < _columnsPerPage; x++)
                {
                    /*if (i > 0)
                    {
                        startX += Screen.width * i; //Spaces according to page number
                    }*/
                    GameObject levelButton = Instantiate(_buttonPrefab, new Vector3(startX, startY, 0), Quaternion.identity); //create button at startx/y
                    levelButton.transform.SetParent(GameObject.Find("PageHolder").transform);
                    levelButton.GetComponentInChildren<TextMeshProUGUI>().text = levelNum.ToString();
                    startX += _buttonPrefab.GetComponent<RectTransform>().rect.width * 1.5f; //move the button to the right by 1.5 buttons width
                    levelNum++;
                }
                startX = (Screen.width / 2) - ((_columnsPerPage - 1) * .75f * _buttonPrefab.GetComponent<RectTransform>().rect.width); //resets start X to original value
                startY -= _buttonPrefab.GetComponent<RectTransform>().rect.height * 1.5f;
            }
            startY = (Screen.height * .9f) - (Screen.height / _rowsPerPage);

            pageSpacingFactor += 1.5f;
        }
    }
}
