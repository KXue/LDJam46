using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base Message Type, defines a sender.
public class Message
{
    public GameObject Sender { get; set; }
}

/*
public class SimUpdateMessage : Message
{
    public static readonly float secondsPerDay = 86400.0f;
    public float CurrentTime;

    public float GetSecondsToday() { return CurrentTime % (secondsPerDay); }

    public int GetTODHour() { return Mathf.FloorToInt(GetSecondsToday() / 3600.0f); }
    public int GetTODMinute() { return Mathf.FloorToInt((GetSecondsToday() - (GetTODHour() * 3600.0f)) / 60.0f); }

    public int GetTODSecond() { return Mathf.FloorToInt(GetSecondsToday() - (GetTODHour() * 3600.0f) - (GetTODMinute() * 60.0f)); }

    public int GetCurrentDay() { return Mathf.FloorToInt(CurrentTime / secondsPerDay) + 1; }
    public float GetCurrentHappiness() { return (Random.value * 500); }
}
*/