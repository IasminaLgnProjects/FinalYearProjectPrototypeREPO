using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TestManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> Test;
    public List<GameObject> buttons;
    public int currentQ = 0;
    public Text textQuestion;

    //UI
    [SerializeField] GameObject CongratsPanel;
    [SerializeField] GameObject TestPanel;
    [SerializeField] GameObject EndPanel;
    [SerializeField] GameObject RefPanel;

    //Score
    int correctAnswersClicked;

    //Message
    [SerializeField] List<string> Results;
    [SerializeField] Text Message;


    void Start()
    {
        //Resolution
        Screen.SetResolution(1920, 1080, true);

        //UI
        EndPanel.SetActive(false);
        TestPanel.SetActive(false);
        RefPanel.SetActive(false);
        WriteQuestion();
    }

    public void StartTest()
    {
        CongratsPanel.SetActive(false);
        TestPanel.SetActive(true);
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
            buttons[i].GetComponent<Image>().color = Color.white;

            if ( i + 1 == Test[currentQ].RightAnswer)
            {
                buttons[i].GetComponent<CorrectAnswer>().isCorrect = true;
            }
        }
    }

    public void CorrectAnswerSelected()
    {
        correctAnswersClicked++;

        if (currentQ < Test.Count - 1)
            currentQ++;
        else
            Invoke("EndTest", 1);

        Invoke("WriteQuestion", 1);
    }

    public void WrongAnswerSelected()
    {
        if (currentQ < Test.Count - 1)
            currentQ++;
        else
            Invoke("EndTest", 1);

        Invoke("WriteQuestion", 1);
    }

    void EndTest()
    {
        EndPanel.SetActive(true);
        EndPanel.GetComponentInChildren<Text>().text = correctAnswersClicked.ToString() + " / " + Test.Count + " right answers";
        
        if(correctAnswersClicked <= Test.Count/2)
            Message.text = Results[0];
        else if (correctAnswersClicked > Test.Count / 2 && correctAnswersClicked < Test.Count)
            Message.text = Results[1];
        else
            Message.text = Results[2];
    }

    public void Retry()
    {
        SceneManager.LoadScene("Test");
    }

    public void Replay()
    {
        SceneManager.LoadScene("FirstPanelScene");
    }

    public void OpenReferences()
    {
        RefPanel.SetActive(true);
    }

    public void CloseReferences()
    {
        RefPanel.SetActive(false);
    }
}
