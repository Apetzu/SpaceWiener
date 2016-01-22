using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class grillItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	private Vector3 startPos;
	public Sprite onDogSpriteReplace;
	public Camera mainCamera;
	public int wienerId;
	public bool wiener;
	public int takenGrillInt;
	bool wienerBeDragged;
	public float currentTime;
	public float grillingTransTime = 5f;
	public Sprite[] animSprites;
	public int burnLevel = 0;
	public GameObject timerMaster;
	public GameObject customerMaster;

	timerMaster timerMasterScript;
	customerMaster customerMasterScript;

	void Start()
	{
		customerMasterScript = customerMaster.GetComponent<customerMaster> ();
		timerMasterScript = timerMaster.GetComponent<timerMaster>();
		grillingTransTime = timerMasterScript.grillTimeToCooked;
	}

	void Update()
	{
		if (Time.timeScale == 0)
			wienerBeDragged = true;
		else
			wienerBeDragged = false;

		if (wiener == true && wienerBeDragged == false && GetComponent<AudioSource>().isPlaying == false)
			GetComponent<AudioSource>().Play ();
		if (wiener == false || wienerBeDragged == true)
			GetComponent<AudioSource>().Stop ();
	}

	void FixedUpdate()
	{
		if (wiener == true && wienerBeDragged == false && burnLevel < animSprites.Length - 1)
		{
			if (burnLevel == 1)
			{
				grillingTransTime = timerMasterScript.grillTimeToBurned;
			}
			currentTime += Time.fixedDeltaTime;
			if (currentTime >= grillingTransTime)
			{
				currentTime = 0f;
				burnLevel++;
				GetComponent<Image>().sprite = animSprites[burnLevel];
			}
			if (burnLevel == 2)
			{
				customerMasterScript.numberOfWienersBurned++;
			}
		}

	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			wienerBeDragged = true;
			startPos = transform.position;
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}
	public void OnDrag(PointerEventData eventData)
	{
		if (Time.timeScale != 0)
			transform.position = mainCamera.ScreenToWorldPoint (eventData.position) + Vector3.forward;
	}
	public void OnEndDrag(PointerEventData eventData)
	{
		if (Time.timeScale != 0)
		{
			wienerBeDragged = false;
			transform.position = startPos;
			if (wiener == true)
				GetComponent<CanvasGroup>().blocksRaycasts = true;
			else
				GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}
}
