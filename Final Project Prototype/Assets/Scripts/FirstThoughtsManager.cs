using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FirstThoughtsManager : MonoBehaviour
{
    //Make then private and turn them back to 2.5 and 2

    //Lists
    [SerializeField] List<GameObject> ListThoughts;
    [SerializeField] List<GameObject> ListInactiveThoughts;
    [SerializeField] List<GameObject> ListText;

    //UI Panels
    [SerializeField] GameObject ThoughtsPanel;
    [SerializeField] GameObject InstructionsPanel;
    //[SerializeField] GameObject CalmDownText;

    //UI Text
    [SerializeField] GameObject DialogueBox;
    //[SerializeField] GameObject TextWhatDay; //have it on the panel so that when it is activated this activates as well

    //The Game Manager reference 
    TheGameManager TGMScript;
    [SerializeField] FirstPersonCamera CameraScript;
    [SerializeField] GameObject Calendar;
    TABMechanic ScriptTABMechanic;

    //Int
    int alreadyReappeared; 
    int nrClicksToReappear = 3;

    //animator
    [SerializeField] Animator anim;

    void Start()
    {
        TGMScript = GameObject.Find("TheGameManager").GetComponent<TheGameManager>();
        ScriptTABMechanic = GameObject.Find("TheGameManager").GetComponent<TABMechanic>();

        //hide all text
        foreach (GameObject text in ListText)
            text.SetActive(false);

        //hide + dis all buttons
        foreach (GameObject thought in ListThoughts)
        {
            thought.SetActive(false);
            thought.GetComponent<Button>().interactable = false;
        }

        //hide all panels
        
        //CalmDownText.SetActive(false);
        //TextWhatDay.SetActive(false);


        InstructionsPanel.SetActive(false);
        DialogueBox.SetActive(false);

        Calendar.GetComponent<Collider>().enabled = false;

        StartCoroutine("All");
    }

    IEnumerator All()
    {
        
        yield return new WaitForSeconds(3);

        //dialogue
        DialogueBox.SetActive(true);
        DialogueBox.GetComponentInChildren<Text>().text = "I can’t believe it’s been 9 months since I started my final year of uni and my part-time job… when my anxiety became so much worse...";
        
        yield return new WaitForSeconds(6);
        DialogueBox.GetComponentInChildren<Text>().text = "But I believe I have improved a lot in those 3 months of therapy with Ms Evans.";

        yield return new WaitForSeconds(5);

        //Message
        ScriptTABMechanic.ShowMessageIcon();
        ScriptTABMechanic.SoundNotification();
        TABMechanic.index = 4;

        DialogueBox.GetComponentInChildren<Text>().text = "Oh, she just sent me a message! I should check it.";

        //Animation
        yield return new WaitForSeconds(5);
        anim.SetBool("GetUp", true);
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("GetUp"); 

        //Wait for animation
        yield return new WaitForSeconds(10); //as much as it needs for the player to wake up

        //Lock Camera
        //CameraScript.mouseSens = 0f;

        //Show dialogue box

        //TextWhatDay.SetActive(true);
        DialogueBox.GetComponentInChildren<Text>().text = "What day is it today?";

        yield return new WaitForSeconds(2);
        DialogueBox.GetComponentInChildren<Text>().text = " ";
        //TextWhatDay.SetActive(false);

        //Heartbeat sound
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Heartbeat30");

        //Thoughts
        for (int i = 0; i < ListThoughts.Count; i++)
        {
            //ActivateText
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

        //heart racing sounds

        //Wait
        yield return new WaitForSeconds(2); //4 seconds in total at the end

        //CalmDown
        //CalmDownText.SetActive(true);
        ListText[ListText.Count - 1].SetActive(false); //last text hidden
        DialogueBox.GetComponentInChildren<Text>().text = "Shh... Calm down... Firstly just breathe and try to make these thoughts go away.";

        //Lock Camera
        CameraScript.mouseSens = 0f;

        //Breathing sounds
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Breathing");

        //Wait
        yield return new WaitForSeconds(4); 

        //Instructions 
        InstructionsPanel.SetActive(true);
        InstructionsPanel.GetComponentInChildren<Text>().text = "*Click on a thought to make it disappear*";

        //Activate buttons
        ActivateButtons();

        //Message
        ScriptTABMechanic.ShowMessageIcon();
        ScriptTABMechanic.SoundNotification();
        TABMechanic.index = 6;

        //Snap to the 4th message
        ScriptTABMechanic.SnapTo(ScriptTABMechanic.ListMessages[2].GetComponent<RectTransform>());

        yield return null;
    }

    void Update()
    {

    }  

    void ShowText(int i)
    {
        ListText[i].SetActive(true);

        if(i > 0)
        {
            ListText[i-1].SetActive(false);
        }
    }

    void ShowButton(int i)
    {
        ListThoughts[i].SetActive(true);
    }

    void IncreaseAnxietyMeter()
    {
        TGMScript.GetComponent<AnxietyMeter>().IncreaseAnxiety();
    }

    void ActivateButtons()
    {
        foreach (GameObject thought in ListThoughts)
            thought.GetComponent<Button>().interactable = true;
    }

    public void ReactivateRandom()
    {
        //Add clicked buttons into a "Inactive" list
        if (!ListInactiveThoughts.Contains(EventSystem.current.currentSelectedGameObject)) //if it's not already in list
        {
            ListInactiveThoughts.Add(EventSystem.current.currentSelectedGameObject); //add to list
        }


        if (ListInactiveThoughts.Count == nrClicksToReappear && alreadyReappeared < 3) //for example make one appear after I clicked on 3 buttons already and repeat it only 3 times 
        {
            //Select randomly a button to reappear
            int random = Random.Range(0, ListInactiveThoughts.Count-1); //The max number is EXCLUSIVE if it uses INT + // -1 because you don't want the button you just clicked on to reappear
            print("random is " + random);
            ListInactiveThoughts[random].SetActive(true); 
            ListInactiveThoughts.Remove(ListInactiveThoughts[random]);

            IncreaseAnxietyMeter(); //it will stay the same since 1 button is clicked but another one appears

            alreadyReappeared++;  //the buttons appear only 3 times
            nrClicksToReappear++; //First appear after 3 buttons clicked, then after 4, then after all 5 
        }

        if (ListInactiveThoughts.Count == 5)
        {
            print("DONE");

            //Stop sound
            GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().StopAudio("Breathing");

            //deactivate all panels
            ThoughtsPanel.SetActive(false);
            //InstructionsPanel.SetActive(false);
            //CalmDownText.SetActive(false);

            DialogueBox.GetComponentInChildren<Text>().text = "Now I can find a solution.";

            //unlock camera
            InstructionsPanel.GetComponentInChildren<Text>().text = "*Look around to find a solution for Mary and click on it*";

            //Unlock camera
            CameraScript.mouseSens = 2.5f;

            Calendar.GetComponent<Collider>().enabled = true;
        }
    }
}
