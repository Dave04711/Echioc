using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    float duration = 10;
    float timeRemaining = 10;
    bool isCounting = false;
    public Action finishCallback;


    private void Update()
    {
        if (isCounting)
        {
            if(timeRemaining > 0) { timeRemaining -= Time.deltaTime; }
            else 
            {
                timeRemaining = 0;
                isCounting = false;
                finishCallback();
            }
        }
    }

    public void StartCounting(float _time) 
    {
        if (isCounting == false)
        {
            timeRemaining = _time;
            duration = _time;
            isCounting = true; 
        }
        else { Debug.LogWarning("Timer " + name + " is already running!"); }
    }

    public float GetTimeLeft() { return timeRemaining; }
    public float GetCompletionPercent() { return timeRemaining / duration; }
}