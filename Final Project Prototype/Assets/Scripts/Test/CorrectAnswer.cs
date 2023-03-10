using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public bool isCorrect;
    TestManager TMScript;
    // Start is called before the first frame update
    void Start()
    {
        TMScript = GameObject.Find("TestManager").GetComponent<TestManager>();
    }

    // Update is called once per frame
    public void AnswerClicked()
    {
        if (isCorrect)
        {
            print("Correct");
            TMScript.CorrectAnswerSelected();
        }
            
        else
        {
            print("False");
            TMScript.WrongAnswerSelected();
            //maybe call here void for wrong answer
            //maybe change colour
        }
            
        //maybe increase currentQ and call WriteQuestion;
    }
}
