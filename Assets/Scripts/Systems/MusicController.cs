using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	[SerializeField]
	List<AudioClip> m_WholeBeatTest;

	[SerializeField]
	List<AudioClip> m_HalfBeatTest;

	[SerializeField]
	List<AudioClip> m_QuarterBeatTest;

	// Start is called before the first frame update
	void Start()
    {
		MessageBus.Instance.AddListener<BeatDivisionChange>(OnBeatDivisionChange);
	}

	private void OnDestroy()
	{
		MessageBus.Instance.RemoveListener<BeatDivisionChange>(OnBeatDivisionChange);
	}

	// Update is called once per frame
	void Update()
    {
		/*
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			RequestPlaylistChange message = new RequestPlaylistChange();
			message.Sender = this.gameObject;
			message.m_NextPlaylist = m_QuarterBeatTest;
			MessageBus.Instance.SendMessage(message);
		}
		*/
	}

	public void OnBeatDivisionChange(BeatDivisionChange message)
	{
		List<AudioClip> updatePlaylist = null;

		switch (message.m_BeatDivision)
		{
			case 8:
			case 4:
				updatePlaylist = m_QuarterBeatTest;
				break;
			case 2:
				updatePlaylist = m_HalfBeatTest;
				break;
			case 1:
				updatePlaylist = m_WholeBeatTest;
				break;
			default:
				break;
		};

		if(updatePlaylist != null)
		{
			RequestPlaylistChange playlistMessage = new RequestPlaylistChange();
			playlistMessage.Sender = this.gameObject;
			playlistMessage.m_NextPlaylist = updatePlaylist;
			MessageBus.Instance.SendMessage(playlistMessage);
		}
	}
}
