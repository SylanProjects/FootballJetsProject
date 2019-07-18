using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    public Text timer;
    private float time;
    // Start is called before the first frame update
    public void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        time += Time.deltaTime;
        timer.text = FormatTime();//((int) time).ToString();
    }
    public void ResetTime()
    {
        time = 0;
    }
    private string FormatTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

    }
}
