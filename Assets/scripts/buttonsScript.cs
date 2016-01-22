using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class buttonsScript : MonoBehaviour {

	public GameObject shutter;

	shutterScript shutterScriptScript;


	void Start () 
	{
		shutterScriptScript = shutter.GetComponent<shutterScript> ();
	}

	void Update () 
	{
	
	}
	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void GameOverBoolSetter()
	{
		shutterScriptScript.gameOver = false;
	}

}
