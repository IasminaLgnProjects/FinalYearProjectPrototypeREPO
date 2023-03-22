using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            //gameObject.GetComponent<Image>().color = Color.green;
            gameObject.GetComponent<Image>().color = new Color(0.1f, 1f, 0.1f, 0.8f);
        }
            
        else
        {
            print("False");
            TMScript.WrongAnswerSelected();
            //gameObject.GetComponent<Image>().color = Color.red;
            gameObject.GetComponent<Image>().color = new Color(1f, 0.1f, 0.1f, 0.8f); //the default red is too much
            
            //maybe call here void for wrong answer
        }
            
        //maybe increase currentQ and call WriteQuestion;
    }
}
