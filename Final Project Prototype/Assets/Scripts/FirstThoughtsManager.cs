using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstThoughtsManager : MonoBehaviour
{
    //list of thoughts 
    //list of ialogue
    //invoke function that calls 3 functions: 
    // 1. activate button
    // 2. activate coresp dialogue text 
    // 3. increase anxiety

    [SerializeField] List<GameObject> ListThoughts;
    [SerializeField] List<GameObject> ListText;
    [SerializeField] GameObject TextWhatDay; //have it on the panel so that when it is activated this activates as well
    TheGameManager TGMScript;
    [SerializeField] GameObject ClickPanel;
    [SerializeField] GameObject CalmDownText;

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
        ClickPanel.SetActive(false);
        CalmDownText.SetActive(false);

        StartCoroutine("All");
    }

    IEnumerator All()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < ListThoughts.Count; i++)
        {
            //ActivateText
            ShowText(i);

            //Wait
            yield return new WaitForSeconds(2.5f);

            //ActivateButton
            ShowButton(i);

            //Wait
            yield return new WaitForSeconds(1);

            //IncreaseAnxiety
            IncreaseAnxietyMeter();

            //Wait until repeat
            yield return new WaitForSeconds(2);
        }

        //heart racing sounds

        //Wait
        yield return new WaitForSeconds(2); //4 seconds in total at the end

        //CalmDown
        CalmDownText.SetActive(true);
        ListText[ListText.Count - 1].SetActive(false); //last text hidden

        //Breathing sounds

        //Wait
        yield return new WaitForSeconds(4); 

        //Instructions + Activate buttons
        ClickPanel.SetActive(true);
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
}
