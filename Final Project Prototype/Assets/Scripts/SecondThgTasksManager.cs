using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SecondThgTasksManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ListNoninteractiveButtons;
    [SerializeField] GameObject DialogueBox;
    public string DialogueText; //make this private
    List<string> ListDialogueText = new List<string>
    {
        "Which means I have to wish her happy birthday",
        "But the exam is so close... I really need to study",
        "And also work on my assignment! I can't leave everything until last minute"
    };

    public bool triedClicking; //make this private

    [SerializeField] GameObject NotWorkingButtons;
    [SerializeField] GameObject ToDoListPanel;

    [SerializeField] GameObject InstructionsPanel;
    [SerializeField] GameObject AnxietyMeterPanel;

    //The Game Manager reference 
    TheGameManager TGMScript;

    // Start is called before the first frame update
    void Start()
    {
        TGMScript = GameObject.Find("TheGameManager").GetComponent<TheGameManager>();
        DialogueText = DialogueBox.GetComponentInChildren<Text>().text;

        foreach (GameObject thought in ListNoninteractiveButtons)
        {
            thought.SetActive(false);
            thought.GetComponent<Button>().interactable = false;
        }

        NotWorkingButtons.SetActive(false);
        ToDoListPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SecondThgtTasksCoroutine()
    {
        //print("STARTED SECOND");

        //DialogueLine
        //DialogueText = "Oh! Today is Lisa's birthday";
        DialogueBox.GetComponentInChildren<Text>().text = "Oh! Today is Lisa's birthday";


        //Wait
        yield return new WaitForSeconds(2);

        //Activate Panel
        NotWorkingButtons.SetActive(true);

        //Hear racing sounds

        for (int i = 0; i < ListNoninteractiveButtons.Count; i++)
        {
            //Show dialogue line
            ShowText(i);

            //Wait
            yield return new WaitForSeconds(2.5f); //B 2.5

            //ActivateButton
            ShowButton(i);

            //Wait
            yield return new WaitForSeconds(1);

            //IncreaseAnxiety
            IncreaseAnxietyMeter();

            //Wait until repeat
            yield return new WaitForSeconds(2); //B 2
        }

        //Calm down text 

        DialogueBox.GetComponentInChildren<Text>().text = "Calm down... Just don't think too much about it";

        //breathing sounds

        //Activate buttons
        ActivateButtons();

        /*
        if(triedClicking)
        {
            //Wait a bit
            yield return new WaitForSeconds(3); //maybe increase it

            AnxietyMeterPanel.SetActive(false);
            NotWorkingButtons.SetActive(false);
            ToDoListPanel.SetActive(true);

            DialogueText = "I know! I can just add them into a To Do List to be sure I don't forget any";

            InstructionsPanel.SetActive(true);
            InstructionsPanel.GetComponentInChildren<Text>().text = "*Click on a thought to add it in the list. Once in list click to remove it.*";

        }*/

        //Player tries to click
        yield return null;
    }

    void ShowText(int i)
    {
        DialogueBox.GetComponentInChildren<Text>().text = ListDialogueText[i];
    }

    void ShowButton(int i)
    {
        ListNoninteractiveButtons[i].SetActive(true);
    }

    void IncreaseAnxietyMeter()
    {
        TGMScript.GetComponent<AnxietyMeter>().IncreaseAnxiety();
    }

    void ActivateButtons()
    {
        foreach (GameObject thought in ListNoninteractiveButtons)
            thought.GetComponent<Button>().interactable = true;
    }

    public void ActivateDialogueLine()
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;
        if(ListNoninteractiveButtons.Contains(buttonClicked))
        {
            DialogueBox.SetActive(true);
            DialogueBox.GetComponentInChildren<Text>().text = "No! I can't just ignore these thoughts! What if I forget something?!... Something bad can happen... ";
            IncreaseAnxietyMeter();
            //IncreaseAnxietyMeter(); //twice
            //heard racing sounds
            //triedClicking = true;
            Invoke("ToDoList", 7); //maybe increase
        }
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
}
