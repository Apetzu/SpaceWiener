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
	public GameObject draggableBreadObj;
	public Camera mainCamera;

	//Text moneyPaidTextClone;

	public float moneyPaid = 0;

	plateZone finishedBread;
	GameObject chosenCustomer;
	customer1 customerScript;
	customer2 customerScript2;
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
			if (hit.collider.gameObject.tag == "childCustomer")
			{
				customerScript2 = hit.transform.gameObject.GetComponent<customer2>();
			}
			else
			{
				customerScript = hit.transform.gameObject.GetComponent<customer1>();
			}
			chosenCustomer = hit.transform.gameObject;
			//child of child
			requestObj = hit.transform.gameObject.transform.Find("speechbubble1/request").gameObject;
			requestScript = requestObj.GetComponent<customerRequest>();
			//loooooooong long sentence that checks the values on customer request and the finished bread
			if (customerScript.canRecieveFood == true && finishedBread.bread == true)
			{
				if (requestScript.wienerI == finishedBread.wienerI  && finishedBread.wiener == true)
				{
					masterScript.moneyValue += 5;
					moneyPaid += 5;
					customerScript.timeLeft = 0;
					customerScript.correctIngredients += 1;
				}
				else
				{	
					customerScript.timeLeft = 0;
				}
				
				if (requestScript.salad == true && finishedBread.salad == true)
				{
					if (requestScript.saladI == finishedBread.saladI)
					{
						masterScript.moneyValue += 3;
						moneyPaid += 3;
						customerScript.correctIngredients += 1;
						customerScript.timeLeft = 0;
					}
					else
					{
						customerScript.timeLeft = 0;
					}
				}
				else if (requestScript.salad == true && finishedBread.salad == false)
				{
					customerScript.timeLeft = 0;
				}
				else if (requestScript.salad == false && finishedBread.salad == false)
				{
					customerScript.timeLeft = 0;
					customerScript.correctIngredients += 1;
				}
				else if (requestScript.salad == false && finishedBread.salad == true)
				{
					customerScript.timeLeft = 0;
				}
				
				if (requestScript.sauce == true && finishedBread.sauce == true)
				{
					if (requestScript.sauceI == finishedBread.sauceI)
					{
						masterScript.moneyValue += 1.5f;
						moneyPaid += 1.5f;
						customerScript.timeLeft = 0;
						customerScript.correctIngredients += 1;
					}
					else
					{
						customerScript.timeLeft = 0;
					}
				}
				else if (requestScript.sauce == true && finishedBread.sauce == false)
				{
					customerScript.timeLeft = 0;
				}
				else if (requestScript.sauce == false && finishedBread.sauce == false)
				{
					customerScript.timeLeft = 0;
					customerScript.correctIngredients += 1;
				}
				else if (requestScript.sauce == false && finishedBread.sauce == true)
				{
					customerScript.timeLeft = 0;
				}
				sausageObj.GetComponent<Image>().color = Color.clear;
				saladObj.GetComponent<Image>().color = Color.clear;
				sauceObj.GetComponent<Image>().color = Color.clear;
				draggableBreadObj.GetComponent<Image>().color = Color.clear;
				finishedBread.sauce = false;
				finishedBread.wiener = false;
				finishedBread.bread = false;
				finishedBread.salad = false;

				/* Tämä ei toimi se spawnautuu jonnekkin ihan muualle*/
				Text customerPaidCopy = (Text) Instantiate(moneyPaidText, Vector3.zero, transform.rotation);
				customerPaidCopy.gameObject.AddComponent<moneyPaidText>();
				customerPaidCopy.transform.SetParent(canvas.transform);
				customerPaidCopy.transform.localScale = new Vector3(1,1,1);
				customerPaidCopy.transform.position = chosenCustomer.transform.position;
				customerPaidCopy.text = ("Earned: " + moneyPaid);
				StartCoroutine("resetMoneyPaid");
			}
			else
			{
				Debug.Log ("customer is moving and cannot recieve food");
			}
		}
	}
	IEnumerator resetMoneyPaid()
	{
		yield return new WaitForSeconds(1.5f);
		moneyPaid = 0;
	}
}
	