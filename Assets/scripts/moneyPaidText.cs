﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moneyPaidText : MonoBehaviour {

	public float smoothTime = 1.3F;
	private float yVelocity = 0.0F;
	float fadeOut = 1f;
	Text text;
	public float target = 10f;
	public Camera mainCamera;
	private Vector3 newThisPosition;

	// Use this for initialization
	void Start () 
	{
		//target = GameObject.FindWithTag ("customerMaster");
		text = GetComponent<Text>();
		mainCamera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*text.color = Color.Lerp (text.color, new Color (230, 255, 0, 0), fadeOut * Time.deltaTime);
		newThisPosition = mainCamera.WorldToScreenPoint (transform.position);
		float newPosition = Mathf.SmoothDamp(newThisPosition.y, newThisPosition.y + target, ref yVelocity, smoothTime);
		transform.position = mainCamera.ScreenToWorldPoint(new Vector3 (newThisPosition.x, newPosition, newThisPosition.z));*/
	}
}
