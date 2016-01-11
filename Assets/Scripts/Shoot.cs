using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	// Use this for initialization
	void Start () {
		//OnButtonPress instantiate new player at scale 0.5, 0.5, 0.5.
		//Then move it forward about 10 in the direction aiming.
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")) 
		{
			Instantiate(bullet, new Vector3(0,0,0), Quaternion.identity);
		}
	}
}
