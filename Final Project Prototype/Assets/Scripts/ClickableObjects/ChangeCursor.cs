using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
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
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Locked;
        MouseLockScript = GameObject.Find("TheGameManager").GetComponent<MouseLock>();
    }

    /*
    private void Update()
    {

        //print(Cursor.visible);
        SetCursor();

        if (useDefault)
        {
            alreadyChanged = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            

        }
            
        if(!useDefault && !alreadyChanged)
        {
            //Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
            alreadyChanged = true;
            Cursor.SetCursor(cursorTexture, new Vector2(160, 160), cursorMode);
            
            print("changed");
        }    
    }

    
    void SetCursor()
    {
        //Raycast
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1.5f))
        {
            //print(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Clickable")
                useDefault = false;
            else
                useDefault = true;
        }
    }

    */
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
