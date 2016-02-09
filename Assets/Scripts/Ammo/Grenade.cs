using UnityEngine;
using System.Collections;

public class Grenade : Projectile 
{
	public float grenadeLife = 0.5f;

    void Awake()
    {
        mMaxBounces = 20f;
    }
}
