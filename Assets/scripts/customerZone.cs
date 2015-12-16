using UnityEngine;
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

	Text moneyPaidTextClone;

	public float moneyPaid = 0;

	plateZone finishedBread;
	GameObject chosenCustomer;
	customer1 customerScript;
	customerRequest requestScript;
	customerMaster masterScript;



	void Start()
	{
		finishedBread = doneBread.GetComponent<plateZone> ();
		masterScript = masterObj.GetComponent<customerMaster>();
	}
	public void OnDrop(PointerEventData eventData)
	{
		//casts ray on object underneath mouse
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
		if (hit.collider != null)
		{
			customerScript = hit.transform.gameObject.GetComponent<customer1>();
			chosenCustomer = hit.transform.gameObject;
			//child of child
			requestObj = hit.transform.gameObject.transform.Find("speechbubble1/request").gameObject;
			requestScript = requestObj.GetComponent<customerRequest>();
			//loooooooong long sentence that checks the values on customer request and the finished bread
			if (customerScript.canRecieveFood == true)
			{
				if (requestScript.wienerI == finishedBread.wienerI)
				{
					Debug.Log("this is the correct wiener");
					masterScript.moneyValue += 5;
					moneyPaid += 5;
					customerScript.timeLeft = 0;
					customerScript.correctIngredients += 1;
				}
				else
				{
					Debug.Log("this is the wrong wiener");		
					customerScript.timeLeft = 0;
				}
				
				if (requestScript.salad == true && finishedBread.salad == true)
				{
					if (requestScript.saladI == finishedBread.saladI)
					{
						Debug.Log("you gave the correct salad");

						masterScript.moneyValue += 3;
						moneyPaid += 3;
						customerScript.correctIngredients += 1;
						customerScript.timeLeft = 0;
					}
					else
					{
						Debug.Log ("you gave the wrong salad");
						customerScript.timeLeft = 0;
					}
				}
				else if (requestScript.salad == true && finishedBread.salad == false)
				{
					Debug.Log ("i wanted salad but you didnt give it to me");
					customerScript.timeLeft = 0;
				}
				else if (requestScript.salad == false && finishedBread.salad == false)
				{
					Debug.Log ("i didnt want salad and you didnt give it to me");
					customerScript.timeLeft = 0;
					customerScript.correctIngredients += 1;
				}
				else if (requestScript.salad == false && finishedBread.salad == true)
				{
					Debug.Log ("i didnt want salad and you gave it to me");
					customerScript.timeLeft = 0;
				}
				
				if (requestScript.sauce == true && finishedBread.salad == true)
				{
					if (requestScript.saladI == finishedBread.saladI)
					{
						Debug.Log ("you gave the correct sauce");
						masterScript.moneyValue += 1.5f;
						moneyPaid += 1.5f;
						customerScript.timeLeft = 0;
						customerScript.correctIngredients += 1;
					}
					else
					{
						Debug.Log("you gave the wrong sauce");
						customerScript.timeLeft = 0;
					}
				}
				else if (requestScript.sauce == true && finishedBread.sauce == false)
				{
					Debug.Log("i wanted sauce but you didnt give it to me");
					customerScript.timeLeft = 0;
				}
				else if (requestScript.sauce == false && finishedBread.sauce == false)
				{
					Debug.Log ("i didnt want sauce and you didnt give it to me");
					customerScript.timeLeft = 0;
					customerScript.correctIngredients += 1;
				}
				else if (requestScript.sauce == false && finishedBread.sauce == true)
				{
					Debug.Log ("i didnt want sauce but you gave it to me");
					customerScript.timeLeft = 0;
				}
				sausageObj.GetComponent<Image>().color = Color.clear;
				saladObj.GetComponent<Image>().color = Color.clear;
				sauceObj.GetComponent<Image>().color = Color.clear;
				finishedBread.sauce = false;
				finishedBread.salad = false;

				Text customerPaidCopy = (Text) Instantiate(moneyPaidText, chosenCustomer.transform.position, transform.rotation);
				customerPaidCopy.gameObject.AddComponent<moneyPaidText>();
				customerPaidCopy.transform.SetParent(canvas.transform);
				customerPaidCopy.transform.position = Input.mousePosition;
				customerPaidCopy.text = ("Earned: " + moneyPaid);
			}
			else
			{
				Debug.Log ("customer is moving and cannot recieve food");
			}
		}
	}
}
	