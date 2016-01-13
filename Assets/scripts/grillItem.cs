using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class grillItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	private Vector3 startPos;
	public Sprite onDogSpriteReplace;
	public Camera mainCamera;

	public void OnBeginDrag (PointerEventData eventData)
	{
		startPos = transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	public void OnDrag(PointerEventData eventData)
	{
		transform.position = mainCamera.ScreenToWorldPoint (eventData.position) + Vector3.forward;
	}
	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = startPos;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
