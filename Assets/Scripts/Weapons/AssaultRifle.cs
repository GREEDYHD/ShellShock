using UnityEngine;
using System.Collections;
namespace ShellShock
{
    public class AssaultRifle : Weapon
    {
        void Start()
        {
            mDamage = 10;
            mCurrentReloadTime = 0f;
            mReloadTime = 10f;
            mSpread = 5f; // Spread
            mSpreadAngle = Mathf.PI / 18; // Angle in radians  (360 degrees = 2PI Radians)
            mFireRate = 60f; // Max fire rate is 60 as the game runs at 60 fps
            mChargeTime = 0f;
            mMuzzleVelocity = 40f;
            mCurrentFireTime = 0f;
            mAmmoRemaining = 30;
            mAmmoMax = 100;
        }
    }
}