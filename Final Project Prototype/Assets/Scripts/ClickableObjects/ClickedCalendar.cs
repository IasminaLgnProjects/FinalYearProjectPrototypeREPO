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

    [SerializeField] GameObject DialogueBox;
    [SerializeField] GameObject InstructionsPanel;
    [SerializeField] GameObject AnxietyMeterPanel;



    [SerializeField] SecondThgTasksManager STMScript;
    TABMechanic ScriptTABMechanic;

    //MouseLock reference
    //MouseLock MouseLockScript;

    // Start is called before the first frame update
    void Start()
    {
        CalendarPanel.SetActive(false);
        ScriptTABMechanic = GameObject.Find("TheGameManager").GetComponent<TABMechanic>();
        //MouseLockScript = GameObject.Find("TheGameManager").GetComponent<MouseLock>();
    }

    // Update is called once per frame


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

    /*
    private void OnMouseOver()
    {
        print("overCalendar");
        MouseLockScript.ChangeCursorFunction();
    }
    */


    /*
    private void OnMouseEnter()
    {
        print("overCalendar");
        MouseLockScript.ChangeCursorFunction();
    }

    private void OnMouseExit()
    {
        MouseLockScript.ChangeCursorFunction();
    }*/

    private void OnMouseDown()
    {
        StartCoroutine("CalendarCoroutine");
        gameObject.GetComponent<Collider>().enabled = false;
    }

    IEnumerator CalendarCoroutine()
    {
        print("clicked");
        //Open Calendar UI
        InstructionsPanel.SetActive(false);
        CalendarPanel.SetActive(true);
        AnxietyMeterPanel.SetActive(false); //hide anxiety meter

        //Mouse
        //GameObject.Find("TheGameManager").GetComponent<MouseLock>().UnlockMouseFunction();

        //Dialogue appears
        DialogueBox.GetComponentInChildren<Text>().text = "Thankfully I made this calendar to help me keep track of the things I have to do.";

        //Wait
        yield return new WaitForSeconds(3);

        //Message
        GameObject.Find("TheGameManager").GetComponent<TABMechanic>().ShowMessageIcon();
        ScriptTABMechanic.SoundNotification();
        TABMechanic.index = 9;

        //Snap to message
        ScriptTABMechanic.SnapTo(ScriptTABMechanic.ListMessages[4].GetComponent<RectTransform>());

        //MessageIcon.SetActive(true); GET REFERENCE TO THE SCRIPT
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
