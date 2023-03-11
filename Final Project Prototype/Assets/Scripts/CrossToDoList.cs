using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossToDoList : MonoBehaviour
{
    [SerializeField] GameObject ToDoListPanel;
    [SerializeField] List<Text> TasksInList;
    [SerializeField] List<Image> CrossLines;
    // Start is called before the first frame update
    void Start()
    {
        ToDoListPanel.SetActive(false);
        for (int i = 0; i < TasksInList.Count; i++)
        {
            TasksInList[i].text = KeepBetweenScenes.ListTaskName[i];
        }

        /* YOU DON'T NEED LIST IN THE BEGINNING
        //List in the beginning
        if(KeepBetweenScenes.sceneCounter > 1) //after the first task
        {
            for(int finished = 0; finished < KeepBetweenScenes.sceneCounter; finished++)
            {
                CrossLines[finished].enabled = true;
            }

            for (int unfinished = KeepBetweenScenes.sceneCounter; unfinished < CrossLines.Count; unfinished++)
            {
                CrossLines[unfinished].enabled = false;
            }
        }
        else
        {
            foreach (Image line in CrossLines)
                line.enabled = false;
        }*/

        foreach (Image line in CrossLines)
            line.enabled = false;

    }

    public void CloseList()
    {
        ToDoListPanel.SetActive(false);
    }

    public void ListAtTheEnd() //this will be called upon the task completion condition
    {
        ToDoListPanel.SetActive(true);
        for (int finished = 0; finished < KeepBetweenScenes.sceneCounter; finished++)
        {
            CrossLines[finished].enabled = true;
        }
        //CrossLines[KeepBetweenScenes.sceneCounter - 1].enabled = true; //cross the task just completed
    }
}
