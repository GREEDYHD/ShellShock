using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace ShellShock
{
    public abstract class Weapon : MonoBehaviour
    {
        protected int mDamage; //Damage per bullet
        protected float mCurrentReloadTime = 0f; //current reload time compared to mReloadTime
        protected float mReloadTime = 10f; //Reload time in seconds
        protected float mSpread = 2f; //Bullet spread
        protected float mSpreadAngle = Mathf.PI / 18; // Angle in radians  (360 degrees = 2PI Radians)
        protected float mFireRate = 60f;//Max fire rate is 60 as the game runs at 60 fps
        protected float mChargeTime = 0f; //if 
        protected float mMuzzleVelocity = 40f;
        protected float mCurrentFireTime = 0f;
        protected int mAmmoRemaining = 100;
        protected int mAmmoMax = 100;

        public bool hasInfiniteAmmo;

        protected Vector2 mShootDirection = new Vector2(0, 0);

        public Vector2 ShootDirection
        {
            get
            {
                return mShootDirection;
            }
            set
            {
                mShootDirection = value;
            }
        }

        public int RemainingAmmo
        {
            get
            {
                return mAmmoRemaining;
            }

            set
            {
                mAmmoRemaining = value;
            }
        }
        public int MaximumAmmo
        {
            get
            {
                return mAmmoMax;
            }

            set
            {
                mAmmoMax = value;
            }
        }

        public GameObject mProjectile;

        public bool Shoot(Vector2 dir, int id)
        {
            if (mAmmoRemaining > 0)
            {
                Vector2 spr = new Vector2(Random.value - 0.5f, Random.value - 0.5f) * mSpread;
                if (mCurrentFireTime > 1 / mFireRate)
                {
                    GameObject firedProjectile = (GameObject)Instantiate(mProjectile, new Vector2(transform.position.x, transform.position.y) + dir.normalized * 1.8f, Quaternion.identity);
                    firedProjectile.GetComponent<ShellShock.Projectile>().Fire((dir * mMuzzleVelocity) + spr, mDamage, id);
                    if (!hasInfiniteAmmo)
                    {
                        mAmmoRemaining--;
                    }
                    mCurrentFireTime = 0;
                    return true;
                }
                else
                {
                    mCurrentFireTime += Time.deltaTime;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}