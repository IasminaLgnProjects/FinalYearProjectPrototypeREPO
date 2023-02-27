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
    [SerializeField] GameObject AnxietyMeterPanel;

    bool tabOpened;

    [SerializeField] SecondThgTasksManager STMScript;

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
            //might want to put all into a single if
            //OLD ONES
            
            /*
            if (tabOpened)
                tabOpened = false;
            else
                tabOpened = true;
            */

            //OpenTabPanel();
            //PauseGame();


            if (tabOpened)
            {
                
                TABPanel.SetActive(true);
                Time.timeScale = 0f; //pause game
                print("freeze");
                tabOpened = false;
            }
            else
            {
                
                TABPanel.SetActive(false);
                MessageIcon.SetActive(false);
                Time.timeScale = 1f;
                tabOpened = true;
            }
        }
    }

    /*
    void OpenTabPanel()
    {
         if (tabOpened)
            TABPanel.SetActive(true);
         else
            TABPanel.SetActive(false);
    }

    void PauseGame()
    {
        if(tabOpened)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }*/

    private void OnMouseDown()
    {
        StartCoroutine("CalendarCoroutine");
        gameObject.GetComponent<Collider>().enabled = false;
    }

    IEnumerator CalendarCoroutine()
    {
        print("clicked");
        InstructionsPanel.SetActive(false);
        CalendarPanel.SetActive(true);
        AnxietyMeterPanel.SetActive(false); //hide anxiety meter

        //Dialogue appears
        DialogueBox.GetComponentInChildren<Text>().text = "Thankfully I made this calendar to help me keep track of the things I have to do";

        //Wait
        yield return new WaitForSeconds(3);

        MessageIcon.SetActive(true);
        //In case the player will press tab beforehand (unlikely to happen) you can add a bool here that becomes true in this stage and above in Update you check if Tab was pressed -> if bool is true

        //sound

        //Wait
        yield return new WaitForSeconds(6); 

        //Start the second part
        //STMScript.GetComponent<SecondThgTasksManager>().StartCoroutine("SecondThgtTasksCoroutine"); DELETE
        STMScript.StartCoroutine("SecondThgtTasksCoroutine");
        
        //Show anxiety meter
        AnxietyMeterPanel.SetActive(true);

        yield return null;
        //first test
    }
}
