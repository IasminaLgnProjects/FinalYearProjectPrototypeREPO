using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedBook : MonoBehaviour
{
    [SerializeField] GameObject ClockObject;

    void Start()
    {
        ClockObject.SetActive(false);
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        print("clicked");
        ClockObject.SetActive(true);
        //Time.timeScale = 0;
        Invoke("CloseClock", 5);
    }

    void CloseClock()
    {
        ClockObject.SetActive(false);
        GameObject.Find("StudySceneManager").GetComponent<CrossToDoList>().ListAtTheEnd();
    }

    private void OnMouseOver()
    {
        print("over");
    }
}
