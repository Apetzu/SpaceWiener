using UnityEngine;
using System.Collections;

public class customer2 : customer1 {
	
		
	public GameObject tentacles;
	public SpriteRenderer tentacleRend;

	new public float speed = 0.3f;

	// Use this for initialization
	public override void Start () 
	{
		tentacles = transform.Find ("customer2Tentacles").gameObject;
		tentacleRend = tentacles.GetComponent<SpriteRenderer> ();
		//gets customers collider, renderer, and speechbubble
		customerColl = GetComponent<BoxCollider2D> ();
		custRend = GetComponent<SpriteRenderer> ();
		speechBubble = gameObject.transform.Find ("speechbubble1").gameObject;
		//random time customer waits at its position
		timeLeft = Random.Range (25, 30);
		lifeTime = timeLeft + 5;
		//copy of timeleft for face changing purposes
		timeLeftCopy = timeLeft;
		ChoosePos();
		side = Random.value;
		Debug.Log ("customer2 script is activated");
		target1 = GameObject.FindWithTag ("custPosKid1");
		target2 = GameObject.FindWithTag ("custPosKid2");
		target3 = GameObject.FindWithTag ("custPosKid3");
		target4 = GameObject.FindWithTag ("custPosKid4");
		masterObj = GameObject.FindWithTag ("customerMaster");
		masterScript = masterObj.GetComponent<customerMaster>();
		SetPosition ();
		if (moveToPos1 == true)
		{
			transform.position = GameObject.FindWithTag("kidSpawner1").gameObject.transform.position;
		}
		if (moveToPos2 == true)
		{
			transform.position = GameObject.FindWithTag("kidSpawner2").gameObject.transform.position;
		}
		if (moveToPos3 == true)
		{
			transform.position = GameObject.FindWithTag("kidSpawner3").gameObject.transform.position;
		}
		if (moveToPos4 == true)
		{
			transform.position = GameObject.FindWithTag("kidSpawner4").gameObject.transform.position;
		}
		tentacles.AddComponent<tentacles>();
	}
	
	// Update is called once per frame
	public override void FixedUpdate () 
	{
		if (moveToPos1 == true)
		{
			tentacleRend.enabled = true;
			transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed);
			if (transform.position == target1.transform.position)
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
			transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
			if (transform.position == target2.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
				masterScript.pos1Taken = true;
				position = 2;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos3 == true)
		{
			tentacleRend.enabled = true;
			transform.position = Vector3.MoveTowards(transform.position, target3.transform.position, speed);
			if (transform.position == target3.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
				masterScript.pos1Taken = true;
				position = 3;
				speechBubble.SetActive(true);
				timeLeft -= Time.deltaTime;
			}
		}
		if (moveToPos4 == true)
		{
			tentacleRend.enabled = true;
			transform.position = Vector3.MoveTowards(transform.position, target4.transform.position, speed);
			if (transform.position == target4.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
				masterScript.pos1Taken = true;
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
	public override void Leave()
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
		if (side > 0.5)
		{
			transform.Translate(Vector2.right * speed);
		}
		else
		{
			transform.Translate(Vector2.left * speed);
		}
		transform.GetChild(0).gameObject.SetActive(false);
	}
}
