using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour
{
	float Range = 3f; //Range the reticle can move from the origin(player)
	Vector2 mAimDirection;

	public Vector2 AimDirection {
		get {
			return mAimDirection;
		}
		set {
			mAimDirection = value;
		}
	}

	void Update ()
	{
		Vector2 playerPosition = new Vector2 (transform.parent.position.x, transform.parent.position.y);
		mAimDirection = new Vector2 (Input.GetAxis ("RJoystickX"), Input.GetAxis ("RJoystickY")).normalized;
		transform.position = playerPosition + (mAimDirection * Range);
		Debug.DrawLine (playerPosition, playerPosition + mAimDirection * Range);
	}
}