using UnityEngine;
using System.Collections;

public class Grenade : Projectile 
	{
		public float bouncesAllowed = 20f;
		public float currentBounces;
		public float grenadeLife = 0.5f;
		
		Vector2 mVelocity;
		Rigidbody2D mRigidBody;
		int mDamage;
		
		public int Damage
		{
			get
			{
				return mDamage;
			}
			set
			{
				mDamage = value;
			}
		}
		
		void Update()
		{
			if (currentBounces > bouncesAllowed)
			{
				Destroy(gameObject);
			}
			Vector3 dir = (Vector2)transform.position - mRigidBody.velocity;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
		}
		
		public void Fire(Vector2 vel, int damage)
		{
			mVelocity = vel;
			mRigidBody = gameObject.GetComponent<Rigidbody2D>();
			mRigidBody.velocity = mVelocity;
			mDamage = damage;
			Vector3 dir = new Vector2(transform.position.x, transform.position.y) - vel;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
			Destroy (gameObject, grenadeLife);
		}
		
		void OnCollisionEnter2D(Collision2D bulletCollider)
		{
			currentBounces++;
		}
	}
