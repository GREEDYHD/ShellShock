using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public Weapon mEquippedWeapon;

    public int mPlayerNumber;

	public float wTime; //Wait time between being able to use holes or otherwise it looks glitchy

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
        mEquippedWeapon.transform.position = transform.position;
        mEquippedWeapon.transform.parent = transform;
        mReticlePosition = mEquippedWeapon.transform.position;
    }

    void Update()
    {
        if (mEquippedWeapon)
        {
            if (GetComponent<Aiming>().AimDirection.magnitude > 0.9)
            {
                if (Input.GetButton("Player_" + mPlayerNumber + "_Fire1"))
                {
                    //emit the particle system (bullet casings).
                    minigunParticleSystem.Emit(1);
                    if (!mEquippedWeapon.Shoot(GetComponent<Aiming>().CorrectedAimDirection))
                    {
                        mEquippedWeapon = null;
                    }
                }
            }
        }

		wTime -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Projectile")
        {
            slider.value -= (float)coll.gameObject.GetComponent<Projectile>().Damage / 1000;
            Destroy(coll.gameObject);
        }
    }
}
