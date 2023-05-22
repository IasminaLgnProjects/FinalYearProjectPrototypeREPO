using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMouseLock : MonoBehaviour
{
    [SerializeField] GameObject DefaultCursor;
    [SerializeField] GameObject IntCursor;
    // Start is called before the first frame update
    void Start()
    {
        IntCursor.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

}
