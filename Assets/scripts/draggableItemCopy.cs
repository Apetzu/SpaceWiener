using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class draggableItemCopy : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	private Vector3 startPos;

	public bool sauce;
	public bool salad;
	
	public int wienerI;
	public int sauceI;
	public int saladI;
	
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
