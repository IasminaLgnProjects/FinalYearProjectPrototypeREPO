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
        ToDoList();
        print("clicked list");
    }

    void ToDoList()
    {
        AnxietyMeterPanel.SetActive(false);
        NotWorkingButtons.SetActive(false);
        ToDoListPanel.SetActive(true);

        DialogueBox.GetComponentInChildren<Text>().text = "I know! I can just add them into a To Do List to be sure I don't forget any";

        InstructionsPanel.SetActive(true);
        InstructionsPanel.GetComponentInChildren<Text>().text = "*Click on a thought to add it in the list. Once in list click to remove it.*";
    }

    private void OnMouseOver()
    {
        print("over");
    }
}
