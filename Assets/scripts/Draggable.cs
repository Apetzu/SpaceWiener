using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	private Vector3 startPos;

	public void OnBeginDrag (PointerEventData eventData)
	{
		startPos = transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;
		GetComponent<Image>().color = Color.white;

	}
	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = startPos;
		GetComponent<Image>().color = Color.clear;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}


}
