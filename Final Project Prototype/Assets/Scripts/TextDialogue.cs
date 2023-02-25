using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDialogue : MonoBehaviour
{
    [SerializeField] List<GameObject> ListDialogue = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject textLine in ListDialogue)
        {
            textLine.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
