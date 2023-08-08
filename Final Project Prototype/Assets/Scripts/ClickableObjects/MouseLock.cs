using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    [SerializeField] GameObject DefaultCursor;
    [SerializeField] GameObject IntCursor;

    void Start()
    {
        LockMouseFunction();
    }

    public void LockMouseFunction()
    {
        Cursor.lockState = CursorLockMode.Locked;
        IntCursor.SetActive(false);
        DefaultCursor.SetActive(true);
    }

    public void UnlockMouseFunction()
    {
        Cursor.lockState = CursorLockMode.None;
        IntCursor.SetActive(false);
        DefaultCursor.SetActive(false);
    }

    public void ChangeCursorFunction()
    {
        //print("changing cursor");
        if(DefaultCursor.activeInHierarchy == true)
        {
            IntCursor.SetActive(true);
            DefaultCursor.SetActive(false);
        }
        else
        {
            DefaultCursor.SetActive(true);
            IntCursor.SetActive(false);
        }
    }

    public void ChangeToDefaultCursor()
    {
        //print("changing to default cursor");
            DefaultCursor.SetActive(true);
            IntCursor.SetActive(false);
    }

    public void ChangeToIntCursor()
    {
        //print("changing to int cursor");
            IntCursor.SetActive(true);
            DefaultCursor.SetActive(false);
    }
}
