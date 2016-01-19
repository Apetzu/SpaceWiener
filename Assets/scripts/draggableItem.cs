using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class draggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	private Vector3 startPos;
	public Sprite onDogSpriteReplace;
	public Camera mainCamera;
	public bool isVisibleAllTime;
	public Sprite[] animSprites;

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			startPos = transform.position;
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}
	public void OnDrag(PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			transform.position = mainCamera.ScreenToWorldPoint (eventData.position) + Vector3.forward;
			GetComponent<Image>().color = Color.white;
		}
	}
	public void OnEndDrag(PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			transform.position = startPos;
			if (isVisibleAllTime != true)
				GetComponent<Image>().color = Color.clear;
			GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
	}


}
