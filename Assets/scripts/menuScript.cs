using UnityEngine;
using System.Collections;

public class menuScript: MonoBehaviour 
{
	public GameObject pauseMenu;

	private bool paused = false;

	void Start()
	{
		pauseMenu.SetActive(false);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;
		}

		if(paused)
		{
			pauseMenu.SetActive(true);
			Time.timeScale = 0;
		}

		if(!paused)
		{
			pauseMenu.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void Resume()
	{
		paused = false;
	}

	public void Play()
	{
		Application.LoadLevel ("pauseMenu");
	}

	public void backToM()
	{
		Application.LoadLevel ("mainMenu");
	}

}
