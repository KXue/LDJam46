﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSystem : MonoBehaviour
{
    private static BeatSystem instance;
    
    public static BeatSystem Instance{ get{ return instance; } }
    
    public static bool IsHalfBeat( int halfBeatCount )
    {
        return halfBeatCount % 2 == 0; 
    }

    public int BPM
    {
        get { return bpm; }
        set
        { 
            bpm = value;
            Start();
        }
    }
    public int BeatsPerBar
    {
        get { return beatsPerBar; }
        set 
        { 
            beatsPerBar = value;
            ResetBeatCounter();
            Start();
        }
    }
    public int HalfBeatCount{ get { return halfBeatCounter; } }
    public float SecondsPerHalfBeat{ get { return secondsPerHalfBeat; } }

    [SerializeField]
    private int bpm;
    [SerializeField]
    private int beatsPerBar;

    private int halfBeatCounter;
    private float secondsPerHalfBeat;
    private float lastBeatTime;
    
    public float NearestBeat(bool halfBeat = false)
    {
        float time = Time.time;
        bool lastTimeWasHalfBeat = IsHalfBeat(HalfBeatCount);
        if(halfBeat)
        {
            float lastBeat = time - lastBeatTime;
            float nextBeat = lastBeatTime + secondsPerHalfBeat - time;
            if (nextBeat < lastBeat)
            {
                return -nextBeat;
            }
            else
            {
                return lastBeat;
            }
        }
        else
        {
            return lastTimeWasHalfBeat ? time - (lastBeatTime + secondsPerHalfBeat) : time - lastBeatTime;
        }
    }
    public float TimeTillNextBeat(bool isHalf = false)
    {
        if(isHalf)
        {
            return lastBeatTime + secondsPerHalfBeat - Time.time;
        }
        else
        {
            return lastBeatTime + secondsPerHalfBeat * (IsHalfBeat(HalfBeatCount) ? 1.0f : 2.0f) - Time.time;
        }
    }
    
    private void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            CalculateTimer();
            ResetBeatCounter();
        }
    }
    private void Start()
    {
        CancelInvoke("Beat");
        InvokeRepeating("Beat", 0, secondsPerHalfBeat);
    }
    private void CalculateTimer()
    {
        if(bpm != 0)
        {
            secondsPerHalfBeat = 60.0f * 0.5f / (float)bpm;
        }
    }
    private void ResetBeatCounter()
    {
        halfBeatCounter = 0;
    }
    private void Beat()
    {
        lastBeatTime = Time.time;
        halfBeatCounter++;
        
        BeatMessage beatMessage = new BeatMessage();
        beatMessage.Sender = gameObject;
        beatMessage.HalfBeatCount = HalfBeatCount;

        MessageBus.Instance.SendMessage(beatMessage);

        if (halfBeatCounter >= beatsPerBar * 2)
        {
            ResetBeatCounter();
            BarMessage barMessage = new BarMessage();
            barMessage.Sender = gameObject;
            MessageBus.Instance.SendMessage(barMessage);
        }
    }
}
