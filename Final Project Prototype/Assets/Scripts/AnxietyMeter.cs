using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyMeter : MonoBehaviour
{
    //GameObject[] AMparts;
    [SerializeField] List<GameObject> AMparts = new List<GameObject>();
    int listSize;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in AMparts)
        {
            listSize++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseAnxiety()
    {
        //AMparts[AMparts.Count-1].SetActive(false); cannot use Count since you are not destroying the object
        AMparts[listSize - 1].SetActive(false);
        listSize--;
    }
}
