using UnityEngine;
using System.Collections;

public class Proj : MonoBehaviour {
	
	public float bouncesAllowed;
	public float currentBounces;

	// Use this for initalization
	void Awake() 
	{
		this.GetComponent<Rigidbody2D>().AddForce (new Vector2 (250, 0));
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (currentBounces > bouncesAllowed) 
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D bulletCollider)
	{
		currentBounces++;
	}
}
