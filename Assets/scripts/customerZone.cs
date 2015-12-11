using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class customerZone : MonoBehaviour, IDropHandler {

	public GameObject doneBread;
	draggableItemCopy finishedBread;
	customer1 customerScript;
	GameObject requestObj;
	customerRequest requestScript;

	void Start()
	{
		finishedBread = doneBread.GetComponent<draggableItemCopy> ();

	}
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log (eventData.pointerDrag.name);

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
		if (hit.collider != null)
		{
			customerScript = hit.transform.gameObject.GetComponent<customer1>();
			requestObj = hit.transform.gameObject.transform.Find("speechbubble1/request").gameObject;
			requestScript = requestObj.GetComponent<customerRequest>();

			if (requestScript.wienerI == finishedBread.wienerI)
			{
				Debug.Log("this is the correct wiener");
			}
			else
			{
				Debug.Log("this is the wrong wiener");		
			}

			if (requestScript.salad == true && finishedBread.salad == true)
			{
				if (requestScript.saladI == finishedBread.saladI)
				{
					Debug.Log("you gave the correct salad");
				}
				else
				{
					Debug.Log ("you gave the wrong salad");
				}
			}
			else if (requestScript.salad == true && finishedBread.salad == false)
			{
				Debug.Log ("i wanted salad but you didnt give it to me");
			}
			else if (requestScript.salad == false && finishedBread.salad == false)
			{
				Debug.Log ("i didnt want salad and you didnt give it to me");
			}
			else if (requestScript.salad == false && finishedBread.salad == true)
			{
				Debug.Log ("i didnt want salad and you gave it to me");
			}

			if (requestScript.sauce == true && finishedBread.salad == true)
			{
				if (requestScript.saladI == finishedBread.saladI)
				{
					Debug.Log ("you gave the correct sauce");
				}
				else
				{
					Debug.Log("you gave the wrong sauce");
				}
			}
			else if (requestScript.sauce == true && finishedBread.sauce == false)
			{
				Debug.Log("i wanted sauce but you didnt give it to me");
			}
			else if (requestScript.sauce == false && finishedBread.sauce == false)
			{
				Debug.Log ("i didnt want sauce and you didnt give it to me");
			}
			else if (requestScript.sauce == false && finishedBread.sauce == true)
			{
				Debug.Log ("i didnt want sauce but you gave it to me");
			}
		}
	}
}
	