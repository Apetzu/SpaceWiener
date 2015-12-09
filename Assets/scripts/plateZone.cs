using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class plateZone : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log (eventData.pointerDrag);
	}
}
