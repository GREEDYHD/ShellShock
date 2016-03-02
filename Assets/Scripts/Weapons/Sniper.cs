using UnityEngine;
using System.Collections;

namespace ShellShock
{
    public class Sniper : Weapon
    {

        void Start()
        {
            mDamage = 50;
            mCurrentReloadTime = 0f;
            mReloadTime = 10f;
            mSpread = 0f; // Spread
            mSpreadAngle = Mathf.PI / 18; // Angle in radians  (360 degrees = 2PI Radians)
            mFireRate = 2f; // Max fire rate is 60 as the game runs at 60 fps
            mChargeTime = 0f;
            mMuzzleVelocity = 75f;
            mCurrentFireTime = 0f;
            mAmmoRemaining = 3;
            mAmmoMax = 3;
        }
    }
}
