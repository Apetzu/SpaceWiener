using UnityEngine;
using System.Collections;

public class customer1 : MonoBehaviour {


	/* Customer chooses position to go to and goes there
	 * speechbubble is displayed which shows what the customer wants
	 */
	float speed = 0.5f;
	float side;
	public float timeLeft = 8;
	int chosenPosition = 4;
	float lifeTime = 20;
	float timeLeftCopy = 0;
	public int position = 0;

	GameObject speechBubble;
	GameObject masterObj;
	GameObject target1;
	GameObject target2;
	GameObject target3;
	GameObject target4;

	Animator animator;

	SpriteRenderer custRend;

	bool moveToPos1;
	bool moveToPos2;
	bool moveToPos3;
	bool moveToPos4;

	customerMaster masterScript;
	
	void Start () 
	{
		custRend = GetComponent<SpriteRenderer> ();
		speechBubble = gameObject.transform.Find ("speechbubble1").gameObject;
		timeLeft = Random.Range (8, 13);
		timeLeftCopy = timeLeft;
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
			//tells customer to move to its position
			transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed);
			if (transform.position == target1.transform.position)
			{
				//shows speechbubble and its contents
				custRend.sortingOrder = 0;
				masterScript.pos1Taken = true;
				position = 1;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos2 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
			if (transform.position == target2.transform.position)
			{
				custRend.sortingOrder = 0;
				masterScript.pos2Taken = true;
				position = 2;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos3 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target3.transform.position, speed);
			if (transform.position == target3.transform.position)
			{
				custRend.sortingOrder = 0;
				masterScript.pos3Taken = true;
				position = 3;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos4 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target4.transform.position, speed);
			if (transform.position == target4.transform.position)
			{
				custRend.sortingOrder = 0;
				masterScript.pos4Taken = true;
				position = 4;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (timeLeft < timeLeftCopy / 2.0f)
		{
			Animator animator = GetComponent<Animator>();
			animator.SetTrigger("angry");
		}
		//customer leaves and sets its position as free
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
		if (moveToPos1 == true)
		{
			masterScript.pos1Taken = true;
		}
		if (moveToPos2 == true)
		{
			masterScript.pos2Taken = true;
		}
		if (moveToPos3 == true)
		{
			masterScript.pos3Taken = true;
		}
		if (moveToPos4 == true)
		{
			masterScript.pos4Taken = true;
		}
	}
	//Leave chooses side customer will leave to and deletes the speechbubble
	public void Leave()
	{
		custRend.sortingOrder = -3;
		Animator animator = GetComponent<Animator>();
		animator.SetTrigger("leaving");
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
			//this sets the chosen position as taken and moves customer to the position if chosen position is taken customer is destroyed
			if (masterScript.pos1Taken == false)
			{
				masterScript.pos1Taken = true;
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
				masterScript.pos2Taken = true;
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
				masterScript.pos3Taken = true;
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
				masterScript.pos4Taken = true;
				moveToPos4 = true;
			}
			else
			{
				Destroy (gameObject);
			}
		}
	}
}
