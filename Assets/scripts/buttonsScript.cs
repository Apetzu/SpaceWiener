using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class buttonsScript : MonoBehaviour {


	void Start () 
	{
	
	}

	void Update () 
	{
	
	}
	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

}
