using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
    //UI

    [SerializeField] GameObject StoryPanel;
    [SerializeField] GameObject SupportPanel;
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject NextButton;
    [SerializeField] GameObject DisclaimerPanel;
    [SerializeField] GameObject SecondNextButton;

    // Start is called before the first frame update
    void Start()
    {
        //resolution
        Screen.SetResolution(1920, 1080, true);

        //UI
        SupportPanel.SetActive(false);
        PlayButton.SetActive(false);
        NextButton.SetActive(false);
        StoryPanel.SetActive(false);
        SecondNextButton.SetActive(false);
        //DisclaimerPanel is active
        Invoke("ShowNextButton", 5); //wait 5 seconds then activate the button
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowNextButton()
    {
        NextButton.SetActive(true);
    }

    public void ActivateSupportPanel()
    {
        DisclaimerPanel.SetActive(false);
        NextButton.SetActive(false);
        SupportPanel.SetActive(true);
        Invoke("ShowSecondNextButton", 5);
    }

    void ShowSecondNextButton()
    {
        SecondNextButton.SetActive(true);
    }

    public void ActivateStoryPanel()
    {
        SupportPanel.SetActive(false);
        SecondNextButton.SetActive(false);
        StoryPanel.SetActive(true);
        Invoke("ShowPlayButton", 5);
    }

    void ShowPlayButton()
    {
        PlayButton.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("FirstScene");
    }
}
