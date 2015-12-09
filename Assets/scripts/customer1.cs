using UnityEngine;
using System.Collections;

public class customer1 : MonoBehaviour {

	float speed = 2;
	float side;
	float timeLeft = 8;

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
	public int position = 0;
	
	void Start () 
	{
		timeLeft = Random.Range (8, 13);
		side = Random.value;
		target1 = GameObject.FindWithTag ("custPos1");
		target2 = GameObject.FindWithTag ("custPos2");
		target3 = GameObject.FindWithTag ("custPos3");
		target4 = GameObject.FindWithTag ("custPos4");
		masterObj = GameObject.FindWithTag ("customerMaster");
		masterScript = masterObj.GetComponent<customerMaster>();
		SetPosition ();
		Debug.Log (position);
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
				// here be what customer want
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
				// here be what customer want
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
				// here be what customer want
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
				// here be what customer want
				timeLeft -= Time.deltaTime;
			}
		}
		if (timeLeft < 0)
		{
			if (position == 1)
			{
				moveToPos1 = false;
				leave ();
				masterScript.pos1Taken = false;
			}
			if (position == 2)
			{
				moveToPos2 = false;
				leave ();
				masterScript.pos2Taken = false;
			}
			if (position == 3)
			{
				moveToPos3 = false;
				leave ();
				masterScript.pos3Taken = false;
			}
			if (position == 4)
			{
				moveToPos4 = false;
				leave ();
				masterScript.pos4Taken = false;
			}
		}
	}
	void leave()
	{
		if (side > 0.5)
		{
			transform.Translate(Vector2.left * speed);
		}
		else
		{
			transform.Translate(Vector2.right * speed);
		}
	}
	void SetPosition()
	{
		if (masterScript.pos1Taken == false)
		{
			Debug.Log ("pos1free");
			moveToPos1 = true;
		}
		else if (masterScript.pos2Taken == false)
		{
			Debug.Log ("pos2free");
			moveToPos2 = true;
		}
		else if (masterScript.pos3Taken == false)
		{
			Debug.Log ("pos3free");
			moveToPos3 = true;
		}
		else if (masterScript.pos4Taken == false)
		{
			Debug.Log ("pos4free");
			moveToPos4 = true;
		}
	}
}
