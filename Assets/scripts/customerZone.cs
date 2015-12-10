using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class customerZone : MonoBehaviour, IDropHandler {

	public GameObject doneBread;
	draggableItem finishedBread;

	void Start()
	{
		finishedBread = doneBread.GetComponent<draggableItem> ();
	}
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log (eventData.pointerDrag.name);
		//Debug.Log (eventData.pointerDrag.doneBread.testFloat);

	}
}
