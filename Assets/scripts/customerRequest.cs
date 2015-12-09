using UnityEngine;
using System.Collections;

public class customerRequest : MonoBehaviour {

	bool spice;
	bool salad;

	float randBoolSpice;
	float randBoolSalad;

	int wienerI;
	int spiceI;
	int saladI;
	
	void Start () 
	{
		randBoolSpice = Random.Range (1,9);
		if (randBoolSpice > 4)
		{
			spice = true;
		}
		else 
		{
			spice = false;
		}
		randBoolSpice = Random.Range (1,9);
		if (randBoolSpice > 2f)
		{
			salad = true;
		}
		else 
		{
			salad = false;
		}
		wienerI = Random.Range (1,4);
		spiceI = Random.Range (1,4);
		saladI = Random.Range (1,4);
		Debug.Log (spice);
		Debug.Log (salad);
		Debug.Log (wienerI);
		Debug.Log (spiceI);
		Debug.Log (saladI);
		
	}

	void Update () 
	{
	
	}
}
