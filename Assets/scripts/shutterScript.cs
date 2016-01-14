using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shutterScript : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;

	public GameObject kioskForeground;
	public Text instructionText;
	//public AudioClip shutterTest;

	Vector3 lastPosition;
	Transform transForm;
	public bool isMoving;
	
	SpriteRenderer kioskRend;
	SpriteRenderer shutterRend;
	
	AudioSource audio;
	
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

		transForm = transform;
		lastPosition = transForm.position;
		isMoving = false;

		audio = GetComponent<AudioSource> ();
	}

	void Update () 
	{
		if(gameObject.transform.position.y >= 6)
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

		//if(Time.timeScale == 0)
		//{
		//	Debug.Log("Paused true");
		//}
		//else
		//{
		//	Debug.Log("Paused false");
		//}

		if(transForm.position != lastPosition)
		{
			isMoving = true;
		}
		else
		{
			isMoving = false;
		}

		lastPosition = transForm.position;

		/*if(!audio.isPlaying)
		{
			Debug.Log("TOIMII!");
		}*/
		/*if(isMoving == true)
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play ();
			Debug.Log("moving");
		}*/

		if((isMoving == true) && (audio.isPlaying == false))
		{
			//AudioSource audio = GetComponent<AudioSource>();
			audio.Play ();
			Debug.Log("moving");
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

