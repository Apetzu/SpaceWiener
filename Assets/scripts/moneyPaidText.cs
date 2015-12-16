using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moneyPaidText : MonoBehaviour {

	public float smoothTime = 1.3F;
	private float yVelocity = 0.0F;
	float fadeOut = 1f;
	Text text;
	public GameObject target;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindWithTag ("customerMaster");
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.color = Color.Lerp (text.color, new Color (230, 255, 0, 0), fadeOut * Time.deltaTime);
		float newPosition = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref yVelocity, smoothTime);
		transform.position = new Vector3 (transform.position.x, newPosition, transform.position.z);
	}
}
