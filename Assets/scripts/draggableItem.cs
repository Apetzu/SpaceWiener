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

	public void OnBeginDrag (PointerEventData eventData)
	{
		startPos = transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	public void OnDrag(PointerEventData eventData)
	{
		transform.position = mainCamera.ScreenToWorldPoint (eventData.position) + Vector3.forward;
		GetComponent<Image>().color = Color.white;

	}
	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = startPos;
		if (isVisibleAllTime != true)
			GetComponent<Image>().color = Color.clear;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}


}
