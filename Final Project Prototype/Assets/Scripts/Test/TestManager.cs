using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> Test; //see which one to make Serializefield
    public List<GameObject> buttons;
    public int currentQ = 0;
    public Text textQuestion;

    int correctAnswersClicked;

    //UI
    [SerializeField] GameObject EndPanel;

    void Start()
    {
        EndPanel.SetActive(false);
        WriteQuestion();
    }

    void Update()
    {
        
    }

    void WriteQuestion()
    {
        textQuestion.text = Test[currentQ].question;
        WriteAnswers();

        //Test.RemoveAt(currentQ);
    }

    void WriteAnswers()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].transform.GetComponentInChildren<Text>().text = Test[currentQ].answers[i];
            buttons[i].GetComponent<CorrectAnswer>().isCorrect = false;

            if( i + 1 == Test[currentQ].RightAnswer)
            {
                buttons[i].GetComponent<CorrectAnswer>().isCorrect = true;
            }
        }
    }

    public void CorrectAnswerSelected()
    {
        if (currentQ < Test.Count - 1)
            currentQ++;
        else
            EndTest();

        correctAnswersClicked++;
        WriteQuestion();
    }

    public void WrongAnswerSelected()
    {
        if (currentQ < Test.Count - 1)
            currentQ++;
        else
            EndTest();

        WriteQuestion();
    }

    void EndTest()
    {
        EndPanel.SetActive(true);
        EndPanel.GetComponentInChildren<Text>().text = correctAnswersClicked.ToString() + " / 3"; //change to 5 when adding all 5 
    }

    //maybe void for wrong answer
}
