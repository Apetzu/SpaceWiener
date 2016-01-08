using UnityEngine;
using System.Collections;

public class customer1 : MonoBehaviour {


	/* Customer chooses position to go to and goes there
	 * speechbubble is displayed which shows what the customer wants
	 * deletes collider when customer leaves
	 */

	public float speed = 0.5f;
	public float side;
	public float timeLeft = 8;
	public int chosenPosition = 4;
	public float lifeTime = 0;
	public float timeLeftCopy = 0;
	public int position = 0;
	public float correctIngredients;

	public BoxCollider2D customerColl;

	public GameObject speechBubble;
	public GameObject masterObj;
	public GameObject target1;
	public GameObject target2;
	public GameObject target3;
	public GameObject target4;

	public Animator animator;

	public SpriteRenderer custRend;
	public SpriteRenderer speechBubRend;

	public bool canRecieveFood;
	public bool moveToPos1;
	public bool moveToPos2;
	public bool moveToPos3;
	public bool moveToPos4;

	public customerMaster masterScript;
	
	public virtual void Start () 
	{
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
		target1 = GameObject.FindWithTag ("custPos1");
		target2 = GameObject.FindWithTag ("custPos2");
		target3 = GameObject.FindWithTag ("custPos3");
		target4 = GameObject.FindWithTag ("custPos4");
		masterObj = GameObject.FindWithTag ("customerMaster");
		masterScript = masterObj.GetComponent<customerMaster>();
		SetPosition ();
	}
	public void ChoosePos()
	{
		//chooses position customer takes max has to be 5 because unity rounds down (i think)
		chosenPosition = Random.Range (1,5);
		//SetPosition ();
	}
	public virtual void FixedUpdate () 
	{
		if (moveToPos1 == true)
		{
			//tells customer to move to its position
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
			transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
			if (transform.position == target2.transform.position)
			{
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
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
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
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
				customerColl.enabled = true;
				canRecieveFood = true;
				custRend.sortingOrder = -1;
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
	//Leave chooses side customer will leave to and deletes the speechbubble + sets customer sorting layer to -3
	public virtual void Leave()
	{
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
			transform.Translate(Vector2.left * speed);
		}
		else
		{
			transform.Translate(Vector2.right * speed);
		}
		transform.GetChild(0).gameObject.SetActive(false);
	}
	public void SetPosition()
	{
		if (masterScript.pos1Taken == true && masterScript.pos2Taken == true && masterScript.pos3Taken == true && masterScript.pos4Taken == true)
		{
			Destroy(gameObject);
		}
		else if (chosenPosition == 1)
		{
			//this sets the chosen position as taken and moves customer to the position if chosen position is taken customer is destroyed
			if (masterScript.pos1Taken == false)
			{
				masterScript.pos1Taken = true;
				moveToPos1 = true;
			}
			else
			{
				chosenPosition = 4;
				SetPosition();
			}
		}
		else if (chosenPosition == 2)
		{
			if (masterScript.pos2Taken == false)
			{
				masterScript.pos2Taken = true;
				moveToPos2 = true;
			}
			else
			{
				chosenPosition = 3;
				SetPosition();
			}
		}
		else if (chosenPosition == 3)
		{
			if (masterScript.pos3Taken == false)
			{
				masterScript.pos3Taken = true;
				moveToPos3 = true;
			}
			else
			{
				chosenPosition = 1;
				SetPosition();
			}
		}
		else if (chosenPosition == 4)
		{
			if (masterScript.pos4Taken == false)
			{
				masterScript.pos4Taken = true;
				moveToPos4 = true;
			}
			else
			{
				chosenPosition = 2;
				SetPosition();
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
