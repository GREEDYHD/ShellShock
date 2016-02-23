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

    public Slider HPSlider;
    public Slider ammoSlider;

    int mHealth;
    int mMaxHealth;

    int mSheildDamageReduction;

    public float waitTime;
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
      ammoSlider.maxValue = mEquippedWeapon.mAmmoRemaining;
        ammoSlider.value = ammoSlider.maxValue;

    }

    void Update()
    {
        waitTime -= Time.deltaTime;
        if (mEquippedWeapon)
        {
            if (GetComponent<Aiming>().AimDirection.magnitude > 0.9)
            {   //if the fire button is pressed, fire the gun.
                if (Input.GetButton("Player_" + mPlayerNumber + "_Fire1"))
                {
                    ammoSlider.value--;
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
            HPSlider.value -= (float)coll.gameObject.GetComponent<Projectile>().Damage / 100;
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
