using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class grill : MonoBehaviour, IDropHandler {
	
	public GameObject[] allGrillObjects = new GameObject[4];
	public bool[] takenGrill;
	public List<GameObject> allSausageObjects = new List<GameObject>();

	void Start()
	{
		takenGrill = new bool[allGrillObjects.Length];
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag.tag == "sausage") 
		{
			for (int o = 0; o <= allSausageObjects.Count; o++)
			{
				if (eventData.pointerDrag.gameObject == allSausageObjects[o])
				{
					for (int i = 0; i < takenGrill.Length; i++) 
					{
						if (takenGrill[i] == false)
						{
							takenGrill[i] = true;
							allGrillObjects[i].GetComponent<grillItem>().takenGrillInt = i;
							allGrillObjects[i].GetComponent<grillItem>().wienerId = o;
							allGrillObjects[i].GetComponent<grillItem>().wiener = true;
							allGrillObjects[i].GetComponent<grillItem>().onDogSpriteReplace = eventData.pointerDrag.GetComponent<Image>().sprite;
							allGrillObjects[i].GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<draggableItem>().onDogSpriteReplace;
							allGrillObjects[i].GetComponent<Image>().color = Color.white;
							allGrillObjects[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
							break;
						}
					}
					break;
				}
			}
		}
	}
}
