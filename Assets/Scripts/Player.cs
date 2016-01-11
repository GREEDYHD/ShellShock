using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public Weapon mEquippedWeapon;
	
	void Start ()
	{
		mEquippedWeapon.transform.parent = transform;
	}
	
	int mPlayerNumber;
	int mHealth;
	int mMaxHealth;
	
	int mSheildDamageReduction;
	
	float mMaxSheildTime;
	float mRemainingSheidTime;
	
	void Update ()
	{
		if (mEquippedWeapon) {
			if (Input.GetButtonUp ("Fire1")) {
				mEquippedWeapon.IsShooting = false;
			}
			
			if (Input.GetButtonDown ("Fire1")) {
				mEquippedWeapon.IsShooting = true;
			}
		}
	}
}
