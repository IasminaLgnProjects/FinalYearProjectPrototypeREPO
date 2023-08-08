using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TABMechanic : MonoBehaviour
{
    [SerializeField] GameObject MessageIcon;
    [SerializeField] GameObject TABPanel;
    bool tabOpened = true;
    public bool tabOpenedAtLeastOnce;

    //ScrollView
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] RectTransform contentPanel;

    //List
    public List<GameObject> ListMessages;
    public static int index;

    //bool stopLockingMouse;

    void Start()
    {
        TABPanel.SetActive(false);
        MessageIcon.SetActive(false);

        foreach (GameObject message in ListMessages)
            message.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tabOpenedAtLeastOnce = true;
            if (tabOpened)
            {
                TABPanel.SetActive(true);
                Time.timeScale = 0f; //pause game
                tabOpened = false;

                for(int i = 0; i < index; i++)
                {
                    ListMessages[i].SetActive(true);
                    //print(index);
                }

                gameObject.GetComponent<MouseLock>().UnlockMouseFunction();
                //stopLockingMouse = false;
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

    public void ShowMessageIcon()
    {
        MessageIcon.SetActive(true);
    }

    public void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();

        contentPanel.anchoredPosition =
                (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
                - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);
    }

    public void SoundNotification()
    {
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Pop");
        GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Vibrate");
    }
}
