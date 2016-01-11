using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	//protected int mDamage;
	protected float mCurrentReloadTime = 0f;
	protected float mReloadTime = 10f;
	protected float mSpread = 1f; //spread at maximum range
	protected float mSpreadAngle = Mathf.PI / 18; // Angle in radians  (360 degrees = 2PI Radians)
	protected float mFireRate = 50f;
	protected float mChargeTime = 0f;
	protected float mRange = 10f;
	protected float mMuzzleVelocity = 20f;
	protected float mCurrentFireTime = 0f;
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
		//      dir.x += Mathf.Sin(Random.value - 0.5f) * mSpreadAngle;
		//      dir.y += Mathf.Cos(Random.value - 0.5f) * mSpreadAngle;
		
		Vector3 spr = new Vector3 (Random.value - 0.5f, Random.value - 0.5f, 0) * mSpread; //Represents bullet spread at maximum range
		if (mCurrentFireTime > 1 / mFireRate) {
			GameObject firedProjectile = (GameObject)Instantiate (mProjectile, transform.position, Quaternion.identity);
			firedProjectile.GetComponent<Projectile> ().Fire ((transform.up * mMuzzleVelocity) + spr);
			mCurrentFireTime = 0;
		} else {
			mCurrentFireTime += Time.deltaTime;
		}
	}

	void Update ()
	{
		Debug.DrawLine (transform.position, transform.position + transform.up);
		if (IsShooting) {
			Shoot ();
		} else {
			mCurrentFireTime = 0;
		}
	}
}