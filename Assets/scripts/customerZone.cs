﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class customerZone : MonoBehaviour, IDropHandler {

	public GameObject doneBread;
	public GameObject masterObj;
	GameObject requestObj;
	public Text moneyPaidText;
	public GameObject sausageObj;
	public GameObject saladObj;
	public GameObject sauceObj;
	public GameObject canvas;
	public GameObject draggableBreadObj;
	public GameObject timerMaster;
	public Camera mainCamera;

	timerMaster timerMasterScript;
	public float moneyPaid = 0;

	plateZone finishedBread;
	GameObject chosenCustomer;
	customer1 customerScript;
	customer2 customerScript2;
	customerRequest requestScript;
	customerMaster masterScript;
	
	void Start()
	{
		timerMasterScript = timerMaster.GetComponent<timerMaster> ();
		finishedBread = doneBread.GetComponent<plateZone> ();
		masterScript = masterObj.GetComponent<customerMaster>();
	}
	public void OnDrop(PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			//casts ray on object underneath mouse
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
			if (hit.collider != null && finishedBread.breadBeDragged == true)
			{
				chosenCustomer = hit.transform.gameObject;
				customerScript = chosenCustomer.transform.gameObject.GetComponent<customer1>();
				requestObj = hit.transform.gameObject.transform.Find("speechbubble1/request").gameObject;
				requestScript = requestObj.GetComponent<customerRequest>();
				// checks the values on customer request and the finished bread
				if (customerScript.canRecieveFood == true && finishedBread.bread == true)
				{
					finishedBread.breadBeDragged = false;
					//if requested wiener is the same as the wiener on the bread
					if (requestScript.wienerI == finishedBread.wienerI  && finishedBread.wiener == true)
					{
						masterScript.moneyValue += timerMasterScript.moneyForCorrectHotdog;
						moneyPaid += timerMasterScript.moneyForCorrectHotdog;
						customerScript.timeLeft = 0;
						customerScript.leaveBool = true;
						customerScript.correctIngredients += 1;
					}
					else
					{	
						customerScript.timeLeft = 0;
						customerScript.leaveBool = true;
					}
					
					if (requestScript.salad == true && finishedBread.salad == true)
					{
						if (requestScript.saladI == finishedBread.saladI)
						{
							masterScript.moneyValue += timerMasterScript.moneyForCorrectSalad;
							moneyPaid += timerMasterScript.moneyForCorrectSalad;
							customerScript.correctIngredients += 1;
							customerScript.timeLeft = 0;
							customerScript.leaveBool = true;
						}
						else
						{
							customerScript.timeLeft = 0;
							customerScript.leaveBool = true;
						}
					}
					else if (requestScript.salad == true && finishedBread.salad == false)
					{
						customerScript.timeLeft = 0;
						customerScript.leaveBool = true;
					}
					else if (requestScript.salad == false && finishedBread.salad == false)
					{
						customerScript.timeLeft = 0;
						customerScript.leaveBool = true;
						customerScript.correctIngredients += 1;
					}
					else if (requestScript.salad == false && finishedBread.salad == true)
					{
						customerScript.timeLeft = 0;
						customerScript.leaveBool = true;
					}
					
					if (requestScript.sauce == true && finishedBread.sauce == true)
					{
						if (requestScript.sauceI == finishedBread.sauceI)
						{
							masterScript.moneyValue += timerMasterScript.moneyForCorrectSauce;
							moneyPaid += timerMasterScript.moneyForCorrectSalad;
							customerScript.timeLeft = 0;
							customerScript.leaveBool = true;
							customerScript.correctIngredients += 1;
						}
						else
						{
							customerScript.timeLeft = 0;
							customerScript.leaveBool = true;
						}
					}
					else if (requestScript.sauce == true && finishedBread.sauce == false)
					{
						customerScript.timeLeft = 0;
						customerScript.leaveBool = true;
					}
					else if (requestScript.sauce == false && finishedBread.sauce == false)
					{
						customerScript.timeLeft = 0;
						customerScript.leaveBool = true;
						customerScript.correctIngredients += 1;
					}
					else if (requestScript.sauce == false && finishedBread.sauce == true)
					{
						customerScript.timeLeft = 0;
						customerScript.leaveBool = true;
					}
					sausageObj.GetComponent<Image>().color = Color.clear;
					saladObj.GetComponent<Image>().color = Color.clear;
					sauceObj.GetComponent<Image>().color = Color.clear;
					draggableBreadObj.GetComponent<Image>().color = Color.clear;
					finishedBread.sauce = false;
					finishedBread.wiener = false;
					finishedBread.bread = false;
					finishedBread.salad = false;
			
					Text customerPaidCopy = (Text) Instantiate(moneyPaidText, Vector3.zero, transform.rotation);
					customerPaidCopy.gameObject.AddComponent<moneyPaidText>();
					customerPaidCopy.transform.SetParent(canvas.transform);
					customerPaidCopy.transform.localScale = new Vector3(1,1,1);
					customerPaidCopy.transform.position = chosenCustomer.transform.position;
					customerPaidCopy.text = ("Earned: " + moneyPaid);
					if (moneyPaid != 0)
						customerPaidCopy.GetComponent<AudioSource> ().Play ();
					StartCoroutine("resetMoneyPaid");
				}
				else
				{
					Debug.Log ("customer is moving and cannot recieve food");
				}
			}
		}
	}
	IEnumerator resetMoneyPaid()
	{
		yield return new WaitForSeconds(1.5f);
		moneyPaid = 0;
	}
}
	