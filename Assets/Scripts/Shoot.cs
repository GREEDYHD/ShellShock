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
		if (Mathf.RoundToInt(Input.GetAxisRaw("Fire1")) > 0.5) 
		{
			Instantiate(bullet, this.GetComponentInParent<Transform>().position, Quaternion.identity);
		}
	}
}
