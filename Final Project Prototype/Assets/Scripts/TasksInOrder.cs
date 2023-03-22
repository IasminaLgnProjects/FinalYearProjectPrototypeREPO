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

    [SerializeField] GameObject ReadyPanel;

    void Start()
    {
        //Clear the To Do list
        foreach (GameObject task in ListTasks)
        {
            task.SetActive(false);
        }

        ReadyPanel.SetActive(false);
    }

    void Update()
    {

    }

    public void AddTaskToList()
    {
        //
        // 1. Make the task (button) visible
        //

        ListTasks[listCounter].SetActive(true);
        //print("listCounter" + listCounter);

         //
         // 2. Set a number to determine the order of the tasks
         //

        numberOfClickedTasks++;
        ListTasks[listCounter].GetComponent<TaskForList>().counter = numberOfClickedTasks;
        //print("numberOfClickedTasks" + numberOfClickedTasks);

        //
        // 3. Add the text
        //

        GameObject GameObjectClicked = EventSystem.current.currentSelectedGameObject;
        ListTasks[listCounter].GetComponentInChildren<Text>().text = GameObjectClicked.name;
        //print("GameObjectClicked.name)" + GameObjectClicked.name + "=" + "ListTasks[listCounter]" + ListTasks[listCounter]);

        //
        // 4. Increase counter to keep track of how many tasks are currently in the list
        //

        listCounter++;

        if(listCounter == ListTasks.Count)
            ReadyPanel.SetActive(true); 
        else
            ReadyPanel.SetActive(false);

        //
        // 5. Play Sound
        //

        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Write");
    }

    public void DeleteTask()
    {
        //
        // 1. Find which task was clicked
        //

        GameObject GameObjectClicked = EventSystem.current.currentSelectedGameObject;
        clickedTaskCounter = GameObjectClicked.GetComponent<TaskForList>().counter;
        // print(clickedTaskCounter);

        //
        // 2. Make it reappear - search the thought bubble based on the task's text (the tasks in the list) 
        //

        nameOfTask = GameObjectClicked.GetComponentInChildren<Text>().text;
        gameObject.GetComponent<TasksReferences>().Activate(nameOfTask);

        //
        // 3. Delete it and move upwards the other tasks
        //

        for (int i = clickedTaskCounter-1; i < listCounter-1; i++)
        {
            ListTasks[i].GetComponentInChildren<Text>().text = ListTasks[i+1].GetComponentInChildren<Text>().text;
        }
        ListTasks[listCounter - 1].GetComponentInChildren<Text>().text = " ";
        ListTasks[listCounter - 1].SetActive(false);

        //
        // 4. Decrease the number of elemnts in the list and also change the number that stores the order of the task
        //

        listCounter--;
        numberOfClickedTasks--;
        //print(listCounter);

        //
        // 5. Deactivate the Ready panel
        //

        ReadyPanel.SetActive(false);

        //
        // 6. Play Sound
        //

        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Erase");
    }

    public void SaveList()
    {
        for (int k = 0; k < ListTasks.Count; k++)
        {
            print("k =" + k + "ListTasks.Count = " + ListTasks.Count);
            KeepBetweenScenes.ListTaskName[k] = ListTasks[k].GetComponentInChildren<Text>().text;
        }

        if(GameObject.Find("TheGameManager").GetComponent<TABMechanic>().tabOpenedAtLeastOnce)
        {
            GameObject.Find("KeepBetweenScenes").GetComponent<KeepBetweenScenes>().LoadScene();
        }
        else
        {
            print("reminder");
            GameObject.Find("SecondThgTasksManager").GetComponent<SecondThgTasksManager>().ReminderTAB();

            //TEST
            //TABMechanic.index = 4;

        }
    }

}
