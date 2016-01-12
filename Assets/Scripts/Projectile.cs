using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float bouncesAllowed;
	public float currentBounces;

	Vector2 mVelocity;
	Rigidbody2D mRigidBody;

	void Update ()
	{
		if (currentBounces > bouncesAllowed) {
			Destroy (gameObject);
		}
	}

	public void Fire (Vector2 vel)
	{
		mVelocity = vel;
		mRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		mRigidBody.velocity = mVelocity;
		
		Vector3 dir = new Vector2 (transform.position.x, transform.position .y) - vel;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle - 180, Vector3.forward);
	}

	void OnCollisionEnter2D (Collision2D bulletCollider)
	{
		currentBounces++;
	}
}