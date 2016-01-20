using UnityEngine;
using System.Collections;

public class customer2 : customer1 {

	/*inherits stuff from customer 1 and overrides some of it 
	 * used for blue child aluen*/
		
	public GameObject tentacles;
	public SpriteRenderer tentacleRend;

	float speedRising = 0.1f;
	new public float bounceSpeed = 28f;
	new public float speed = 0.2f;
	bool speechbubbleSound = false;
	
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
	//use this if you want tentacles to show betterly
	//public void Update ()
	//{
	//	Debug.Log (Time.timeScale);
	//	if (Time.timeScale != 0)
	//	{
	//		tentacleRend.sortingOrder = 10;
	//	}
	//	else
	//	{
	//		tentacleRend.sortingOrder = 1;
	//	}
	//}
	public override void CustomerMoveFunction()
	{
		transform.position = new Vector2(transform.position.x + Time.fixedDeltaTime * 5 ,transform.position.y + Mathf.Sin (Time.timeSinceLevelLoad * bounceSpeed) * MoveRange);
	}
	public override void FixedUpdate () 
	{
		if (moveToPos1 == true)
		{
			tentacleRend.enabled = true;
			transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speedRising);
			if (transform.position == target1.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				masterScript.pos1Taken = true;
				position = 1;
				speechBubbleDelay -= Time.fixedDeltaTime;
				if (speechBubbleDelay <= 0)
				{
					speechBubble.SetActive(true);
				}
				timeLeft -= Time.deltaTime;
				custRend.sortingOrder = -4;
				if (speechbubbleSound == false)
				{
					speechBubble.GetComponent<AudioSource>().Play();
					speechbubbleSound = true;
				}
				GetComponent<AudioSource>().clip = masterScript.childCustomerSounds[0];
				GetComponent<AudioSource>().Play();
			}
		}
		if (moveToPos2 == true)
		{
			tentacleRend.enabled = true;
			transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speedRising);
			if (transform.position == target2.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -4;
				masterScript.pos2Taken = true;
				position = 2;
				speechBubbleDelay -= Time.fixedDeltaTime;
				if (speechBubbleDelay <= 0)
				{
					speechBubble.SetActive(true);
				}
				timeLeft -= Time.deltaTime;
				if (speechbubbleSound == false)
				{
					speechBubble.GetComponent<AudioSource>().Play();
					speechbubbleSound = true;
				}
				GetComponent<AudioSource>().clip = masterScript.childCustomerSounds[0];
				GetComponent<AudioSource>().Play();
			}
		}
		if (moveToPos3 == true)
		{
			tentacleRend.enabled = true;
			transform.position = Vector3.MoveTowards(transform.position, target3.transform.position, speedRising);
			if (transform.position == target3.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -4;
				masterScript.pos3Taken = true;
				position = 3;
				speechBubbleDelay -= Time.fixedDeltaTime;
				if (speechBubbleDelay <= 0)
				{
					speechBubble.SetActive(true);
				}
				timeLeft -= Time.deltaTime;
				if (speechbubbleSound == false)
				{
					speechBubble.GetComponent<AudioSource>().Play();
					speechbubbleSound = true;
				}
				GetComponent<AudioSource>().clip = masterScript.childCustomerSounds[0];
				GetComponent<AudioSource>().Play();
			}
		}
		if (moveToPos4 == true)
		{
			tentacleRend.enabled = true;
			transform.position = Vector3.MoveTowards(transform.position, target4.transform.position, speedRising);
			if (transform.position == target4.transform.position)
			{
				//shows speechbubble and its contents sets customer able to recieve food
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -4;
				masterScript.pos4Taken = true;
				position = 4;
				speechBubbleDelay -= Time.fixedDeltaTime;
				if (speechBubbleDelay <= 0)
				{
					speechBubble.SetActive(true);
				}
				timeLeft -= Time.deltaTime;
				if (speechbubbleSound == false)
				{
					speechBubble.GetComponent<AudioSource>().Play();
					speechbubbleSound = true;
				}
				GetComponent<AudioSource>().clip = masterScript.childCustomerSounds[0];
				GetComponent<AudioSource>().Play();
			}
		}
		if (timeLeft < timeLeftCopy / 2.0f)
		{
			Animator animator = GetComponent<Animator>();
			animator.SetTrigger("angry");
			GetComponent<AudioSource>().clip = masterScript.childCustomerSounds[1];
			GetComponent<AudioSource>().Play();
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
		speechbubbleSound = false;
		colorSpeed = 4f;
		tentacleRend.enabled = false;
		Animator animator = GetComponent<Animator>();
		if (correctIngredients == 3)
		{
			animator.SetBool("happy",true);
			animator.SetBool("angry",false);
			animator.SetBool("leaving",false);
			GetComponent<AudioSource>().clip = masterScript.childCustomerSounds[0];
			GetComponent<AudioSource>().Play();
		}
		else if (correctIngredients == 2)
		{
			animator.SetBool("happy",false);
			animator.SetBool("angry",true);
			animator.SetBool("leaving",false);
			GetComponent<AudioSource>().clip = masterScript.childCustomerSounds[1];
			GetComponent<AudioSource>().Play();
		}
		else
		{
			animator.SetBool("happy",false);
			animator.SetBool("angry",false);
			animator.SetBool("leaving",true);
			GetComponent<AudioSource>().clip = masterScript.childCustomerSounds[2];
			GetComponent<AudioSource>().Play();
		}
		custRend.sortingOrder = -1;
		if (side > 0.5)
		{
			scaling = false;
			leaveDelay -= Time.deltaTime;
			if (leaveDelay <= 0)
			{
				CustomerMoveFunction();
			}
			if (leaveDelay >= 0.2)
			{
				//makes customers scale smaller + darkens its color
				transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(minimum, minimum, minimum), Time.fixedDeltaTime * growSpeed);
				lerpTime += colorSpeed * Time.fixedDeltaTime;
				custRend.color = Color.Lerp(custRend.color,new Color(0,0,0,1), Time.fixedDeltaTime * lerpTime);
			}
		}
		else
		{
			scaling = false;
			leaveDelay -= Time.deltaTime;
			if (leaveDelay <= 0)
			{
				CustomerMoveFunction();
			}
			if (leaveDelay >= 0.2)
			{
				transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(minimum, minimum, minimum), Time.fixedDeltaTime * growSpeed);
				lerpTime += colorSpeed * Time.fixedDeltaTime;
				custRend.color = Color.Lerp(custRend.color,new Color(0,0,0,1), Time.fixedDeltaTime * lerpTime);
			}
		}
		transform.GetChild(0).gameObject.SetActive(false);
	}
}
