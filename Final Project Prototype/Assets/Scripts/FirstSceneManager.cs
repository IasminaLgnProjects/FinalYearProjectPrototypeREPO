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

    // Start is called before the first frame update
    void Start()
    {
        SupportPanel.SetActive(false);
        PlayButton.SetActive(false);
        NextButton.SetActive(false);
        Invoke("ShowNextButton", 5);
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
        NextButton.SetActive(false);
        SupportPanel.SetActive(true);
        Invoke("ShowPlayButton", 5);
    }

    void ShowPlayButton()
    {
        PlayButton.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Demo Scene");
    }
}
