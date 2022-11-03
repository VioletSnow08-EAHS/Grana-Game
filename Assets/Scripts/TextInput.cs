using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInput : MonoBehaviour
{
    private string textInput;
    public string TextIn
    {
        get { return textInput; }
        set { textInput = value; }
    }

    public void OnTextChange(string value)
    {
        textInput = value;
    }

}
