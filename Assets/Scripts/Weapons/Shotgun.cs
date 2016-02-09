using UnityEngine;
using System.Collections;

public class Shotgun : Weapon
{
    void Start()
    {
        mDamage = 35;
        mCurrentReloadTime = 0f;
        mReloadTime = 10f;
        mSpread = 45f; // Spread
        mSpreadAngle = Mathf.PI / 18; // Angle in radians  (360 degrees = 2PI Radians)
        mFireRate = 10f; // Max fire rate is 60 as the game runs at 60 fps
        mChargeTime = 0f;
        mMuzzleVelocity = 30f;
        mCurrentFireTime = 0f;
        mAmmoRemaining = 10;
        mAmmoMax = 10;
    }

    public override bool Shoot(Vector2 dir)
    {
        if (mAmmoRemaining > 0)
        {
            if (mCurrentFireTime > 1 / mFireRate)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector2 spr = new Vector2(Random.value - 0.5f, Random.value - 0.5f) * mSpread;
                    GameObject firedProjectile = (GameObject)Instantiate(mProjectile, new Vector2(transform.position.x, transform.position.y) + dir.normalized * 1.8f, Quaternion.identity);
                    firedProjectile.GetComponent<Projectile>().Fire((dir * mMuzzleVelocity) + spr, mDamage, mMaxBounces);
                }

                if (!hasInfiniteAmmo)
                {
                    mAmmoRemaining--;
                }
                mCurrentFireTime = 0;
                return true;
            }
            else {
                mCurrentFireTime += Time.deltaTime;
                return true;
            }
        }
        else {
            return false;
        }
    }
}