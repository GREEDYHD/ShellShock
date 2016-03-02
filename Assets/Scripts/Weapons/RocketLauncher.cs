using UnityEngine;
using System.Collections;

namespace ShellShock
{
    public class RocketLauncher : Weapon
    {

        void Start()
        {
            mDamage = 90;
            mCurrentReloadTime = 0f;
            mReloadTime = 10f;
            mSpread = 0f; // Spread
            mSpreadAngle = Mathf.PI / 18; // Angle in radians  (360 degrees = 2PI Radians)
            mFireRate = 1f; // Max fire rate is 60 as the game runs at 60 fps
            mChargeTime = 0f;
            mMuzzleVelocity = 20f;
            mCurrentFireTime = 0f;
            mAmmoRemaining = 1;
            mAmmoMax = 1;
        }
    }
}
