using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public Weapon mEquippedWeapon;
	public Weapon[] weaponList; // 10/02/16
    public int mPlayerNumber;
    public int PlayerNumber
    {
        get
        {
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
	public ParticleSystem minigunParticleSystem;
    public Vector2 ReticlePosition
    {
        get
        {
            return mReticlePosition;
        }
    }

    void Start()
    {
        mReticlePosition = mEquippedWeapon.transform.position;
        mEquippedWeapon.transform.position = transform.position;
        mEquippedWeapon.transform.parent = transform;
        //mEquippedWeapon = weaponList [0];
    }

    void Update()
    {
		
        if (mEquippedWeapon)
        {
            if (GetComponent<Aiming>().AimDirection.magnitude > 0.9)
            {   //if the fire button is pressed, fire the gun.
                if (Input.GetButton("Player_" + mPlayerNumber + "_Fire1"))
                {
                    //emit the bullet casing particle system
					minigunParticleSystem.Emit(1);
                   
                    if (!mEquippedWeapon.Shoot(GetComponent<Aiming>().CorrectedAimDirection))
                    {
                        mEquippedWeapon = null;
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Projectile")
        {
            slider.value -= (float)coll.gameObject.GetComponent<Projectile>().Damage / 100;
            Destroy(coll.gameObject);
        }
    }
	//######################################################################################
	//Youles 10/02/16
	public void ChangeWeapon(int weaponNumber)
	{
		mEquippedWeapon = weaponList [weaponNumber];
		mEquippedWeapon.transform.position = transform.position;
		mEquippedWeapon.transform.parent = transform;

	}
	//######################################################################################
}
