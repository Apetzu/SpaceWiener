using UnityEngine;
using System.Collections;

public class timerMaster : MonoBehaviour {

	public float gameTime = 120f;
	public float timeBetweenCustomerSpawnMin = 1f;
	public float timeBetweenCustomerSpawnMax = 3f;
	public float customerTimeMin = 25f;
	public float customerTimeMax = 30f;
	public float grillTimeToCooked = 5f;
	public float grillTimeToBurned = 10f;
	public float moneyNeededForWin = 100f;
	public float moneyForCorrectHotdog = 5f;
	public float moneyForCorrectSalad = 3f;
	public float moneyForCorrectSauce = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
