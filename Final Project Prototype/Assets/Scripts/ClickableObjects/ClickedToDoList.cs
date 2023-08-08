using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedToDoList : MonoBehaviour //Only deals with ToDoList UI + cursor unlock
{
    [SerializeField] GameObject DialogueBox;
    public string DialogueText; //make this private
    [SerializeField] GameObject NotWorkingButtons;
    [SerializeField] GameObject ToDoListPanel;

    [SerializeField] GameObject InstructionsPanel;
    [SerializeField] GameObject AnxietyMeterPanel;

    [SerializeField] GameObject CursorDef;
    bool hideCursor;

    void Start()
    {
        ToDoListPanel.SetActive(false);
    }

    void Update()
    {
        if(hideCursor) CursorDef.SetActive(false);
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        ToDoList();
    }

    void ToDoList()
    {
        ToDoListPanel.SetActive(true);

        //UnlockCursor
        GameObject.Find("TheGameManager").GetComponent<MouseLock>().UnlockMouseFunction();
        hideCursor = true;

        //hide
        AnxietyMeterPanel.SetActive(false);
        NotWorkingButtons.SetActive(false);

        //sound
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().StopAudio("RapidHeartbeat");

        //text + instructions
        DialogueBox.GetComponentInChildren<Text>().text = "I know! I can just add them into a To Do List to be sure I don't forget anything.";

        InstructionsPanel.SetActive(true);
        InstructionsPanel.GetComponentInChildren<Text>().text = "*Click on a thought to add it to the list. Once in list, you can click again to remove it and rearrange the tasks in your preferred order*";
    }
}
