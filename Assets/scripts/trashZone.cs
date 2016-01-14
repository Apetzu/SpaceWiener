using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class trashZone : MonoBehaviour, IDropHandler {

	public GameObject sausageObj;
	public GameObject saladObj;
	public GameObject sauceObj;
	public GameObject draggableBreadObj;
	plateZone finishedBread;
	public GameObject doneBread;
	public GameObject canvas;
	float tempMoneyValue;
	public Text moneyPaidText;
	public GameObject grillObj;

	void Start()
	{
		finishedBread = doneBread.GetComponent<plateZone> ();
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag == doneBread)
		{
			/*if (doneBread.GetComponent<plateZone>().wiener == true)
				tempMoneyValue += 5f;
			if (doneBread.GetComponent<plateZone>().salad == true)
				tempMoneyValue += 3f;
			if (doneBread.GetComponent<plateZone>().sauce == true)
				tempMoneyValue += 1.15f;

			GameObject.FindWithTag("customerMaster").GetComponent<customerMaster>().moneyValue -= tempMoneyValue;

			Text customerPaidCopy = (Text) Instantiate(moneyPaidText, Vector3.zero, transform.rotation);
			customerPaidCopy.gameObject.AddComponent<moneyPaidText>();
			customerPaidCopy.transform.SetParent(canvas.transform);
			customerPaidCopy.transform.localScale = new Vector3(1,1,1);
			customerPaidCopy.transform.position = new Vector2 (transform.position.x - 3f, transform.position.y);
			customerPaidCopy.text = ("Money lost: " + tempMoneyValue);
			tempMoneyValue = 0;*/

			sausageObj.GetComponent<Image> ().color = Color.clear;
			saladObj.GetComponent<Image> ().color = Color.clear;
			sauceObj.GetComponent<Image> ().color = Color.clear;
			draggableBreadObj.GetComponent<Image> ().color = Color.clear;
			finishedBread.sauce = false;
			finishedBread.wiener = false;
			finishedBread.bread = false;
			finishedBread.salad = false;
		}

		if (eventData.pointerDrag.tag == "sausageFromGrill") 
		{
			eventData.pointerDrag.GetComponent<Image>().sprite = null;
			eventData.pointerDrag.GetComponent<Image>().color = Color.clear;
			eventData.pointerDrag.GetComponent<grillItem>().onDogSpriteReplace = null;
			eventData.pointerDrag.GetComponent<grillItem>().wienerId = 0;
			eventData.pointerDrag.GetComponent<grillItem>().wiener = false;
		}
	}
}
