using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shutterScript : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;

	public GameObject kioskForeground;
	public Text instructionText;

	SpriteRenderer kioskRend;
	SpriteRenderer shutterRend;

	/*SORTING ORDERS:
	 * speecbubble = 7
	 * bread = 8
	 * breads children = 9 (nakki, salad, sauce)
	 * shutter = 5 when down
	 * kiosk = 6 when shutter down
	 * shutter = 10 when up
	 * kiosk = 11 when shutter up
	 */
	
	void Start () 
	{
		Time.timeScale = 0;
		shutterRend = GetComponent<SpriteRenderer> ();
		kioskRend = kioskForeground.GetComponent<SpriteRenderer> ();
	}

	void Update () 
	{
		if(gameObject.transform.position.y != 5)
		{
			Time.timeScale = 1;
			instructionText.enabled = false;
		}
		else
		{
			Time.timeScale = 0;
		}
		if(gameObject.transform.position.y < 10)
		{
			shutterRend.sortingOrder = 10;
			kioskRend.sortingOrder = 11;
		}
		else
		{
			kioskRend.sortingOrder = 6;
			shutterRend.sortingOrder = 0;
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
		gameObject.transform.position = new Vector3 (0, Mathf.Clamp (point.y, 5.0F, 13.0F), 0);
	}
}

