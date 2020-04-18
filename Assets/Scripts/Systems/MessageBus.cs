using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Simple Message Bus That allows us to set up fire and forget messages between UI and logical systems
/// - As noted in my email, I have been utilizing a custom version of https://gist.github.com/bendangelo/093edb33c2e844c5c73a 
///  for some time now, so I removed some of my changes and made it simpler for this test. It's my go-to message / event system for any front end system I'm working on.
///  I strongly dislike UI and backend / logic code being coupled with references.
/// </summary>
public class MessageBus : MonoBehaviourSingleton<MessageBus>
{
    public delegate void EventDelegate<T>(T msg) where T : Message;
    delegate void EventDelegate(Message msg);

    private Dictionary<System.Type, EventDelegate> m_Delegates;
    private Dictionary<System.Delegate, EventDelegate> m_DelegateLookup;

    public void Awake()
    {
        m_Delegates = new Dictionary<System.Type, EventDelegate>();
        m_DelegateLookup = new Dictionary<System.Delegate, EventDelegate>();
    }

    public void AddListener<T>(EventDelegate<T> msgDelegate) where T : Message
    {
        // If we've already added this listener, don't add it.
        if (m_DelegateLookup.ContainsKey(msgDelegate))
        {
            return;
        }

        EventDelegate internalDelegate = (msg) => { msgDelegate((T)msg); };
        m_DelegateLookup[msgDelegate] = internalDelegate;

        EventDelegate foundDelegate;
        if (m_Delegates.TryGetValue(typeof(T), out foundDelegate))
        {
            m_Delegates[typeof(T)] = foundDelegate += internalDelegate;
        }
        else
        {
            m_Delegates[typeof(T)] = internalDelegate;
        }
    }

    public void RemoveListener<T>(EventDelegate<T> msgDelegate) where T : Message
    {
        EventDelegate foundDelegate;
        if (m_DelegateLookup.TryGetValue(msgDelegate, out foundDelegate))
        {
            EventDelegate existingDelegate;
            if (m_Delegates.TryGetValue(typeof(T), out existingDelegate))
            {
                existingDelegate -= foundDelegate;
                if (existingDelegate == null)
                {
                    m_Delegates.Remove(typeof(T));
                }
                else
                {
                    m_Delegates[typeof(T)] = existingDelegate;
                }
            }
        }
    }

    public void SendMessage(Message msg)
    {
        EventDelegate foundDelegate;
        if (m_Delegates.TryGetValue(msg.GetType(), out foundDelegate))
        {
            foundDelegate.Invoke(msg);
        }
    }

    public void Clear()
    {
        m_Delegates.Clear();
    }
}