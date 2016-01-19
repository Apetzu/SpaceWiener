using UnityEngine;
using System.Collections;

public class customer1 : MonoBehaviour {


	/* Customer chooses position to go to and goes there
	 * speechbubble is displayed which shows what the customer wants
	 * deletes collider when customer leaves
	 */

	public Vector3 MoveVector = Vector3.up;
	public float MoveRange = 0.03f;
	public float bounceSpeed = 10f;
	public float MoveSpeed = 8f;
	public float yPosition = 0;
	public float direction = 0;
	public float minimum = 2.2f;
	public float maximum = 2.5f;
	public float colorSpeed = 0.5f;
	public float lerpTime = 0;

	public Color startColor;
	public Color currentColor;

	public Vector3 startScale;
	public Vector3 finalScale;

	public float speed = 5f;
	public float growSpeed = 3f;
	public float speedY = 5f;
	public float side;
	public float timeLeft = 8;
	public int chosenPosition = 0;
	public float lifeTime = 0;
	public float timeLeftCopy = 0;
	public int position = 0;
	public float correctIngredients;
	public float leaveDelay = 1;
	public float scaleX = 0f;
	
	public BoxCollider2D customerColl;

	public GameObject speechBubble;
	public GameObject masterObj;
	public GameObject chosenTarget;
	public GameObject target1;
	public GameObject target2;
	public GameObject target3;
	public GameObject target4;

	public Animator animator;

	public SpriteRenderer custRend;
	public SpriteRenderer speechBubRend;

	public bool canRecieveFood;
	public bool scaling;
	public bool inPlace;
	public bool moveToPos1;
	public bool moveToPos2;
	public bool moveToPos3;
	public bool moveToPos4;
	public bool fadeOut;
	//use this to call function in update only once
	//saves time to do 2 instead of using one shut up
	public bool updateFixer1;
	public bool updateFixer2;

	public customerMaster masterScript;
	
	public virtual void Start () 
	{
		//these change the customers bouncing
		if (gameObject.tag == "humanCustomer")
		{
			bounceSpeed = 18;
		}
		if (gameObject.tag == "pinkCustomer")
		{
			bounceSpeed = 12;
		}
		if (gameObject.tag == "grayCustomer")
		{
			bounceSpeed = 8;
		}
		if (gameObject.tag == "greenCustomer")
		{
			bounceSpeed = 15;
		}
		//gets customers collider, renderer, and speechbubble
		customerColl = GetComponent<BoxCollider2D> ();
		custRend = GetComponent<SpriteRenderer> ();
		speechBubble = gameObject.transform.Find ("speechbubble1").gameObject;
		//random time customer waits at its position
		timeLeft = Random.Range (25, 30);
		lifeTime = timeLeft + 20;
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
		if (transform.position.x >= chosenTarget.transform.position.x)
		{
			speed = -speed;
		}
		startScale = transform.localScale;
		direction = transform.position.y - chosenTarget.transform.position.y;
		startColor = custRend.color;
		custRend.sortingOrder = masterScript.customerLayerOrder;
	}
	public void ChoosePos()
	{
		//chooses position customer takes max has to be 5 because unity rounds down (i think)
		chosenPosition = Random.Range (1,5);
	}
	public virtual void CustomerMoveFunction()
	{
		transform.position = new Vector2(transform.position.x + Time.fixedDeltaTime * speed ,transform.position.y + Mathf.Sin (Time.timeSinceLevelLoad * bounceSpeed) * MoveRange);
	}
	public void CustomerIsInPlace ()
	{
		if (speed > 0 && transform.position.x > chosenTarget.transform.position.x)
		{
			MoveRange = 0;
			speed = 0;
			scaling = true;
		}
		else if (speed < 0 && transform.position.x < chosenTarget.transform.position.x)
		{
			MoveRange = 0;
			speed = 0;
			scaling = true;
		}
	}
	public virtual void FixedUpdate () 
	{
		if (scaling == true && transform.localScale.x <= 2.45f)
		{
			lerpTime = colorSpeed * Time.fixedDeltaTime;
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(maximum, maximum, maximum), Time.fixedDeltaTime * growSpeed);
			custRend.color = Color.Lerp(custRend.color,new Color (255,255,255), Time.fixedDeltaTime * lerpTime);
		}
		CustomerIsInPlace ();
		CustomerMoveFunction();
		if (speed == 0 && transform.localScale.x >= 2.44f)
		{
			//shows speechbubble and its contents sets customer able to recieve food
			customerColl.enabled = true;
			canRecieveFood = true;
			custRend.sortingOrder = -1;
			position = chosenPosition;
			speechBubble.SetActive(true);
			timeLeft -= Time.fixedDeltaTime;
		}
		else
		{
			custRend.sortingOrder = masterScript.customerLayerOrder + 1;
			if (updateFixer1 != true)
			{
				masterScript.customerLayerOrder += 1;
				updateFixer1 = true;
			}
		}
		if (timeLeft < timeLeftCopy / 2.0f)
		{
			Animator animator = GetComponent<Animator>();
			animator.SetBool("angry",true);
			animator.SetBool("happy",false);
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
		lifeTime -= Time.fixedDeltaTime;
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
		custRend.sortingLayerName = "Default";
		colorSpeed = 5f;
		fadeOut = true;
		currentColor = custRend.color;
		if (chosenPosition == 1)
		{
			masterScript.pos1Taken = false;
		}
		if (chosenPosition == 2)
		{
			masterScript.pos2Taken = false;
		}
		if (chosenPosition == 3)
		{
			masterScript.pos3Taken = false;
		}
		if (chosenPosition == 4)
		{
			masterScript.pos4Taken = false;
		}
		speed = 5;
		MoveRange = 0.03f;
		Animator animator = GetComponent<Animator>();
		if (correctIngredients == 3)
		{
			animator.SetBool("happy",true);
			animator.SetBool("angry",false);
			animator.SetBool("leaving",false);
		}
		else if (correctIngredients == 2)
		{
			animator.SetBool("happy",false);
			animator.SetBool("angry",true);
			animator.SetBool("leaving",false);
		}
		else
		{
			animator.SetBool("happy",false);
			animator.SetBool("angry",false);
			animator.SetBool("leaving",true);
		}
		custRend.sortingOrder = masterScript.customerLayerOrder + 1;
		//this makes it so customerLayerOrder is changed only once even if Leave() is called in FixedUpdate
		if (updateFixer2 != true)
		{
			masterScript.customerLayerOrder += 1;
			updateFixer2 = true;
		}
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
	public void SetPosition()
	{
		if (masterScript.pos1Taken == true && masterScript.pos2Taken == true && masterScript.pos3Taken == true && masterScript.pos4Taken == true)
		{
			Destroy(gameObject);
		}
		else if (chosenPosition == 1)
		{
			//this sets the chosen position as taken and moves customer to the position if chosen position is taken customer is destroyed
			chosenTarget = target1;
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
			chosenTarget = target2;
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
			chosenTarget = target3;
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
			chosenTarget = target4;
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
