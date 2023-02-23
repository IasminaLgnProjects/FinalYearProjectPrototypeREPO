using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TheGameManager : MonoBehaviour
{
    //Panels
    public GameObject ThoughtBubblePanel;
    public GameObject ToDoListPanel;
    public GameObject CalendarPanel;
    public GameObject MessagePanel;

    //
    public TasksInOrder ListReferenceScript;
    string nameOfTask;
    public List<GameObject> ToDoList;
    int sceneCounter;

    // Start is called before the first frame update
    void Start()
    {
        ThoughtBubblePanel.SetActive(false);
        ToDoListPanel.SetActive(false);
        CalendarPanel.SetActive(false);
        MessagePanel.SetActive(false);

        ListReferenceScript = gameObject.GetComponent<TasksInOrder>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("1");
            ThoughtBubblePanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ThoughtBubblePanel.SetActive(false);
            CalendarPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ThoughtBubblePanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ThoughtBubblePanel.SetActive(false);
            CalendarPanel.SetActive(false);
            ToDoListPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ThoughtBubblePanel.SetActive(false);
            CalendarPanel.SetActive(false);
            ToDoListPanel.SetActive(false);
            MessagePanel.SetActive(true);
        }

    }

    public void LoadScene()
    {
        string nameOfTask = ToDoList[sceneCounter].GetComponentInChildren<Text>().text;
        SceneManager.LoadScene(nameOfTask);
        sceneCounter++;
    }
}
