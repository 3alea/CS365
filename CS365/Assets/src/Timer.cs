using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float StartTime;
    private string minutes;
    private string seconds;
    private string solution;
    void Start()
    {
        StartTime = Time.time;
    }


    void Update()
    {
        float t = Time.time - StartTime;
        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        TimerText.text = string.Format("{00:00}:{01:00}", minutes, seconds); ;
    }

    public void TimerStart()
    {
        StartTime = Time.time;
        TimerText.color = new Color(TimerText.color.r, TimerText.color.g, TimerText.color.b, 1.0f);
    }
}
