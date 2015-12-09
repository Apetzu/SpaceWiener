using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	private Vector3 startPos;

	public void OnBeginDrag (PointerEventData eventData)
	{
		startPos = transform.position;
		Debug.Log ("OnBegindDrag");
	}
	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;
		Debug.Log ("OnDrag");
		GetComponent<Image> ().color = Color.white;

	}
	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log ("OnEndDrag");
		transform.position = startPos;
		GetComponent<Image> ().color = Color.clear;

	}


}
