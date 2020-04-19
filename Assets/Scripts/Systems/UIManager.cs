using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviourSingleton<UIManager>
{
	public enum eScreens
	{
		Title = 0,
		Gameover,
		Win,
		HUD,
		MAX = HUD
	}

	[SerializeField]
	private List<UIBaseScreen> m_ScreenPrefabs;

	[SerializeField]
	private Camera m_UICamera;

	private UIBaseScreen m_CurrentScreen;
	private eScreens m_CurrentScreenID = eScreens.Title;

	// Start is called before the first frame update
	void Start()
	{
		LoadScreen(eScreens.Title);
	}

	public void StartGameplay()
	{
		m_UICamera.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void LoadScreen(eScreens screen)
	{
		if (m_CurrentScreen != null)
		{
			m_CurrentScreen.Shutdown();
			GameObject.Destroy(m_CurrentScreen.gameObject);
		}

		m_CurrentScreen = GameObject.Instantiate(m_ScreenPrefabs[(int)screen], this.transform, false).GetComponent<UIBaseScreen>();
		m_CurrentScreen.Init();
	}
}
