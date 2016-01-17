using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour
{
	float Range = 3f; //Range the reticle can move from the origin(player)
	Vector2 mAimDirection;
	public GameObject mReticle;

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
		Vector2 playerPosition = new Vector2 (transform.position.x, transform.position.y);
		mAimDirection = new Vector2 (Input.GetAxis ("Player_" + GetComponent<Player> ().PlayerNumber + "_RJoystickX"), Input.GetAxis ("Player_" + GetComponent<Player> ().PlayerNumber + "_RJoystickY")).normalized;

		mReticle.transform.position = playerPosition + GetComponent<Player> ().ReticlePosition + (mAimDirection * Range);
		Debug.DrawLine (playerPosition + GetComponent<Player> ().ReticlePosition, playerPosition + GetComponent<Player> ().ReticlePosition + mAimDirection * Range);
	}
}