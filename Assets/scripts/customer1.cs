using UnityEngine;
using System.Collections;

public class customer1 : MonoBehaviour {

	float speed = 5;
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
		}
		if (moveToPos2 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
		}
		if (moveToPos3 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target3.transform.position, speed);
		}
		if (moveToPos4 == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, target4.transform.position, speed);
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
