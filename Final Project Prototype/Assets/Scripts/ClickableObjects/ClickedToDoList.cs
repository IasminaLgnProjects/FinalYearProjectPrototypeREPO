using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedToDoList : MonoBehaviour
{
    [SerializeField] GameObject DialogueBox;
    public string DialogueText; //make this private
    [SerializeField] GameObject NotWorkingButtons;
    [SerializeField] GameObject ToDoListPanel;

    [SerializeField] GameObject InstructionsPanel;
    [SerializeField] GameObject AnxietyMeterPanel;

    // Start is called before the first frame update
    void Start()
    {
        ToDoListPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        ToDoList();
        print("clicked list");
    }

    void ToDoList()
    {
        ToDoListPanel.SetActive(true);

        //hide
        AnxietyMeterPanel.SetActive(false);
        NotWorkingButtons.SetActive(false);

        //sound
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().StopAudio("RapidHeartbeat");

        DialogueBox.GetComponentInChildren<Text>().text = "I know! I can just add them into a To Do List to be sure I don't forget anything.";

        InstructionsPanel.SetActive(true);
        InstructionsPanel.GetComponentInChildren<Text>().text = "*Click on a thought to add it to the list. Once in list, you can click again to remove it and rearrange the tasks in your preferred order*";
    }

    private void OnMouseOver()
    {
        print("over");
    }
}
