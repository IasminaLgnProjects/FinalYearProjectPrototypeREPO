using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectAnswer : MonoBehaviour
{
    public bool isCorrect;
    TestManager TMScript;

    void Start()
    {
        TMScript = GameObject.Find("TestManager").GetComponent<TestManager>();
    }

    public void AnswerClicked()
    {
        if (isCorrect)
        {
            print("Correct");
            TMScript.CorrectAnswerSelected();
            gameObject.GetComponent<Image>().color = new Color(0.1f, 1f, 0.1f, 0.8f);
        }
            
        else
        {
            print("False");
            TMScript.WrongAnswerSelected();
            gameObject.GetComponent<Image>().color = new Color(1f, 0.1f, 0.1f, 0.8f); //the default red is too much
        }
    }
}
