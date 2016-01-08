using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class customerMaster : MonoBehaviour {

	/* this script sets customer spawn side
	 * spawns random customer from array on either left or right
	 */
	public Text moneyText;
	public Text timer;
	public Text winText;

	public bool pos1Taken = false;
	public bool pos2Taken = false;
	public bool pos3Taken = false;
	public bool pos4Taken = false;

	float side;
	public float moneyValue = 0;
	float endTimer = 81;

	public GameObject spawnerLeft;
	public GameObject spawnerRight;
	public GameObject[] customers;

	Vector3 waitPosition;

	void Update()
	{
		endTimer = endTimer - Time.deltaTime;
		moneyText.text = ("money: "+moneyValue);
		timer.text = ("Time left: "+ (int) (endTimer));
		if (endTimer <= 0 || moneyValue >= 100 /*replace with wanted number */)
		{
			winText.text = ("you got "+moneyValue+"/100 money");
			Time.timeScale = 0;
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
			Debug.Log (customer1.tag);
			if (customer1.gameObject.tag == "childCustomer")
			{
				customer1.gameObject.AddComponent<customer2>();
			}
			else
			{
				customer1.gameObject.AddComponent<customer1>();
			}
		}
		else
		{
			//spawn random customer on right side from array and applies customer script to it
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,4)],spawnerRight.transform.position, spawnerRight.transform.rotation);
			Debug.Log (customer1.tag);
			if (customer1.gameObject.tag == "childCustomer")
			{
				customer1.gameObject.AddComponent<customer2>();
			}
			else
			{
				customer1.gameObject.AddComponent<customer1>();
			}
		}
	}
	IEnumerator spawnCust()
	{
		//spawns customer every 1-3 seconds
		while (true)
		{
			yield return new WaitForSeconds(1);
			RollSide ();
			yield return new WaitForSeconds(Random.Range(1f,3));
		}
	}
}
