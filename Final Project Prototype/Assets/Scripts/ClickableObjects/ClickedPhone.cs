using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedPhone : MonoBehaviour
{
    [SerializeField] GameObject MessageLisaPanel;

    [SerializeField] GameObject DialogueBox;
    [SerializeField] GameObject AnxietyMeterPanel;
    [SerializeField] GameObject ButtonsPanel;

    [SerializeField] GameObject Message1;
    [SerializeField] GameObject Message2;

    [SerializeField] List<GameObject> Buttons;


    [SerializeField] AnxietyMeter AMScript;
    [SerializeField] CrossToDoList ListReference;

    // Start is called before the first frame update
    void Start()
    {
        //UI diactivate panels
        MessageLisaPanel.SetActive(false);
        AnxietyMeterPanel.SetActive(false);
        ButtonsPanel.SetActive(false);
        Message1.SetActive(false);
        Message2.SetActive(false);
        DialogueBox.SetActive(false); //might want to comment this

        //Reference to the Anxiety Meter
        AMScript = GameObject.Find("TheGameManager").GetComponent<AnxietyMeter>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseOver()
    {
        print("overPhone");
    }

    private void OnMouseDown()
    {
        StartCoroutine("MessageCoroutine");
        gameObject.GetComponent<Collider>().enabled = false;
    }

    IEnumerator MessageCoroutine()
    {
        print("clicked");
        MessageLisaPanel.SetActive(true);
        AnxietyMeterPanel.SetActive(true);

        yield return new WaitForSeconds(2);

        Message1.SetActive(true);

        yield return new WaitForSeconds(2);

        Message2.SetActive(true);

        yield return new WaitForSeconds(4);

        //Dialogue appears
        DialogueBox.SetActive(true);
        DialogueBox.GetComponentInChildren<Text>().text = "Of course she's having a party, she doesn’t get anxious around people and avoids them like I do...";

        yield return new WaitForSeconds(6);

        ButtonsPanel.SetActive(true);
        AnxietyMeterPanel.SetActive(true);

        yield return null;
   
    }

    public void ThirdButtonClicked()
    {
        MakeButtonsNONInteractable();
        StartCoroutine("ThirdButtonCoroutine");
    }

    public void SecondButtonClicked()
    {
        Buttons[0].GetComponent<Button>().interactable = false;
        StartCoroutine("SecondButtonCoroutine");
    }

    void MakeButtonsNONInteractable()
    {
        foreach(GameObject button in Buttons)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }

    /*
    void MakeButtonsInteractable()
    {
        foreach (GameObject button in Buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }
    }*/

    IEnumerator ThirdButtonCoroutine()
    {
        DialogueBox.GetComponentInChildren<Text>().text = "I hate parties but she's my best friend!";
        AMScript.IncreaseAnxiety();

        yield return new WaitForSeconds(4);

        DialogueBox.GetComponentInChildren<Text>().text = "If I don't go she'll be sad...";
        AMScript.IncreaseAnxiety();

        yield return new WaitForSeconds(4);

        DialogueBox.GetComponentInChildren<Text>().text = "Or even worse, she'll start disliking me!";
        AMScript.IncreaseAnxiety();

        yield return new WaitForSeconds(4);

        DialogueBox.GetComponentInChildren<Text>().text = "What if she finds better friends and doesn't want to talk to me anymore?!";
        AMScript.IncreaseAnxiety();

        yield return new WaitForSeconds(4);

        DialogueBox.GetComponentInChildren<Text>().text = "I'll end up being all alone!!";
        AMScript.IncreaseAnxiety();

        yield return new WaitForSeconds(4);

        DialogueBox.GetComponentInChildren<Text>().text = "I guess I have no choice...";
        Buttons[1].GetComponent<Button>().interactable = false;
        Buttons[0].GetComponent<Button>().interactable = true;
        AMScript.ResetAnxietyMeter();

        yield return null;
    }

    IEnumerator SecondButtonCoroutine()
    {
        //Dialogue
        DialogueBox.GetComponentInChildren<Text>().text = "Just thinking about it makes me so anxious but I have to go...";

        yield return new WaitForSeconds(2);

        //Increase Anxiety
        for(int i = 0; i < 4; i++)
            AMScript.IncreaseAnxiety();

        yield return new WaitForSeconds(4);

        //ToDoList
        ListReference.ListAtTheEnd();

        yield return null;
    }
}
