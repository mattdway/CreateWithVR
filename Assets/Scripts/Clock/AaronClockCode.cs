using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AaronClockCode : MonoBehaviour
{
    public Transform secondHand = null;
    public Transform minuteHand = null;
    public Transform hourHand = null;

    // Update is called once per frame
    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        DateTime now = DateTime.Now;
        UpdateSecond(now);
        UpdateMinute(now);
        UpdateHour(now);
    }

    private void UpdateSecond(DateTime now)
    {
        Vector3 newSecondRotation = new Vector3(6.0f * now.Second, 0, 0);
        secondHand.localRotation = Quaternion.Euler(newSecondRotation);
    }

    private void UpdateMinute(DateTime now)
    {
        Vector3 newMinuteRotation = new Vector3(6.0f * now.Minute, 0, 0);
        minuteHand.localRotation = Quaternion.Euler(newMinuteRotation);
    }

    private void UpdateHour(DateTime now)
    {
        Vector3 newHourRotation = new Vector3(30.0f * now.Hour, 0, 0);
        hourHand.localRotation = Quaternion.Euler(newHourRotation);
    }
}
