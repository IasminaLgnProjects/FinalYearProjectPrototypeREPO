using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCrsForScenes : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public bool useDefault;

    public bool alreadyChanged; //make private

    //MouseLock reference
    MouseLock MouseLockScript;

    //Layer
    public LayerMask clickableLayer;

    public bool unlockedCursor;

    private void Start()
    {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Locked;
        MouseLockScript = GameObject.Find("TheGameManager").GetComponent<MouseLock>();
        useDefault = true;
    }


    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1.5f, clickableLayer))
        {
            //useDefault = false;
            //print(hit.collider.gameObject.name);
            MouseLockScript.ChangeToIntCursor();
        }
        else
        {
            //print("nothing");
            //useDefault = true;


            if(!unlockedCursor)
            {
                MouseLockScript.ChangeToDefaultCursor();
            }
            else
            {
                MouseLockScript.UnlockMouseFunction();
            }
        }






        /*
        SetCursor();

        if (useDefault)
        {
            alreadyChanged = false;
            MouseLockScript.ChangeToDefaultCursor();
            //print("default");
        }
        else if (!useDefault && !alreadyChanged)
        {
            alreadyChanged = true;
            MouseLockScript.ChangeToIntCursor();
            //print("changed");
        }*/
    }


    void SetCursor()
    {
        //Raycast
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1.5f, clickableLayer))
        {
            useDefault = false;
            //print(hit.collider.gameObject.name);
        }
        else
        {
            //print("nothing");
            useDefault = true;
        }

    }

    /*
    private void OnMouseEnter()
    {
        print("enterCalendar");
        MouseLockScript.ChangeCursorFunction();
    }

    private void OnMouseExit()
    {
        print("exit");
        MouseLockScript.ChangeCursorFunction();
    }

    /*
    private void OnMouseOver()
    {
    print("overCalendar");
                MouseLockScript.ChangeCursorFunction();
    }
    */

}
