using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base Message Type, defines a sender.
public class Message
{
    public GameObject Sender { get; set; }
}

public class RequestPlaylistChange : Message
{
	public List<AudioClip> m_NextPlaylist;
}
