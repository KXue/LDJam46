using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : UIBaseScreen
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			GameManager.Instance.StartGame();
			UIManager.Instance.LoadScreen(UIManager.eScreens.HUD);
		}
	}
}
