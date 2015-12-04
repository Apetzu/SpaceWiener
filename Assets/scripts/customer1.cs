using UnityEngine;
using System.Collections;

public class customer1 : MonoBehaviour {

	customerMaster masterScript;
	public int position = 0;

	void Start () 
	{
		customerMaster = GameObject.FindWithTag ("customerMaster");
		Debug.Log (position);
	}
	void Update () 
	{
	
	}
	void SetPosition()
	{

	}
}
