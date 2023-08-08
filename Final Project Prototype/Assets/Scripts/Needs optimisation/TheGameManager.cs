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


    public TasksInOrder ListReferenceScript;
    public List<GameObject> ToDoList;


    void Start()
    {
        ThoughtBubblePanel.SetActive(false);
        ToDoListPanel.SetActive(false);
        CalendarPanel.SetActive(false);
        MessagePanel.SetActive(false);

        ListReferenceScript = gameObject.GetComponent<TasksInOrder>();
    }


    void Update()
    {
        /* DEBUG
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
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
        */
    }
}
