using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public Weapon mEquippedWeapon;
    public Weapon[] weaponList;
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
<<<<<<< HEAD
        mEquippedWeapon.transform.position = transform.position;
        mEquippedWeapon.transform.parent = transform;
=======
		mEquippedWeapon = weaponList [0];
>>>>>>> parent of 99dcb0c... Added HUDPanel and Bullet Casing Particle System
    }

    void Update()
    {
<<<<<<< HEAD
=======
		mEquippedWeapon.transform.position = transform.position;
		mEquippedWeapon.transform.parent = transform;
>>>>>>> parent of 99dcb0c... Added HUDPanel and Bullet Casing Particle System
        if (mEquippedWeapon)
        {
            if (GetComponent<Aiming>().AimDirection.magnitude > 0.9)
            {
                if (Input.GetButton("Player_" + mPlayerNumber + "_Fire1"))
                {
<<<<<<< HEAD
                    //emit the bullet casing particle system
                    minigunParticleSystem.Emit(1);

=======
					minigunParticleSystem.Emit(1);
>>>>>>> parent of 99dcb0c... Added HUDPanel and Bullet Casing Particle System
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

    public void ChangeWeapon(int weaponNumber)
    {
        mEquippedWeapon = weaponList[weaponNumber];
        mEquippedWeapon.transform.position = transform.position;
        weaponList[weaponNumber].transform.SetParent(transform);
    }
}
