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
			GetComponent<AudioSource>().Play();
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
			GetComponent<AudioSource>().Play();
			eventData.pointerDrag.GetComponent<Image>().sprite = null;
			eventData.pointerDrag.GetComponent<Image>().color = Color.clear;
			eventData.pointerDrag.GetComponent<grillItem>().onDogSpriteReplace = null;
			eventData.pointerDrag.GetComponent<grillItem>().wienerId = 0;
			eventData.pointerDrag.GetComponent<grillItem>().wiener = false;
			eventData.pointerDrag.GetComponent<grillItem>().burnLevel = 0;
			eventData.pointerDrag.GetComponent<grillItem>().currentTime = 0f;
		}
	}
}
