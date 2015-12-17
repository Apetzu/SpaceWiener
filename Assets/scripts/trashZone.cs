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

	void Start()
	{
		finishedBread = doneBread.GetComponent<plateZone> ();
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag == doneBread)
		{
			sausageObj.GetComponent<Image> ().color = Color.clear;
			saladObj.GetComponent<Image> ().color = Color.clear;
			sauceObj.GetComponent<Image> ().color = Color.clear;
			draggableBreadObj.GetComponent<Image> ().color = Color.clear;
			finishedBread.sauce = false;
			finishedBread.wiener = false;
			finishedBread.bread = false;
			finishedBread.salad = false;
		}
	}
}
