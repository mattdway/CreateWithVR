using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{

    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6f;
    const float degreesPerSecond = 6f;
    public Transform hoursTransform, minutesTransform, secondsTransform;
    public bool continuous;

    // Update is called once per frame
    void Update()
    {
        if (continuous == true)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }

        void UpdateContinuous()
        {
            TimeSpan time = DateTime.Now.TimeOfDay;
            hoursTransform.localRotation = Quaternion.Euler((float)time.TotalHours * degreesPerHour, 0f, 0f);
            minutesTransform.localRotation = Quaternion.Euler((float)time.TotalMinutes * degreesPerMinute, 0f, 0f);
            secondsTransform.localRotation = Quaternion.Euler((float)time.TotalSeconds * degreesPerSecond, 0f, 0f);
            print(time);
        }
    }

    void UpdateDiscrete()
    {
        DateTime now = DateTime.Now;
        hoursTransform.localRotation = Quaternion.Euler(now.Hour * degreesPerHour, 0f, 0f);
        minutesTransform.localRotation = Quaternion.Euler(now.Minute * degreesPerMinute, 0f, 0f);
        secondsTransform.localRotation = Quaternion.Euler(now.Second * degreesPerSecond, 0f, 0f);
    }
}