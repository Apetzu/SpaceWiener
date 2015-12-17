using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class customerMaster : MonoBehaviour {

	/* this script sets customer spawn side
	 * spawns random customer from array on either left or right
	 */
	public Text moneyText;
	public Text timer;

	public bool pos1Taken = false;
	public bool pos2Taken = false;
	public bool pos3Taken = false;
	public bool pos4Taken = false;

	float side;
	public float moneyValue = 0;
	float endTimer = 60;

	public GameObject spawnerLeft;
	public GameObject spawnerRight;
	public GameObject[] customers;

	Vector3 waitPosition;

	void Update()
	{
		endTimer = endTimer - Time.deltaTime;
		moneyText.text = ("money: "+moneyValue);
		timer.text = ("Time left: "+ (int) (endTimer) );
		if (endTimer >= 0 || moneyValue == 1 /*replace with wanted number */)
		{
			//win condition
		}
	}
	void Start()
	{
		StartCoroutine (spawnCust());
	}
	void RollSide()
	{
		side = Random.value;
		SpawnCust ();
	}
	void SpawnCust()
	{
		if (side > 0.5)
		{
			//spawn random customer on left side from array and applies customer script to it
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,4)],spawnerLeft.transform.position, spawnerLeft.transform.rotation);
			customer1.gameObject.AddComponent<customer1>();
		}
		else
		{
			//spawn random customer on right side from array and applies customer script to it
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,4)],spawnerRight.transform.position, spawnerRight.transform.rotation);
			customer1.gameObject.AddComponent<customer1>();
		}
	}
	IEnumerator spawnCust()
	{
		//spawns customer every 2-4 seconds
		while (true)
		{
			RollSide ();
			yield return new WaitForSeconds(Random.Range(2,4));
		}
	}
}
