using UnityEngine;
using System.Collections;

namespace ShellShock

{

	public class Grenade : Projectile 
	{
		public float grenadeLife = 0.5f;
	
	    public Collider2D[] PlayersAffected;
	
	    public float damageRadius;
	    
		RaycastHit2D checkHit;
	
	    float distance;
	
	   float effect = 0f;
	
	    void Awake()
	    {
	        bouncesAllowed = 20f;
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
	
	    void AOEDamage(Vector3 position, float damageRadius, float damage, GameObject Player)
	    {
	        Collider2D[] PlayersAffected = Physics2D.OverlapCircleAll(position, damageRadius);
	
	        foreach (Collider2D col in PlayersAffected)
	        {
	           Player playerAffected = col.GetComponent<ShellShock.Player>();
	
	            if (playerAffected != null) //if there is at least one player to affect apply damage
	            {
	                bool checkCover = false;
	
	                if (Physics2D.Raycast(position, (playerAffected.gameObject.transform.position - position)))
	                {
						if(checkHit.collider == Player.gameObject.GetComponent<Collider2D>())
						{
							checkCover = true;
							Debug.Log(checkCover);
						}
	                }
	                if (checkCover) //effect of the explosion
	                {
	                    Debug.Log("vaffanculo");
	                    distance = (position - Player.transform.position).magnitude;
	                    effect = 1 - (distance / damageRadius);
	                    playerAffected.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1));
	                    // affect health based on the effect = (damage * effect)
	                }
	
	            }
	
	        } 
	
	    }
			
		//public override void Fire(Vector2 vel, int damage)
		//{
	 //       Debug.Log("adsd");
		//	mVelocity = vel;
		//	mRigidBody = gameObject.GetComponent<ShellShock.Rigidbody2D>();
		//	mRigidBody.velocity = mVelocity;
		//	mDamage = damage;
		//	Vector3 dir = new Vector2(transform.position.x, transform.position.y) - vel;
		//	float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		//	transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
		//	Destroy (gameObject, grenadeLife);
		//}
			
		void OnCollisionEnter2D(Collision2D bulletCollider)
		{
			currentBounces++;
		}
	}
}
