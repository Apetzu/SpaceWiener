using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class buttonsScript : MonoBehaviour {

	GameObject creditsObj;
	GameObject tutorialObj;

	public bool isVisible;

	public UnityEvent OnClick;
	public UnityEvent OnRelease;

	void Start () 
	{
		
	}

	void Update () 
	{
	
	}
	public void Clicked()
	{
		Debug.Log ("clicked");
	}
	public void ClickCredits()
	{
		if (isVisible != true)
		{
			creditsObj.SetActive(true);
		}
		else
		{
			creditsObj.SetActive(false);
		}
	}
	public void ClickTutorial()
	{
		if (isVisible != true)
		{
			tutorialObj.SetActive(true);
		}
		else
		{
			tutorialObj.SetActive(false);
		}
	}
	public void ClickRestart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

}
