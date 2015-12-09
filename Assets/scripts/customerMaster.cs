﻿using UnityEngine;
using System.Collections;

public class customerMaster : MonoBehaviour {

	public bool pos1Taken = false;
	public bool pos2Taken = false;
	public bool pos3Taken = false;
	public bool pos4Taken = false;

	float side;

	public GameObject spawnerLeft;
	public GameObject spawnerRight;
	public GameObject[] customers;

	Vector3 waitPosition;
	
	void Start()
	{
		RollSide ();
	}
	void RollSide()
	{
		side = Random.value;
		SpawnCust ();
	}
	void SpawnCust()
	{
		if (side > 0.5)
		{
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,2)],spawnerLeft.transform.position, spawnerLeft.transform.rotation);
			customer1.gameObject.AddComponent<customer1>();
		}
		else
		{
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,2)],spawnerRight.transform.position, spawnerRight.transform.rotation);
			customer1.gameObject.AddComponent<customer1>();
		}
	}
}
