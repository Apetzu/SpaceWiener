using UnityEngine;
using System.Collections;

public class customerMaster : MonoBehaviour {

	/* this script sets customer spawn side
	 * spawns random customer from array on either left or right
	 */

	public bool pos1Taken = false;
	public bool pos2Taken = false;
	public bool pos3Taken = false;
	public bool pos4Taken = false;

	float side;

	public GameObject spawnerLeft;
	public GameObject spawnerRight;
	public GameObject[] customers;

	Vector3 waitPosition;
	
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
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,2)],spawnerLeft.transform.position, spawnerLeft.transform.rotation);
			customer1.gameObject.AddComponent<customer1>();
		}
		else
		{
			//spawn random customer on right side from array and applies customer script to it
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,2)],spawnerRight.transform.position, spawnerRight.transform.rotation);
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
