using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class grill : MonoBehaviour, IDropHandler {
	
	public GameObject[] allGrillObjects = new GameObject[4];
	bool[] takenGrill;

	void Start()
	{
		takenGrill = new bool[allGrillObjects.Length];
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag.tag == "sausage") 
		{
			for (int i = 0; i < takenGrill.Length; i++) 
			{
				if (takenGrill[i] == false)
				{
					takenGrill[i] = true;
					allGrillObjects[i].GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<draggableItem>().onDogSpriteReplace;
					allGrillObjects[i].GetComponent<Image>().color = Color.white;
					allGrillObjects[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
					break;
				}
			}
		}
	}
}
