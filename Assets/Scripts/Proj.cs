using UnityEngine;
using System.Collections;

public class Proj : MonoBehaviour {

	float t;
	// Use this for initalization
	void Awake() 
	{
		this.GetComponent<Rigidbody2D>().AddForce (new Vector2 (250, 0));
	}
	
	// Update is called once per frame
	void Update() {
		t += Time.deltaTime;
		if (t >= 0.5) {
			Destroy(this.gameObject);
		}
	}
}
