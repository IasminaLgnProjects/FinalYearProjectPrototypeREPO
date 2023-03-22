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


    private void Update()
    {
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

    /*
    private void OnMouseEnter()
    {
        useDefault = false;
    }

    private void OnMouseExit()
    {
        useDefault = true;
    }

    private void OnMouseOver()
    {
        useDefault = false;
    }
    */
}
