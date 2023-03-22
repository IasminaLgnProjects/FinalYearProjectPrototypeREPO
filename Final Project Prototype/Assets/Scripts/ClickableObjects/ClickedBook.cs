using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedBook : MonoBehaviour
{
    [SerializeField] GameObject ClockObject;
    [SerializeField] GameObject Book;
    [SerializeField] GameObject BlurBook;
    [SerializeField] GameObject DialogueBox;
    Image BlurImage;
    float fadeSpeed;
    public bool fading; //make private
    TABMechanic ScriptTABMechanic;

    void Start()
    {
        fadeSpeed = 0.2f;
        ClockObject.SetActive(false);
        BlurImage = BlurBook.GetComponentInChildren<Image>();

        //hide panels
        Book.SetActive(false);
        ClockObject.SetActive(false);
        BlurBook.SetActive(false);
        //DialogueBox.SetActive(false);
        DialogueBox.GetComponentInChildren<Text>().text = "I have to start studying now.";

        //Tab
        ScriptTABMechanic = GameObject.Find("StudySceneManager").GetComponent<TABMechanic>();
    }


    void Update()
    {
        if(fading)
        {
            BlurImage.color = new Color(BlurImage.color.r, BlurImage.color.b, BlurImage.color.g, BlurImage.color.a + fadeSpeed * Time.deltaTime); //increase blur
        }
        else
        {
            BlurImage.color = new Color(BlurImage.color.r, BlurImage.color.b, BlurImage.color.g, BlurImage.color.a - fadeSpeed * Time.deltaTime); //decrease blur
            //print("fading out");
        }
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        print("clicked");
        //ClockObject.SetActive(true);
        //Time.timeScale = 0;
        //Invoke("CloseClock", 5);

        StartCoroutine("BookCoroutine");
    }

    void Close()
    {
        ClockObject.SetActive(false);
        GameObject.Find("StudySceneManager").GetComponent<CrossToDoList>().ListAtTheEnd();
    }

    private void OnMouseOver()
    {
        //print("over");
    }

    IEnumerator BookCoroutine()
    {
        //Activate panels
        Book.SetActive(true);
        ClockObject.SetActive(true);
        DialogueBox.SetActive(false);

        //Page sound
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Page");

        //Wait
        yield return new WaitForSeconds(8); //4

        //Initiate blur panel
        BlurBook.SetActive(true);
        BlurImage.color = new Color(BlurImage.color.r, BlurImage.color.b, BlurImage.color.g, 0f);

        //Start blur fade in
        fading = true;
        print("fading in");

        //Wait
        //yield return new WaitForSeconds(10);

        //Slow clock
        //ClockObject.GetComponent<Clock>().rotationDegreesPerDay = 20f;
        ClockObject.GetComponent<Clock>().REAL_SECONDS_PER_INGAME_DAY = 300f;

        //Dialogue
        DialogueBox.SetActive(true);
        DialogueBox.GetComponentInChildren<Text>().text = "Wait... what was my idea?";
        yield return new WaitForSeconds(4);
        DialogueBox.GetComponentInChildren<Text>().text = "I can't even remember what part I was on.";
        yield return new WaitForSeconds(4);
        DialogueBox.GetComponentInChildren<Text>().text = "I can't concentrate at all...";
        yield return new WaitForSeconds(2);

        //blur fade out
        fading = false;
        fadeSpeed = 0.9f;
        //print("fading out");
        yield return new WaitForSeconds(3);

        fading = true;
        print("fading back");

        yield return new WaitForSeconds(4);

        //Message
        ScriptTABMechanic.ShowMessageIcon();
        ScriptTABMechanic.SoundNotification();
        TABMechanic.index = 10;
        //Snap to the last
        ScriptTABMechanic.SnapTo(ScriptTABMechanic.ListMessages[9].GetComponent<RectTransform>());

        yield return new WaitForSeconds(6);
        DialogueBox.GetComponentInChildren<Text>().text = "There is no use... I hope I studied enough for today.";


        yield return new WaitForSeconds(6);
        Close();

        yield return null;
    }
}
