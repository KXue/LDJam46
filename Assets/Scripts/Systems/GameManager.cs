using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
		ChangeScene("TitleScreen");
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void StartGame()
	{
		//ChangeScene("Main");
		ChangeScene("Sandbox");
	}

	public void ChangeScene(string requestedScene)
	{
		string activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
		UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(activeScene);
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(requestedScene, UnityEngine.SceneManagement.LoadSceneMode.Additive);
	}
}
