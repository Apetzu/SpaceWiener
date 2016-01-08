using UnityEngine;
using System.Collections;

public class tentacles : MonoBehaviour {

	float startPosition;

	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (transform.position.x, startPosition, transform.position.z);
	}
}
