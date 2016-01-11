using UnityEngine;
using System.Collections;

public class Proj : MonoBehaviour {
	
	public float bouncesAllowed;
	public float currentBounces;
	public GameObject mReticle;
	public GameObject mPlayer;

	// Use this for initalization
	void Awake() 
	{
		mReticle = GameObject.Find ("Reticle");
		mPlayer = GameObject.Find ("Player 1");

		Vector3 d = mReticle.GetComponent<Transform> ().position - mPlayer.GetComponent<Transform> ().position;

		this.GetComponent<Rigidbody2D>().AddForce (new Vector2 (d.x*750, d.y*750));
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
