using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class plateZone : MonoBehaviour, IDropHandler
{
	private Vector3 startPos;

	bool bread = false;
	public GameObject draggableBreadObj;
	public GameObject sausageObj;
	public GameObject saladObj;
	public GameObject sauceObj;

	public int wienerI;
	public int saladI;
	public int sauceI;
	public bool salad;
	public bool sauce;

	//public GameObject[,] objects = new GameObject[3,3];
	public List<GameObject> allSausageObjects = new List<GameObject>();
	public List<GameObject> allSaladObjects = new List<GameObject>();
	public List<GameObject> allSauceObjects = new List<GameObject>();
	
	public void OnDrop(PointerEventData eventData)
	{
		if (bread == true)
		{
			if (eventData.pointerDrag.tag == "sausage" && sausageObj.GetComponent<Image>().color == Color.clear)
			{
				sausageObj.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
				sausageObj.GetComponent<Image>().color = Color.white;
				for (int i = 0; i <= allSausageObjects.Count; i++)
				{
					if (eventData.pointerDrag.gameObject == allSausageObjects[i])
					{
						wienerI = i;
						break;
					}
				}
			}
			if (eventData.pointerDrag.tag == "salad" && saladObj.GetComponent<Image>().color == Color.clear)
			{
				saladObj.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
				saladObj.GetComponent<Image>().color = Color.white;
				for (int i = 0; i <= allSaladObjects.Count; i++)
				{
					if (eventData.pointerDrag.gameObject == allSaladObjects[i])
					{
						salad = true;
						saladI = i;
						break;
					}
				}
			}
			if (eventData.pointerDrag.tag == "sauce" && sauceObj.GetComponent<Image>().color == Color.clear)
			{
				sauceObj.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
				sauceObj.GetComponent<Image>().color = Color.white;
				for (int i = 0; i <= allSauceObjects.Count; i++)
				{
					if (eventData.pointerDrag.gameObject == allSauceObjects[i])
					{
						sauce = true;
						sauceI = i;
						break;
					}
				}
			}
		}

		if (eventData.pointerDrag.gameObject == draggableBreadObj)
		{
			bread = true;
			GetComponent<Image>().color = Color.white;
		}
	}
}
