using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base Message Type, defines a sender.
public class Message
{
    public GameObject Sender { get; set; }
}
public class BeatMessage : Message
{
    public int HalfBeatCount { get; set; }
}
public class BarMessage : Message {}

public class BeatDivisionChange : Message
{
	public int m_BeatDivision;
}

public class RequestPlaylistChange : Message
{
	public List<AudioClip> m_NextPlaylist;
}
