using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    [SerializeField] GameObject DefaultCursor;
    [SerializeField] GameObject IntCursor;
    // Start is called before the first frame update
    void Start()
    {
        LockMouseFunction();
        //IntCursor.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnMouseOver()
    {
        print("over");
        IntCursor.SetActive(true);
        DefaultCursor.SetActive(false);
    }

    private void OnMouseExit()
    {
        IntCursor.SetActive(false);
        DefaultCursor.SetActive(true);
    }
    */

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
        print("changing cursor");
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
        print("changing to default cursor");
            DefaultCursor.SetActive(true);
            IntCursor.SetActive(false);
    }

    public void ChangeToIntCursor()
    {
        print("changing to int cursor");
            IntCursor.SetActive(true);
            DefaultCursor.SetActive(false);
    }
}
