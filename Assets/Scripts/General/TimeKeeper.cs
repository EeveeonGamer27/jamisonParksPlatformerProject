using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeKeeper : MonoBehaviour
{
    float bestTime1 = 0;
    float TimerTime;
    float minutes;
    float seconds;
    public TMP_Text TimerBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(TimerTime / 60);
        seconds = Mathf.FloorToInt(TimerTime % 60);
        Debug.Log(minutes);
        Debug.Log(seconds);
        //string CurrentTime = string.Format("0:00, 1:00", minutes, seconds);
        TimerBox.text = minutes + ":" + seconds;
    }

    void TimerReset()
    {
        TimerTime = 0;
    }

}
