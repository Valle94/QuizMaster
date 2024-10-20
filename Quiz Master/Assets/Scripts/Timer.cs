using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion = true;
    public bool isAnsweringQuestion = false;
    public float fillFraction;

    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (timerValue <= 0)
        {
            if (isAnsweringQuestion == false)
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (isAnsweringQuestion == false)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
        }
        Debug.Log(isAnsweringQuestion + ": " + timerValue + " = " + fillFraction);
    }
}
