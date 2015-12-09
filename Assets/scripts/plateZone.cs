using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class plateZone : MonoBehaviour, IDropHandler
{
	bool bread = false;
	public GameObject draggableBreadObj;
	public GameObject sausageObj;
	public GameObject saladObj;
	public GameObject sauceObj;

	public void OnDrop(PointerEventData eventData)
	{
		if (bread == true)
		{
			if (eventData.pointerDrag.tag == "sausage" && sausageObj.GetComponent<Image>().color == Color.clear)
			{
				sausageObj.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
				sausageObj.GetComponent<Image>().color = Color.white;
			}
			if (eventData.pointerDrag.tag == "salad" && saladObj.GetComponent<Image>().color == Color.clear)
			{
				saladObj.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
				saladObj.GetComponent<Image>().color = Color.white;
			}
			if (eventData.pointerDrag.tag == "sauce" && sauceObj.GetComponent<Image>().color == Color.clear)
			{
				sauceObj.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
				sauceObj.GetComponent<Image>().color = Color.white;
			}
		}

		if (eventData.pointerDrag.gameObject == draggableBreadObj)
		{
			bread = true;
			GetComponent<Image>().color = Color.white;
		}
	}
}
