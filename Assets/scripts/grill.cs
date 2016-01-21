using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class grill : MonoBehaviour, IDropHandler {
	
	public GameObject[] allGrillObjects = new GameObject[4];
	public List<GameObject> allSausageObjects = new List<GameObject>();
	bool soundBool;

	void Update()
	{
		if (Time.timeScale != 0f && soundBool == false)
		{
			GetComponent<AudioSource>().Play();
			soundBool = true;
		}
		if (Time.timeScale == 0f)
		{
			GetComponent<AudioSource>().Stop();
			soundBool = false;
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag.tag == "sausage" && Time.timeScale != 0f) 
		{
			for (int o = 0; o <= allSausageObjects.Count; o++)
			{
				if (eventData.pointerDrag.gameObject == allSausageObjects[o])
				{
					for (int i = 0; i < allGrillObjects.Length; i++) 
					{
						if (allGrillObjects[i].GetComponent<grillItem>().wiener == false)
						{
							allGrillObjects[i].GetComponent<grillItem>().takenGrillInt = i;
							allGrillObjects[i].GetComponent<grillItem>().wienerId = o;
							allGrillObjects[i].GetComponent<grillItem>().wiener = true;
							allGrillObjects[i].GetComponent<grillItem>().onDogSpriteReplace = eventData.pointerDrag.GetComponent<draggableItem>().onDogSpriteReplace;
							allGrillObjects[i].GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<draggableItem>().animSprites[0];
							allGrillObjects[i].GetComponent<Image>().color = Color.white;
							allGrillObjects[i].GetComponent<grillItem>().animSprites = eventData.pointerDrag.GetComponent<draggableItem>().animSprites;
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
