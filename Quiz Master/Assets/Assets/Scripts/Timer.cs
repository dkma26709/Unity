using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30;
    [SerializeField] float timeToShowCorrectAnswer = 30;

    public bool loadNextQuestion = false;
    public float fillFraction;
    public bool isAnsweringQuestion = true;
    public bool isReady = false;

    float TimerValue;

    void Update()
    {
        if (isReady)
        {
            UpdateTimer();
        }
    }

    public float GetTimeToCompleteQuestion()
    {
        return timeToCompleteQuestion;
    }

    public float GetTimerValue()
    {
        return TimerValue;
    }

    public void CancelTimer()
    {
        TimerValue = 0;
    }

    public void IsReady()
    {
        isReady = true;
    }

    void UpdateTimer()
    {
        TimerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (TimerValue > 0)
            {
                fillFraction = TimerValue/timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                TimerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (TimerValue > 0)
            {
                fillFraction = TimerValue/timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                TimerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
