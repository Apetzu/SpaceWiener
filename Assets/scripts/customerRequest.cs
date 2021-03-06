﻿using UnityEngine;
using System.Collections;

public class customerRequest : MonoBehaviour {

	/* Randomizes customizers ingredient values and sets the sprites
	 * to the ingredients in question
	 */

	float randBoolSpice;
	float randBoolSalad;

	public GameObject sauceObj;
	public GameObject saladObj;
	public GameObject wienerObj;

	public Sprite sauce1;
	public Sprite sauce2;
	public Sprite sauce3;
	public Sprite salad1;
	public Sprite salad2;
	public Sprite salad3;
	public Sprite wiener1;
	public Sprite wiener2;
	public Sprite wiener3;
	SpriteRenderer sauceRend;
	SpriteRenderer wienerRend;
	SpriteRenderer saladRend;

	public bool sauce;
	public bool salad;
	
	public int wienerI;
	public int sauceI;
	public int saladI;
	
	void Start () 
	{
		sauceRend = sauceObj.GetComponent<SpriteRenderer> ();
		saladRend = saladObj.GetComponent<SpriteRenderer> ();
		wienerRend = wienerObj.GetComponent<SpriteRenderer> ();
		RandomizeValues ();
		ChangeSprites ();
	}
	void RandomizeValues()
	{
		//rolls whether the customer wants sauce or not 
		randBoolSpice = Random.Range (1,10);
		//2 / 10 times customer does not want salad
		if (randBoolSpice > 2)
		{
			sauce = true;
		}
		else 
		{
			sauce = false;
		}
		//rolls whether the customer wants salad or not 
		randBoolSalad = Random.Range (1,10);
		//2 / 10 times customer does not want salad
		if (randBoolSalad > 2f)
		{
			salad = true;
		}
		else 
		{
			salad = false;
		}
		//rolls customers desired ingredients
		wienerI = Random.Range (0,3);
		sauceI = Random.Range (0,3);
		saladI = Random.Range (0,3);
	}
	//sets sprites to correspond customers wants
	void ChangeSprites()
	{
		if (sauce == true && sauceI == 0)
		{
			sauceRend.sprite = sauce1;
		}
		else if (sauce == true && sauceI == 1)
		{
			sauceRend.sprite = sauce2;
		}
		else if (sauce == true && sauceI == 2)
		{
			sauceRend.sprite = sauce3;
		}
		else
		{
			sauceRend.sprite = null;
		}
		if (salad == true && saladI == 0)
		{
			saladRend.sprite = salad1;
		}
		else if (salad == true && saladI == 1)
		{
			saladRend.sprite = salad2;
		}
		else if (salad == true && saladI == 2)
		{
			saladRend.sprite = salad3;
		}
		else
		{
			saladRend.sprite = null;
		}
		if (wienerI == 0)
		{
			wienerRend.sprite = wiener1;
		}
		else if (wienerI == 1)
		{
			wienerRend.sprite = wiener2;
		}
		else if (wienerI == 2)
		{
			wienerRend.sprite = wiener3;
		}
		else
		{
			wienerRend.sprite = null;
		}
	}
	void Update () 
	{
	
	}
}
