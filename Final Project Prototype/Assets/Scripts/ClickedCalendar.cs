using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedCalendar : MonoBehaviour
{
    //Activate panel calendar
    //dialogue
    //Tab panel
    //Play sound
    //call Tab function

    [SerializeField] GameObject CalendarPanel;
    [SerializeField] GameObject MessageIcon;
    [SerializeField] GameObject TABPanel;

    [SerializeField] GameObject DialogueBox;
    [SerializeField] GameObject InstructionsPanel;


    bool tabOpened;



    // Start is called before the first frame update
    void Start()
    {
        TABPanel.SetActive(false);
        CalendarPanel.SetActive(false);
        MessageIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (tabOpened)
                tabOpened = false;
            else
                tabOpened = true;

            if (!tabOpened)
                TABPanel.SetActive(true);
            else
                TABPanel.SetActive(false);

        }
    }

    private void OnMouseDown()
    {
        StartCoroutine("CalendarCoroutine");

    }

    IEnumerator CalendarCoroutine()
    {
        print("clicked");
        InstructionsPanel.SetActive(false);
        CalendarPanel.SetActive(true);

        //Dialogue appears
        DialogueBox.GetComponentInChildren<Text>().text = "Thankfully I made this calendar to help me keep track of the things I have to do";

        //Wait
        yield return new WaitForSeconds(2);

        MessageIcon.SetActive(true);
        
        //sound

        yield return new WaitForSeconds(2);
        yield return null;
    }
}
