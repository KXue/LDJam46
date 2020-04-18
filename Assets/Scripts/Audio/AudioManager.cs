using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
	List<AudioSource>	m_SoundHost;
	List<AudioClip>		m_QueuedList;

	private void Start()
	{
		MessageBus.Instance.AddListener<RequestPlaylistChange>(ChangePlayList);
	}

	private void OnDestroy()
	{
		MessageBus.Instance.RemoveListener<RequestPlaylistChange>(ChangePlayList);
	}

	// Update is called once per frame
	void Update()
    {
		if(HasBarEnded() && m_QueuedList != null)
		{
			Play(m_QueuedList);
		}
	}

    public void Play(List<AudioClip> audioList)
    {
        AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();

		int numberOfSources = audioSources.Length;

		for(int i = 0; i < numberOfSources; ++i)
		{
			Destroy(audioSources[i]);
		}

		for (int i = 0; i < audioList.Count; ++i)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.clip = (AudioClip)Instantiate(audioList[i]);
            newSource.loop = false;
            newSource.volume = 0.5f;
            newSource.Play();
        }
    }

	private bool HasBarEnded()
	{
		AudioSource[] playNowList = gameObject.GetComponents<AudioSource>();
		bool hasBarEnded = true;

		for (int i = 0; i < playNowList.Length; ++i)
		{
			hasBarEnded &= (!playNowList[i].isPlaying);
		}

		return hasBarEnded;
	}

	public void ChangePlayList(RequestPlaylistChange message)
	{
		m_QueuedList = message.m_NextPlaylist;
	}
}
