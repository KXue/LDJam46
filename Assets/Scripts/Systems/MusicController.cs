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

		/*
		bool changePlaylist = false;

		if (Input.GetKeyDown(KeyCode.LeftArrow) && (m_CurrentPlayIndex > 0))
		{
			m_CurrentPlayIndex--;
			changePlaylist = true;
		}

		if (Input.GetKeyDown(KeyCode.RightArrow) && (m_CurrentPlayIndex+1 < 3))
		{
			m_CurrentPlayIndex++;
			changePlaylist = true;
		}

		if(changePlaylist)
		{
			switch(m_CurrentPlayIndex)
			{
				case 0:
					Play(m_WholeBeatTest);
					break;
				case 1:
					Play(m_HalfBeatTest);
					break;
				case 2:
					Play(m_QuarterBeatTest);
					break;
				default:
					break;
			}
		}
		*/
	}
}
