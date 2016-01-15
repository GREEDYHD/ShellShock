using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
	public Weapon mEquippedWeapon;
	public Slider slider;
	
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

			if (GetComponent<Aiming> ().AimDirection.magnitude > 0.9) {
				if (Input.GetButtonUp ("Fire1")) {
					mEquippedWeapon.IsShooting = false;
				}
				
				if (Input.GetButtonDown ("Fire1")) {
					mEquippedWeapon.IsShooting = true;
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Projectile") {
			Debug.Log("Hit");
			slider.value -= 0.05f; //But it will be coll.damage not 5.
		}
	}
}
