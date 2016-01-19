using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
	public Weapon mEquippedWeapon;
	
	public int mPlayerNumber;
	public int PlayerNumber {
		get {
			return mPlayerNumber;
		}
	}

	public Slider slider;
	
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

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Projectile") {
			slider.value -= (float)coll.gameObject.GetComponent<Projectile>().Damage / 100;
			Destroy(coll.gameObject);
		}
	}
}
