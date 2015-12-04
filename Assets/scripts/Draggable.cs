using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	private Vector3 startPos;

	void Start()
	{
		print (transform.position);
		startPos = transform.position;
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		Debug.Log ("OnBegindDrag");
	}
	public void OnDrag(PointerEventData eventData)
	{
		this.transform.position = eventData.position;
		Debug.Log ("OnDrag");
		this.GetComponent<Image> ().color = Color.white;

	}
	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log ("OnEndDrag");
		this.transform.position = startPos;
		this.GetComponent<Image> ().color = Color.clear;

	}


}
