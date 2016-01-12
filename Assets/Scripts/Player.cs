using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public Weapon mEquippedWeapon;
	
	public int mPlayerNumber = 0;

	public int PlayerNumber {
		get {
			return mPlayerNumber;
		}
	}

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

			if (GetComponent<Aiming> ().AimDirection.magnitude > 0.9) {
				if (Input.GetButton ("Player_" + mPlayerNumber + "_Fire1")) {
					if (!mEquippedWeapon.Shoot ()) {
						mEquippedWeapon = null;
					}
				}
			}
		}
	}
}
