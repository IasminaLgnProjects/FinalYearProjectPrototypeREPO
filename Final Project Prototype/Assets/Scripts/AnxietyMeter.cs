using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyMeter : MonoBehaviour
{
    [SerializeField] List<GameObject> AMparts = new List<GameObject>();
    int listIndex;

    void Start()
    {
        foreach (GameObject part in AMparts)
            part.SetActive(false);
    }

    public void DecreaseAnxiety()
    {

        if(listIndex > 0)
        {
            listIndex--; //You decrease the index first because it went +1 too much when Increasing the anxiety
            //AMparts[AMparts.Count-1].SetActive(false); cannot use Count since you are not destroying the object
            AMparts[listIndex].SetActive(false);
            
        }
    }

    public void IncreaseAnxiety()
    {
        if(listIndex < AMparts.Count)
        {
            AMparts[listIndex].SetActive(true);
            listIndex++;
        }
    }

    public void ResetAnxietyMeter()
    {
        foreach (GameObject part in AMparts)
        {
            part.SetActive(false);
            listIndex = 0;
        }

    }

    public int GetListCount() //instead of making the list public
    {
        return AMparts.Count;
    }    
}
