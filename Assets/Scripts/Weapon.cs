using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	//protected int mDamage;
	protected float mCurrentReloadTime = 0f;
	protected float mReloadTime = 10f;
	protected float mSpread = 2f; //spread
	protected float mSpreadAngle = Mathf.PI / 18; // Angle in radians  (360 degrees = 2PI Radians)
	protected float mFireRate = 60f;//Max fire rate is 60 as the game runs at 60 fps
	protected float mChargeTime = 0f;
	protected float mMuzzleVelocity = 40f;
	protected float mCurrentFireTime = 0f;
	protected Vector2 mShootDirection = new Vector2 (0, 0);

	public Vector2 ShootDirection {
		get {
			return mShootDirection;
		}
		set {
			mShootDirection = value;
		}
	}

	public GameObject mProjectile;
	
	bool isShooting;
	
	public bool IsShooting {
		get {
			return isShooting;
		}
		
		set {
			isShooting = value;
		}
	}

	void Shoot ()
	{
		Vector2 spr = new Vector2 (Random.value - 0.5f, Random.value - 0.5f) * mSpread;
		if (mCurrentFireTime > 1 / mFireRate) {
			GameObject firedProjectile = (GameObject)Instantiate (mProjectile, transform.position, Quaternion.identity);
			firedProjectile.GetComponent<Projectile> ().Fire ((mShootDirection * mMuzzleVelocity) + spr);
			mCurrentFireTime = 0;
		} else {
			mCurrentFireTime += Time.deltaTime;
		}
	}

	void Update ()
	{
		if (IsShooting) {
			Shoot ();
		} else {
			mCurrentFireTime = 0;
		}
	}
}