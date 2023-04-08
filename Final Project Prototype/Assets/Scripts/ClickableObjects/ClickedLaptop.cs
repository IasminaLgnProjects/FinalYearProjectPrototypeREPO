using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedLaptop : MonoBehaviour
{
    [SerializeField] GameObject ClockObject;
    [SerializeField] GameObject DialogueBox;

    void Start()
    {
        ClockObject.SetActive(false);
        DialogueBox.GetComponentInChildren<Text>().text = "I have to work on my assignment now.";
    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        print("clicked");
        //ClockObject.SetActive(true);
        //Time.timeScale = 0;
        //Invoke("CloseClock", 5);
        StartCoroutine("AssignmentCoroutine");
    }

    void Close()
    {
        ClockObject.SetActive(false);
        GameObject.Find("StudySceneManager").GetComponent<CrossToDoList>().ListAtTheEnd();
    }

    private void OnMouseOver()
    {
        print("over");
    }

    IEnumerator AssignmentCoroutine()
    {
        //show clock animation
        ClockObject.SetActive(true);
        ClockObject.GetComponent<Clock>().REAL_SECONDS_PER_INGAME_DAY = 240f; //slow down the normal clock
        DialogueBox.SetActive(false);

        //Typing sound
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Typing");

        yield return new WaitForSeconds(5);
        DialogueBox.SetActive(true);

        //Yawn sound
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Yawn");
        DialogueBox.GetComponentInChildren<Text>().text = "I feel so tired and I barely did anything... These racing thoughts are really exhausting.";

        yield return new WaitForSeconds(8);

        DialogueBox.GetComponentInChildren<Text>().text = "Sometimes these thoughts won't go away no matter what I do...";
        yield return new WaitForSeconds(6);
        DialogueBox.GetComponentInChildren<Text>().text = "Even when I know the cause.";
        yield return new WaitForSeconds(4);
        DialogueBox.GetComponentInChildren<Text>().text = "Or I'm actively working on it.";
        yield return new WaitForSeconds(4);
        DialogueBox.GetComponentInChildren<Text>().text = "Not even after I've already done it...";
        yield return new WaitForSeconds(6);
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Yawn");

        //Stop Sound
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().StopAudio("Typing");

        DialogueBox.GetComponentInChildren<Text>().text = "I guess I am done working on my assignment for today.";
        yield return new WaitForSeconds(5);

        //To Do List
        Close();


        yield return null;
    }
}