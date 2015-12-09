using UnityEngine;
using System.Collections;

public class customer1 : MonoBehaviour {

	float speed = 0.5f;
	float side;
	float timeLeft = 8;
	int chosenPosition = 4;
	float lifeTime = 20;
	public int position = 0;

	GameObject masterObj;
	GameObject target1;
	GameObject target2;
	GameObject target3;
	GameObject target4;

	bool moveToPos1;
	bool moveToPos2;
	bool moveToPos3;
	bool moveToPos4;

	customerMaster masterScript;
	
	void Start () 
	{
		timeLeft = Random.Range (8, 13);
		ChoosePos();
		side = Random.value;
		target1 = GameObject.FindWithTag ("custPos1");
		target2 = GameObject.FindWithTag ("custPos2");
		target3 = GameObject.FindWithTag ("custPos3");
		target4 = GameObject.FindWithTag ("custPos4");
		masterObj = GameObject.FindWithTag ("customerMaster");
		masterScript = masterObj.GetComponent<customerMaster>();
		SetPosition ();
	}
	void ChoosePos()
	{
		chosenPosition = Random.Range (1,5);

	}
	void Update () 
	{
		if (moveToPos1 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed);
			if (transform.position == target1.transform.position)
			{
				masterScript.pos1Taken = true;
				position = 1;
				transform.GetChild(0).gameObject.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos2 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
			if (transform.position == target2.transform.position)
			{
				masterScript.pos2Taken = true;
				position = 2;
				transform.GetChild(0).gameObject.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos3 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target3.transform.position, speed);
			if (transform.position == target3.transform.position)
			{
				masterScript.pos3Taken = true;
				position = 3;
				transform.GetChild(0).gameObject.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos4 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target4.transform.position, speed);
			if (transform.position == target4.transform.position)
			{
				masterScript.pos4Taken = true;
				position = 4;
				transform.GetChild(0).gameObject.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (timeLeft < timeLeft / 2)
		{

		}
		if (timeLeft < 0)
		{
			if (position == 1)
			{
				moveToPos1 = false;
				Leave ();
				masterScript.pos1Taken = false;
			}
			if (position == 2)
			{
				moveToPos2 = false;
				Leave ();
				masterScript.pos2Taken = false;
			}
			if (position == 3)
			{
				moveToPos3 = false;
				Leave ();
				masterScript.pos3Taken = false;
			}
			if (position == 4)
			{
				moveToPos4 = false;
				Leave ();
				masterScript.pos4Taken = false;
			}
		}
		lifeTime -= Time.deltaTime;
		if (lifeTime < 0)
		{
			Destroy (gameObject);
		}
	}
	void Leave()
	{
		//Payment system here
		if (side > 0.5)
		{
			transform.Translate(Vector2.left * speed);
		}
		else
		{
			transform.Translate(Vector2.right * speed);
		}
		transform.GetChild(0).gameObject.SetActive(false);
	}
	void SetPosition()
	{
		if (chosenPosition == 1)
		{
			if (masterScript.pos1Taken == false)
			{
				moveToPos1 = true;
			}
			else
			{
				Destroy (gameObject);
			}
		}
		if (chosenPosition == 2)
		{
			if (masterScript.pos2Taken == false)
			{
				moveToPos2 = true;
			}
			else
			{
				Destroy (gameObject);
			}
		}
		if (chosenPosition == 3)
		{
			if (masterScript.pos3Taken == false)
			{
				moveToPos3 = true;
			}
			else
			{
				Destroy (gameObject);
			}
		}
		if (chosenPosition == 4)
		{
			if (masterScript.pos4Taken == false)
			{
				moveToPos4 = true;
			}
			else
			{
				Destroy (gameObject);
			}
		}
	}
}
