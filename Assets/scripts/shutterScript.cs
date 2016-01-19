using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shutterScript : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;

	public GameObject kioskForeground;
	public Text instructionText;


	Vector3 lastPosition;
	Transform transForm;
	//Transform transForm2;
	public bool isMoving;
	
	SpriteRenderer kioskRend;
	SpriteRenderer shutterRend;
	
	AudioSource moving;
	AudioSource close;

	//Transform here;
	//Transform stop;
	//private float startTime;
	//private float jorneyLenght;
	//public float speed = 1.0f;

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

		AudioSource[] audioSources = GetComponents<AudioSource> ();
		moving = audioSources [0];
		close = audioSources [1];
	}

	void Update () 
	{
		//here = transForm;
		//stop = transForm2;

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
<<<<<<< HEAD

		if(transForm.position != lastPosition)
		{
			isMoving = true;
		}
		else if(transForm.position == lastPosition)
		{
			isMoving = false;
		}
		
		lastPosition = transForm.position;
=======
		//if(Time.timeScale == 0)
		//{
		//	Debug.Log("Paused true");
		//}
		//else
		//{
		//	Debug.Log("Paused false");
		//}
	}
>>>>>>> origin/master
	
		moving.volume = 0.4f;

		if(isMoving == true && moving.isPlaying == false)
		{
			moving.Play ();
		}
		else if(isMoving == false && moving.isPlaying == true)
		{
			//moving.volume = 0;
			//moving.Stop();
			moving.Pause();
		}


		if(isMoving == true && gameObject.transform.position.y == 5 || isMoving == true && gameObject.transform.position.y == 13)
		{
			close.Play ();
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

