using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDialogue : MonoBehaviour //Initial inefficient dialogue mechanic - it was further replaced without this part  
{
    [SerializeField] List<GameObject> ListDialogue = new List<GameObject>();

    void Start()
    {
        foreach (GameObject textLine in ListDialogue)
        {
            textLine.SetActive(false);
        }
    }
}
