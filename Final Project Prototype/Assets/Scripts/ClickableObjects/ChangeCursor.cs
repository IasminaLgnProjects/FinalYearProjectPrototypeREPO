using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour //Previous method - only worked well for the calendar and notebook
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public bool useDefault;

    bool alreadyChanged;

    //MouseLock reference
    MouseLock MouseLockScript;

    private void Start()
    {
        MouseLockScript = GameObject.Find("TheGameManager").GetComponent<MouseLock>();
    }

    private void OnMouseEnter()
    {
        //print("enterCalendar");
        MouseLockScript.ChangeCursorFunction();
    }

    private void OnMouseExit()
    {
        //print("exit");
        MouseLockScript.ChangeCursorFunction();
    }
}
