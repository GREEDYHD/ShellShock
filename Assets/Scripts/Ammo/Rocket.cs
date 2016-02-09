using UnityEngine;
using System.Collections;

public class Rocket : Projectile
{
	void Awake()
	{
		mMaxBounces = 20;
	}
}
