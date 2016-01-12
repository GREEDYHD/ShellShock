using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public Weapon mEquippedWeapon;
	
	int mPlayerNumber;
	int mHealth;
	int mMaxHealth;
	
	int mSheildDamageReduction;
	
	float mMaxSheildTime;
	float mRemainingSheidTime;
	Vector2 mReticlePosition;

	public Vector2 ReticlePosition {
		get {
			return mReticlePosition;
		}
	}

	void Start ()
	{
		mEquippedWeapon.transform.parent = transform;
		mReticlePosition = mEquippedWeapon.transform.position;
	}
	
	void Update ()
	{
		if (mEquippedWeapon) {
			mEquippedWeapon.ShootDirection = GetComponent<Aiming> ().AimDirection;

			if (Input.GetButtonUp ("Fire1")) {
				mEquippedWeapon.IsShooting = false;
			}
			
			if (Input.GetButtonDown ("Fire1")) {
				mEquippedWeapon.IsShooting = true;
			}
		}
	}
}
