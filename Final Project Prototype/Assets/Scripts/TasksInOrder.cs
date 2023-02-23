using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TasksInOrder : MonoBehaviour
{
    [SerializeField] List<GameObject> ListTasks;
    [SerializeField] int listCounter;
    [SerializeField] int clickedTaskCounter;
    [SerializeField] int numberOfClickedTasks;
    TaskForList TaskScript;
    string nameOfTask;

    [SerializeField] GameObject TheGameManager;

    void Start()
    {
        //listCounter = 4;
        foreach (GameObject task in ListTasks)
        {
            task.SetActive(false);
        }
        //listCounter = 0;

        TheGameManager = GameObject.Find("TheGameManager");
    }

    void Update()
    {
        //print(listCounter);
    }

    public void AddTaskToList()
    {
        //make button visible
        ListTasks[listCounter].SetActive(true);
        print("listCounter" + listCounter);

        //set the number to determine the order of the task
        numberOfClickedTasks++;
        ListTasks[listCounter].GetComponent<TaskForList>().counter = numberOfClickedTasks;
        print("numberOfClickedTasks" + numberOfClickedTasks);

        //Add the text
        GameObject GameObjectClicked = EventSystem.current.currentSelectedGameObject;
        print("GameObjectClicked.name)" + GameObjectClicked.name + "=" + "ListTasks[listCounter]" + ListTasks[listCounter]);
        //print();
        ListTasks[listCounter].GetComponentInChildren<Text>().text = GameObjectClicked.name;

        //increase counter to keep track of how many tasks are currently in the list
        listCounter++;


        //list of type BUTTONS 
        //if the name of the button is X then add X as the first element
        //elemn1.Find component text = " X ";

        //after that if the list button is pressed reactivate the initial button

        // X not good X end (if list.count == 5) - are you happy with your task order - Yes = close to do list - No = go back (close the 
        //  end (
        //- Yes = turns off the buttons(maybe)
    }

    public void DeleteTask()
    {
        //Find which task was clicked

        /* LONG WAY
        string nameOfGameObjectClicked = EventSystem.current.currentSelectedGameObject.name;
        //print(EventSystem.current.currentSelectedGameObject.name);
        TaskScript = GameObject.Find(nameOfGameObjectClicked).GetComponent<TaskForList>();
        clickedTaskCounter = TaskScript.counter;
        */ 

        // SHORTEST WAY
        //clickedTaskCounter = EventSystem.current.currentSelectedGameObject.GetComponent<TaskForList>().counter;

        GameObject GameObjectClicked = EventSystem.current.currentSelectedGameObject;
        clickedTaskCounter = GameObjectClicked.GetComponent<TaskForList>().counter;
        // print(clickedTaskCounter);


        //Make it reappear - search the thought bubble based on the list's task's text 
        
        nameOfTask = GameObjectClicked.GetComponentInChildren<Text>().text;
        /*
        print(nameOfTask);
        GameObject.Find(nameOfTask).SetActive(true);*/

        TheGameManager.GetComponent<TasksReferences>().Activate(nameOfTask);

        //Delete it and move upwards the other tasks

        for (int i = clickedTaskCounter-1; i < listCounter-1; i++)
        {
            ListTasks[i].GetComponentInChildren<Text>().text = ListTasks[i+1].GetComponentInChildren<Text>().text;
        }
        ListTasks[listCounter-1].GetComponentInChildren<Text>().text = " ";
        ListTasks[listCounter - 1].SetActive(false);
        
        listCounter--;
        numberOfClickedTasks--;
        //print(listCounter);
    }
}
