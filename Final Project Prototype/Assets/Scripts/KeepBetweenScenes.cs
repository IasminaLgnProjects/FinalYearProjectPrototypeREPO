using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepBetweenScenes : MonoBehaviour
{
    public static int check;
    public static int sceneCounter; //to now which one to cross from list
    public static List<string> ListTaskName = new List<string>() { "", "", "" }; //you need to initialise the list since the first part only creates a field to keep a list in
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //print("sceneCounter " + sceneCounter);
        //for(int i = 0; i < ListTaskName.Count; i++)
        //    print("task " + i + " name " + ListTaskName[i]);
    }

    public void LoadScene() //There will be no button so you load the TEST scene on task completion
    {
        if(sceneCounter == ListTaskName.Count)
            SceneManager.LoadScene("Test");
        else
        {
            string nameOfTask = ListTaskName[sceneCounter]; //the name of the Thought Bubble should be the name of the Scene Loaded
            SceneManager.LoadScene(nameOfTask);
            sceneCounter++;
        }
    }
}
