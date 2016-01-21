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
	public Button creditsButton;

	public bool pos1Taken = false;
	public bool pos2Taken = false;
	public bool pos3Taken = false;
	public bool pos4Taken = false;

	float side;
	public float moneyValue = 0;
	float endTimer = 121;

	public GameObject spawnerLeft;
	public GameObject spawnerRight;
	public GameObject[] customers;
	public GameObject timerMaster;
	public GameObject victory;
	public GameObject gameOver;
	public GameObject shutter;
	public GameObject canvas2;

	public AudioClip[] humanCustomerSounds;
	public AudioClip[] childCustomerSounds;
	public AudioClip[] pinkCustomerSounds;
	public AudioClip[] grayCustomerSounds;
	public AudioClip[] greenCustomerSounds;

	Vector3 waitPosition;
	timerMaster timerMasterScript;
	shutterScript shutterScript;

	void FixedUpdate()
	{
		endTimer = endTimer - Time.fixedDeltaTime;
		moneyText.text = ("Money: "+moneyValue);
		timer.text = ("Time left: "+ (int) (endTimer));
		if (moneyValue >= timerMasterScript.moneyNeededForWin /*replace with wanted number */)
		{
			canvas2.SetActive(true);
			victory.gameObject.SetActive(true);
			winText.text = ("you got "+moneyValue+"/"+timerMasterScript.moneyNeededForWin);
			shutterScript.MoveShutterDown();
		}
		if (endTimer <= 0)
		{
			canvas2.SetActive(true);
			gameOver.gameObject.SetActive(true);
			winText.text = ("you got "+moneyValue+"/"+timerMasterScript.moneyNeededForWin);
			shutterScript.MoveShutterDown();
		}
	}
	void Start()
	{
		shutterScript = shutter.gameObject.GetComponent<shutterScript>();
		timerMasterScript = timerMaster.GetComponent<timerMaster> ();
		endTimer = timerMasterScript.gameTime;
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
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,5)],spawnerLeft.transform.position, spawnerLeft.transform.rotation);
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
			GameObject customer1 = (GameObject) Instantiate(customers[UnityEngine.Random.Range (0,5)],spawnerRight.transform.position, spawnerRight.transform.rotation);
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
			yield return new WaitForSeconds(Random.Range(timerMasterScript.timeBetweenCustomerSpawnMin,timerMasterScript.timeBetweenCustomerSpawnMax));
		}
	}
}
