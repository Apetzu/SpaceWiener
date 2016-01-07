using UnityEngine;
using System.Collections;

public class customer2 : MonoBehaviour {

	/*used for the blue alien
	 * that comes from below
	 * customer1 is used for 
	 * everything else*/

	float speed = 0.5f;
	float side;
	public float timeLeft = 8;
	int chosenPosition = 4;
	float lifeTime = 20;
	float timeLeftCopy = 0;
	public int position = 0;
	public float correctIngredients;
	
	BoxCollider2D customerColl;

	GameObject customerObj;
	GameObject speechBubble;
	GameObject tentacles;
	GameObject masterObj;
	GameObject target1;
	GameObject target2;
	GameObject target3;
	GameObject target4;
	
	Animator animator;
	
	SpriteRenderer custRend;
	SpriteRenderer speechBubRend;
	SpriteRenderer tentacleRend;
	
	public bool canRecieveFood;
	bool moveToPos1;
	bool moveToPos2;
	bool moveToPos3;
	bool moveToPos4;

	customerMaster masterScript;
	
	void Start () 
	{
		//gets customers collider, renderer, and speechbubble
		gameObject.tag = "Untagged";
		customerColl = transform.Find("customer2").GetComponent<BoxCollider2D> ();
		customerObj = gameObject.transform.Find("customer2").gameObject;
		custRend = transform.Find("customer2").GetComponent<SpriteRenderer> ();
		speechBubble = gameObject.transform.Find ("customer2/speechbubble1").gameObject;
		tentacleRend = GetComponent<SpriteRenderer>();
		//random time customer waits at its position
		timeLeft = Random.Range (10, 15);
		//copy of timeleft for face changing purposes
		timeLeftCopy = timeLeft;
		ChoosePos();
		side = Random.value;
		target1 = GameObject.FindWithTag ("custPosKid1");
		target2 = GameObject.FindWithTag ("custPosKid2");
		target3 = GameObject.FindWithTag ("custPosKid3");
		target4 = GameObject.FindWithTag ("custPosKid4");
		masterObj = GameObject.FindWithTag ("customerMaster");
		masterScript = masterObj.GetComponent<customerMaster>();
		SetPosition ();
		if (moveToPos1 == true)
		{
			transform.position = GameObject.FindWithTag("kidSpawner1").transform.position;
		}
		if (moveToPos2 == true)
		{
			transform.position = GameObject.FindWithTag("kidSpawner2").transform.position;
		}
		if (moveToPos3 == true)
		{
			transform.position = GameObject.FindWithTag("kidSpawner3").transform.position;
		}
		if (moveToPos4 == true)
		{
			transform.position = GameObject.FindWithTag("kidSpawner4").transform.position;
		}
	}
	void ChoosePos()
	{
		//chooses position customer takes max has to be 5 because unity rounds down 
		chosenPosition = Random.Range (1,5);
	}
	
	void FixedUpdate () 
	{
		if (moveToPos1 == true)
		{
			tentacleRend.enabled = true;
			//tells customer to move to its position
			customerObj.transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed);
			if (customerObj.transform.position == target1.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
				masterScript.pos1Taken = true;
				position = 1;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos2 == true)
		{
			tentacleRend.enabled = true;
			//tells customer to move to its position
			customerObj.transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
			if (customerObj.transform.position == target2.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
				masterScript.pos1Taken = true;
				position = 1;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos3 == true)
		{
			tentacleRend.enabled = true;
			//tells customer to move to its position
			customerObj.transform.position = Vector3.MoveTowards(transform.position, target3.transform.position, speed);
			if (customerObj.transform.position == target3.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
				masterScript.pos1Taken = true;
				position = 1;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos4 == true)
		{
			tentacleRend.enabled = true;
			//tells customer to move to its position
			customerObj.transform.position = Vector3.MoveTowards(transform.position, target4.transform.position, speed);
			if (customerObj.transform.position == target4.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
				masterScript.pos1Taken = true;
				position = 1;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (timeLeft < timeLeftCopy / 2.0f)
		{
			Animator animator = GetComponent<Animator>();
			animator.SetTrigger("angry");
		}
		//customer leaves and sets its position as free deletes collider
		if (timeLeft < 0)
		{
			if (position == 1)
			{
				customerColl.enabled = false;
				canRecieveFood = false;
				moveToPos1 = false;
				Leave ();
				masterScript.pos1Taken = false;
			}
			if (position == 2)
			{
				customerColl.enabled = false;
				canRecieveFood = false;
				moveToPos2 = false;
				Leave ();
				masterScript.pos2Taken = false;
			}
			if (position == 3)
			{
				customerColl.enabled = false;
				canRecieveFood = false;
				moveToPos3 = false;
				Leave ();
				masterScript.pos3Taken = false;
			}
			if (position == 4)
			{
				customerColl.enabled = false;
				canRecieveFood = false;
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
	public void Leave()
	{
		tentacleRend.enabled = false;
		Animator animator = GetComponent<Animator>();
		if (correctIngredients == 3)
		{
			animator.SetTrigger("happy");
		}
		else if (correctIngredients == 2)
		{
			animator.SetTrigger("angry");
		}
		else
		{
			animator.SetTrigger("leaving");
		}
		custRend.sortingOrder = -3;
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
