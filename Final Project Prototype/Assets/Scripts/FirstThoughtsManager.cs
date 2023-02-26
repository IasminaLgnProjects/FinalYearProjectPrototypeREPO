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
    [SerializeField] GameObject TextWhatDay; //have it on the panel so that when it is activated this activates as well

    //The Game Manager reference 
    TheGameManager TGMScript;

    //Int
    int alreadyReappeared; 
    int nrClicksToReappear = 3;

    void Start()
    {
        TGMScript = GameObject.Find("TheGameManager").GetComponent<TheGameManager>();

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
        InstructionsPanel.SetActive(false);
        //CalmDownText.SetActive(false);
        TextWhatDay.SetActive(false);
        DialogueBox.SetActive(false);

        StartCoroutine("All");
    }

    IEnumerator All()
    {
        yield return new WaitForSeconds(2); //as much as it needs for the player to wake up

        DialogueBox.SetActive(true);
        TextWhatDay.SetActive(true);

        yield return new WaitForSeconds(2);
        TextWhatDay.SetActive(false);

        for (int i = 0; i < ListThoughts.Count; i++)
        {
            //ActivateText
            ShowText(i);

            //Wait
            //yield return new WaitForSeconds(2.5f); //B 2.5

            //ActivateButton
            ShowButton(i);

            //Wait
            yield return new WaitForSeconds(1);

            //IncreaseAnxiety
            IncreaseAnxietyMeter();

            //Wait until repeat
            //yield return new WaitForSeconds(2); //B 2
        }

        //heart racing sounds

        //Wait
        yield return new WaitForSeconds(2); //4 seconds in total at the end

        //CalmDown
        //CalmDownText.SetActive(true);
        ListText[ListText.Count - 1].SetActive(false); //last text hidden
        DialogueBox.GetComponentInChildren<Text>().text = "Shh... Calm down... Firstly just breathe and try to make these thoughts go away";

        //Breathing sounds

        //Wait
        //yield return new WaitForSeconds(4); 

        //Instructions 
        InstructionsPanel.SetActive(true);
        InstructionsPanel.GetComponentInChildren<Text>().text = "*Click on a thought to make it disappear*";

        //Activate buttons
        ActivateButtons();



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

        if (ListInactiveThoughts.Count == 1)
        {
            print("DONE");

            //deactivate all panels
            ThoughtsPanel.SetActive(false);
            //InstructionsPanel.SetActive(false);
            //CalmDownText.SetActive(false);

            DialogueBox.GetComponentInChildren<Text>().text = "Now I can find a solution";

            //unlock camera
            InstructionsPanel.GetComponentInChildren<Text>().text = "*Look around to find a solution for Mary and click on it*";
        }
    }
}
