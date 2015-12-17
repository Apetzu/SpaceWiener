using UnityEngine;
using System.Collections;

public class shutterScript : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameObject.transform.position.y == 6)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}

		if(Time.timeScale == 0)
		{
			Debug.Log("Paused true");
		}
		else
		{
			Debug.Log("Paused false");
		}
	}
	
	void OnMouseDown()
	{ 
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag() 
	{ 
		Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
		gameObject.transform.position = new Vector3 (0, Mathf.Clamp (point.y, 6.0F, 14.0F), 0);
	}
}

