using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class plateZone : MonoBehaviour, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	private Vector3 startPos;
	public Camera mainCamera;
	public RectTransform readyHotdogRect;

	public bool bread = false;
	public GameObject draggableBreadObj;
	public GameObject sausageObj;
	public GameObject saladObj;
	public GameObject sauceObj;
	public GameObject grillObj;

	public int wienerI;
	public int saladI;
	public int sauceI;
	public bool salad;
	public bool sauce;
	public bool wiener;
	public bool breadBeDragged;

	//public GameObject[,] objects = new GameObject[3,3];
	public List<GameObject> allGrillSausageObjects = new List<GameObject>();
	public List<GameObject> allSaladObjects = new List<GameObject>();
	public List<GameObject> allSauceObjects = new List<GameObject>();

	void Update()
	{
		//if (bread != true)
		//{
		//	readyHotdogRect.sizeDelta = new Vector2 (250,150);
		//}
		//else
		//{
		//	readyHotdogRect.sizeDelta = new Vector2 (150,150);
		//}

	}
	public void OnDrop(PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			if (bread == true)
			{
				if (eventData.pointerDrag.tag == "sausageFromGrill" && sausageObj.GetComponent<Image>().color == Color.clear && eventData.pointerDrag.GetComponent<grillItem>().wiener == true && eventData.pointerDrag.GetComponent<Image>().sprite == eventData.pointerDrag.GetComponent<grillItem>().animSprites[1])
				{
					sausageObj.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<grillItem>().onDogSpriteReplace;
					sausageObj.GetComponent<Image>().color = Color.white;
					wienerI = eventData.pointerDrag.GetComponent<grillItem>().wienerId;
					wiener = true;

					eventData.pointerDrag.GetComponent<Image>().sprite = null;
					eventData.pointerDrag.GetComponent<Image>().color = Color.clear;
					eventData.pointerDrag.GetComponent<grillItem>().onDogSpriteReplace = null;
					eventData.pointerDrag.GetComponent<grillItem>().wienerId = 0;
					eventData.pointerDrag.GetComponent<grillItem>().wiener = false;
					eventData.pointerDrag.GetComponent<grillItem>().burnLevel = 0;
					eventData.pointerDrag.GetComponent<grillItem>().currentTime = 0f;
					eventData.pointerDrag.GetComponent<grillItem>().grillingTransTime = 5f;
				}
				if (eventData.pointerDrag.tag == "salad" && saladObj.GetComponent<Image>().color == Color.clear)
				{
					saladObj.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
					saladObj.GetComponent<Image>().color = Color.white;
					for (int i = 0; i <= allSaladObjects.Count; i++)
					{
						if (eventData.pointerDrag.gameObject == allSaladObjects[i])
						{
							if (allSaladObjects[i].GetComponent<draggableItem>().onDogSpriteReplace != null)
								saladObj.GetComponent<Image>().sprite = allSaladObjects[i].GetComponent<draggableItem>().onDogSpriteReplace;
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
							if (allSauceObjects[i].GetComponent<draggableItem>().onDogSpriteReplace != null)
								sauceObj.GetComponent<Image>().sprite = allSauceObjects[i].GetComponent<draggableItem>().onDogSpriteReplace;
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
				GetComponent<Image>().sprite = draggableBreadObj.GetComponent<Image>().sprite;
				if (draggableBreadObj.GetComponent<draggableItem>().onDogSpriteReplace != null)
					GetComponent<Image>().sprite = draggableBreadObj.GetComponent<draggableItem>().onDogSpriteReplace;
			}
	}
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			if (bread == true)
			{
				breadBeDragged = true;
				startPos = transform.position;
				GetComponent<CanvasGroup> ().blocksRaycasts = false;
				GetComponent<Image> ().color = Color.white;
			}
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			if (bread == true)
				transform.position = mainCamera.ScreenToWorldPoint (eventData.position) + Vector3.forward;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			breadBeDragged = false;
			transform.position = startPos;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}
}
