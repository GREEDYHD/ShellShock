﻿using UnityEngine;
using System.Collections;
namespace ShellShock
{
    public class Pistol : Weapon
    {
        void Start()
        {
            mDamage = 50;
            mCurrentReloadTime = 0f;
            mReloadTime = 10f;
            mSpread = 2f; // Spread
            mSpreadAngle = Mathf.PI / 18; // Angle in radians  (360 degrees = 2PI Radians)
            mFireRate = 10f; // Max fire rate is 60 as the game runs at 60 fps
            mChargeTime = 0f;
            mMuzzleVelocity = 40f;
            mCurrentFireTime = 0f;
            mAmmoRemaining = 10;
            mAmmoMax = 10;
        }
    }
}