using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksReferences : MonoBehaviour
{
    //This class is used to keep a reference of all tasks to avoid the excessive use of the function .Find()
    //Also because .Find() cannot find inactive objects 

    [SerializeField] List<GameObject> ListTasksReferences;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Activate(string s)
    {
        foreach (GameObject task in ListTasksReferences)
        {
            if(task.name == s)
            {
                print("match");
                task.SetActive(true);
            }
        }
    }
}
