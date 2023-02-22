using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TasksInOrder : MonoBehaviour
{
    [SerializeField] List<GameObject> TasksList;
    [SerializeField] int listCounter;
    [SerializeField] int clickedTaskCounter;
    TaskForList TaskScript;

    void Start()
    {
        //BACK-UP ONLY FOR REMOVING TASKS FROM LIST - WIHOUT MAKING THEM APPEAR AGAIN
    }

    void Update()
    {
        
    }

    void AddTaskToList()
    {
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

        string nameOfTask = EventSystem.current.currentSelectedGameObject.name;
        //print(EventSystem.current.currentSelectedGameObject.name);
        TaskScript = GameObject.Find(nameOfTask).GetComponent<TaskForList>();
        clickedTaskCounter = TaskScript.counter;

        print(clickedTaskCounter);
        //Text hinge = GetComponentInChildren<HingeJoint>();

        for(int i = clickedTaskCounter-1; i < listCounter-1; i++)
        {
            TasksList[i].GetComponentInChildren<Text>().text = TasksList[i+1].GetComponentInChildren<Text>().text;
        }
        TasksList[listCounter-1].GetComponentInChildren<Text>().text = " ";
        TasksList[listCounter - 1].SetActive(false);
        
        listCounter--;
        //print(listCounter);
    }
}
