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
        "Which means I have to wish her happy birthday. I can't wait any longer or she'll think I forgot!",
        "The exam is so close... I really need to study, I have been procrastinating too much!",
        "Oh no I also have to work on my assignment! I can't leave everything until last minute again..."
    };

    public bool triedClicking; //make this private

    [SerializeField] GameObject NotWorkingButtons;

    [SerializeField] GameObject InstructionsPanel;
    [SerializeField] GameObject AnxietyMeterPanel;
    [SerializeField] GameObject CalendarPanel;

    //The Game Manager reference 
    GameObject TGMObject;

    //ToDoList callind the coroutine
    [SerializeField] Collider notepadCollider;

    MouseLock MouseLockScript;

    void Start()
    {
        notepadCollider.enabled = false;
        TGMObject = GameObject.Find("TheGameManager");
        DialogueText = DialogueBox.GetComponentInChildren<Text>().text;
        MouseLockScript = GameObject.Find("TheGameManager").GetComponent<MouseLock>();

        foreach (GameObject thought in ListNoninteractiveButtons)
        {
            thought.SetActive(false);
            thought.GetComponent<Button>().interactable = false;
        }

        NotWorkingButtons.SetActive(false);
    }

    IEnumerator SecondThgtTasksCoroutine()
    {
        DialogueBox.GetComponentInChildren<Text>().text = "Oh! Today is Lisa's birthday.";

        //Mouse
        MouseLockScript.UnlockMouseFunction();

        yield return new WaitForSeconds(2);

        //Show thought bubbles
        NotWorkingButtons.SetActive(true);

        //Sound
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Heartbeat20");

        for (int i = 0; i < ListNoninteractiveButtons.Count; i++)
        {
            ShowText(i);

            yield return new WaitForSeconds(2.5f);

            ShowButton(i);

            yield return new WaitForSeconds(1);

            IncreaseAnxietyMeter();

            yield return new WaitForSeconds(2); //Wait until repeat loop
        }

        DialogueBox.GetComponentInChildren<Text>().text = "Calm down... Just don't think too much about it.";

        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Breathing");
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().StopAudio("Heartbeat20");

        ActivateButtons();

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
        TGMObject.GetComponent<AnxietyMeter>().IncreaseAnxiety();
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
            DialogueBox.GetComponentInChildren<Text>().text = "No! I can't just ignore these thoughts! What if I forget something?!... Something bad can happen... I need to find a different solution.";
            IncreaseAnxietyMeter();

            //Sound
            GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().StopAudio("Breathing");
            GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("RapidHeartbeat");

            Invoke("LookForToDoList", 6);
        }
    }

    void LookForToDoList()
    {
        //UI
        CalendarPanel.SetActive(false);
        NotWorkingButtons.SetActive(false);
        AnxietyMeterPanel.SetActive(false);

        //Collider
        notepadCollider.enabled = true;

        //Instructions
        InstructionsPanel.SetActive(true);
        InstructionsPanel.GetComponentInChildren<Text>().text = "*Look around to find a solution and click on it*";
        DialogueBox.GetComponentInChildren<Text>().text = "Remember what you've learned during the cognitive behavioural therapy... or how I like to call it “Can Be Treated”.";

        //Lock mouse
        MouseLockScript.LockMouseFunction();
    }

    public void ReminderTAB()
    {
        DialogueBox.GetComponentInChildren<Text>().text = "I should really check my therapist's messages first.";
    }
}
