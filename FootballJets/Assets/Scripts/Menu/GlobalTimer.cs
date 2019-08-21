using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    /* This class counts the time from the beginning of the game.
     */
    public Text timer;
    private float time;

    public void Update()
    {
        time -= Time.deltaTime;
        timer.text = FormatTime();
    }
    public void ResetTime()
    {
        time = 0;
    }
    public float GetTime()
    {
        return time;
    }
    public void SetTime(float t)
    {
        time = t;
    }
    private string FormatTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

    }
}
