﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class customerMaster : MonoBehaviour {

	/* this script sets customer spawn side
	 * spawns random customer from array on either left or right
	 */
	public Text moneyText;
	public Text timer;
	public Text winText;
	public Text numberOfCustsAngeredText;
	public Text numberOfCustsServedText;
	public Text timer2;
	public Text numberOfWienersBurnedText;
	public Text numberOfTrashesText;
	//public Button creditsButton;

	public bool pos1Taken = false;
	public bool pos2Taken = false;
	public bool pos3Taken = false;
	public bool pos4Taken = false;
	public bool gameLost;

	float side;
	public float moneyValue = 0;
	float endTimer = 121;
	public float numberOfCustsAngered = 0f;
	public float numberOfCustsServed = 0f;
	public float numberOfTrashes = 0f;
	public float numberOfWienersBurned = 0f;

	public GameObject spawnerLeft;
	public GameObject spawnerRight;
	public GameObject[] customers;
	public GameObject timerMaster;
	public GameObject victory;
	public GameObject gameOver;
	public GameObject shutter;
	public GameObject canvas1;
	public GameObject canvas2;

	public AudioClip[] humanCustomerSounds;
	public AudioClip[] childCustomerSounds;
	public AudioClip[] pinkCustomerSounds;
	public AudioClip[] grayCustomerSounds;
	public AudioClip[] greenCustomerSounds;

	Vector3 waitPosition;
	timerMaster timerMasterScript;
	shutterScript shutterScript;

	void FixedUpdate()
	{
		endTimer = endTimer - Time.fixedDeltaTime;
		moneyText.text = ("Money: "+moneyValue+"/"+timerMasterScript.moneyNeededForWin);
		timer.text = ("Time left: "+ (int) (endTimer));
		timer2.text = ("Time left: "+ (int) (endTimer));
		if (moneyValue >= timerMasterScript.moneyNeededForWin /*replace with wanted number */)
		{
			StartCoroutine(endDelay());
		}
		if (endTimer <= 0)
		{
			StartCoroutine(endDelay());
			gameLost = true;
		}
	}
	IEnumerator endDelay()
	{
		yield return new WaitForSeconds (0.5f);
		if (gameLost == true)
		{
			shutterScript.gameOver = true;
			numberOfCustsServedText.text = ("Customers served: "+numberOfCustsServed);
			numberOfWienersBurnedText.text = ("Wieners burned: "+numberOfWienersBurned);
			numberOfTrashesText.text = ("Objects put in trash: "+numberOfTrashes);
			numberOfCustsAngeredText.text = ("Customers angered: "+numberOfCustsAngered);
			canvas1.SetActive(false);
			canvas2.SetActive(true);
			gameOver.gameObject.SetActive(true);
			gameOver.GetComponent<AudioSource>().Play();
			winText.text = ("You got "+moneyValue+"/"+timerMasterScript.moneyNeededForWin+" money");
			shutterScript.MoveShutterDown();
		}
		else
		{
			shutterScript.gameOver = true;
			numberOfCustsServedText.text = ("Customers served: "+numberOfCustsServed);
			numberOfWienersBurnedText.text = ("Wieners burned: "+numberOfWienersBurned);
			numberOfTrashesText.text = ("Objects put in trash: "+numberOfTrashes);
			numberOfCustsAngeredText.text = ("Customers angered: "+numberOfCustsAngered);
			canvas1.SetActive(false);
			canvas2.SetActive(true);
			victory.gameObject.SetActive(true);
			victory.GetComponent<AudioSource>().Play();
			winText.text = ("You got "+moneyValue+"/"+timerMasterScript.moneyNeededForWin+" money");
			shutterScript.MoveShutterDown();
		}


	}
	void Start()
	{
		shutterScript = shutter.gameObject.GetComponent<shutterScript>();
		timerMasterScript = timerMaster.GetComponent<timerMaster> ();
		endTimer = timerMasterScript.gameTime;
		StartCoroutine (spawnCust());
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
			//spawn random customer on left side from array and applies customer script to it
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,5)],spawnerLeft.transform.position, spawnerLeft.transform.rotation);
			if (customer1.gameObject.tag == "childCustomer")
			{
				customer1.gameObject.AddComponent<customer2>();
			}
			else
			{
				customer1.gameObject.AddComponent<customer1>();
			}
		}
		else
		{
			//spawn random customer on right side from array and applies customer script to it
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,5)],spawnerRight.transform.position, spawnerRight.transform.rotation);
			if (customer1.gameObject.tag == "childCustomer")
			{
				customer1.gameObject.AddComponent<customer2>();
			}
			else
			{
				customer1.gameObject.AddComponent<customer1>();
			}
		}
	}
	IEnumerator spawnCust()
	{
		//spawns customer every 1-3 seconds
		while (true)
		{
			yield return new WaitForSeconds(1);
			RollSide ();
			yield return new WaitForSeconds(Random.Range(timerMasterScript.timeBetweenCustomerSpawnMin,timerMasterScript.timeBetweenCustomerSpawnMax));
		}
	}
}
