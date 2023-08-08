using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedCalendar : MonoBehaviour
{
    [SerializeField] GameObject CalendarPanel;
    [SerializeField] GameObject DialogueBox;
    [SerializeField] GameObject InstructionsPanel;
    [SerializeField] GameObject AnxietyMeterPanel;

    [SerializeField] SecondThgTasksManager STMScript;
    TABMechanic ScriptTABMechanic;

    void Start()
    {
        CalendarPanel.SetActive(false);
        ScriptTABMechanic = GameObject.Find("TheGameManager").GetComponent<TABMechanic>();
    }

    private void OnMouseDown()
    {
        StartCoroutine("CalendarCoroutine");
        gameObject.GetComponent<Collider>().enabled = false;
    }

    IEnumerator CalendarCoroutine()
    {
        //Open Calendar UI
        InstructionsPanel.SetActive(false);
        CalendarPanel.SetActive(true);
        AnxietyMeterPanel.SetActive(false); //hide anxiety meter

        //Dialogue appears
        DialogueBox.GetComponentInChildren<Text>().text = "Thankfully I made this calendar to help me keep track of the things I have to do.";

        yield return new WaitForSeconds(3);

        //Message + snap to message
        GameObject.Find("TheGameManager").GetComponent<TABMechanic>().ShowMessageIcon();
        ScriptTABMechanic.SoundNotification();
        TABMechanic.index = 9;
        ScriptTABMechanic.SnapTo(ScriptTABMechanic.ListMessages[4].GetComponent<RectTransform>());

        yield return new WaitForSeconds(6); 

        //Start the second part
        STMScript.StartCoroutine("SecondThgtTasksCoroutine");
        
        //Show anxiety meter
        AnxietyMeterPanel.SetActive(true);

        yield return null;
    }
}
