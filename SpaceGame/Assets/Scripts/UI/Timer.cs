﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Timer : MonoBehaviour, ISubject
{
    public enum TimerState
    {
        ACTIVE,
        OUT_OF_TIME,
        PAUSED
    }
    private TimerState m_state = TimerState.OUT_OF_TIME;
    private List<IObserver> m_Observers = new List<IObserver>();
    private float m_TimeLeft = 0;
    private float m_StartTime = 0;
    void Update()
    {
        if (m_state == TimerState.ACTIVE)
        {
            m_TimeLeft -= Time.deltaTime;

            if (m_TimeLeft <= 0)
            {
                m_state = TimerState.OUT_OF_TIME;
            }
            Notify();
        }
    }
    public void Pause()
    {
        m_state=TimerState.PAUSED;
    }
    public void Continue()
    {
        m_state = TimerState.ACTIVE;
    }
    public float GetStartTime() => m_StartTime;
    public TimerState GetState() => m_state;
    public float GetTime() => m_TimeLeft;
    public void StartTimer(float newDuration)
    {
        m_StartTime = newDuration;
        m_TimeLeft = newDuration;
        m_state = TimerState.ACTIVE;
    }

    public void IncreaseTimeLeft(float timeGained)
    {
        m_TimeLeft += timeGained;
        Notify();
        // TO DO: text pop up to visualize increase in time
    }
    public void Notify()
    {
        foreach (IObserver observer in m_Observers)
        {
            observer.GetUpdate(this);
        }
    }

    public void Attach(IObserver observer)
    {
        m_Observers.Add(observer);
    }
}
