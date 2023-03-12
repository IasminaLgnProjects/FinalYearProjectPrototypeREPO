using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private const float REAL_SECONDS_PER_INGAME_DAY = 60f;
    private Transform hourHandTransform;
    private Transform minuteHandTransform;
    private float day;
    
    private void Awake()
    {

    }

    private void Start()
    {
        
        hourHandTransform = transform.Find("HourHand");
        minuteHandTransform = transform.Find("MinuteHand");
    }
    private void Update()
    {
        //print(hourHandTransform);
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;

        //hour hand rotation
        float rotationDegreesPerDay = 360f;
        hourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);
        
        //minute hand rotation
        float hoursPerDay = 24f; //the minute rotates 24 times for every rotation of the hour hand
        minuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);
    }
}
