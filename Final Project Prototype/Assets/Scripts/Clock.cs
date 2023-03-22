using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float REAL_SECONDS_PER_INGAME_DAY = 60f;
    private Transform hourHandTransform;
    private Transform minuteHandTransform;
    private float day;

    //floats
    float dayNormalized;
    float rotationDegreesPerDay;
    float hoursPerDay;


    private void Awake()
    {

    }

    private void Start()
    {
        rotationDegreesPerDay = 360f;
        hourHandTransform = transform.Find("HourHand");
        minuteHandTransform = transform.Find("MinuteHand");
    }
    private void Update()
    {
        //print(hourHandTransform);
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        dayNormalized = day % 1f;

        //hour hand rotation
        //rotationDegreesPerDay = 360f;
        hourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);
        
        //minute hand rotation
        hoursPerDay = 24f; //the minute rotates 24 times for every rotation of the hour hand
        minuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);
    }
}
