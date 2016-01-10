using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float mMovementSpeed;

	Rigidbody2D mRigidBody2D;

	void Start ()
	{
		mRigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.W)) {
			mRigidBody2D.AddForce (new Vector2 (0, mMovementSpeed));
		}
		if (Input.GetKey (KeyCode.A)) {
			mRigidBody2D.AddForce (new Vector2 (-mMovementSpeed, 0));
		}
		if (Input.GetKey (KeyCode.S)) {
			mRigidBody2D.AddForce (new Vector2 (0, -mMovementSpeed));
		}
		if (Input.GetKey (KeyCode.D)) {
			mRigidBody2D.AddForce (new Vector2 (mMovementSpeed, 0));
		}
	}
}