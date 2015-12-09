using UnityEngine;
using System.Collections;

public class customerRequest : MonoBehaviour {

	bool sauce;
	bool salad;

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

	int wienerI;
	int sauceI;
	int saladI;
	
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
		randBoolSpice = Random.Range (1,9);
		if (randBoolSpice > 4)
		{
			sauce = true;
		}
		else 
		{
			sauce = false;
		}
		randBoolSalad = Random.Range (1,9);
		if (randBoolSalad > 2f)
		{
			salad = true;
		}
		else 
		{
			salad = false;
		}
		wienerI = Random.Range (1,4);
		sauceI = Random.Range (1,4);
		saladI = Random.Range (1,4);
		Debug.Log (sauce);
		Debug.Log (salad);
		Debug.Log (wienerI);
		Debug.Log (sauceI);
		Debug.Log (saladI);
	}
	void ChangeSprites()
	{
		if (sauce == true && sauceI == 1)
		{
			sauceRend.sprite = sauce1;
		}
		else if (sauce == true && sauceI == 2)
		{
			sauceRend.sprite = sauce2;
		}
		else if (sauce == true && sauceI == 3)
		{
			sauceRend.sprite = sauce3;
		}
		else
		{
			saladRend.sprite = null;
		}
		if (sauce == true && saladI == 1)
		{
			saladRend.sprite = salad1;
		}
		else if (sauce == true && saladI == 2)
		{
			saladRend.sprite = salad2;
		}
		else if (sauce == true && saladI == 3)
		{
			saladRend.sprite = salad3;
		}
		else
		{
			saladRend.sprite = null;
		}
		if (wienerI == 1)
		{
			wienerRend.sprite = wiener1;
		}
		else if (wienerI == 2)
		{
			wienerRend.sprite = wiener2;
		}
		else if (wienerI == 3)
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
