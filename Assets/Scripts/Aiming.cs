using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour
{
	public GameObject player;
	private PlayerActions _playerActions;
	private SpriteRenderer reticleRenderer;

	float Range = 3f; //Range the reticle can move from the origin(player)
	Vector2 mAimDirection;
	public GameObject mReticle;

	void Start()
	{
		reticleRenderer = GetComponent<SpriteRenderer>();
		_playerActions = player.GetComponent<PlayerActions>();
		reticleRenderer.enabled = true;
	}

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
		mAimDirection = new Vector2 (Input.GetAxis ("Player_" + GetComponent<Player> ().PlayerNumber + "_RJoystickX"), Input.GetAxis ("Player_" + GetComponent<Player> ().PlayerNumber +  "_RJoystickY")).normalized;
		mReticle.transform.position = playerPosition + (mAimDirection * Range);
		//Debug.DrawLine (playerPosition, playerPosition + mAimDirection * Range);
	}

	public void ReticleRender()
	{
		if (_playerActions.isBallin == true)
		{
			reticleRenderer.enabled = false;
		}
		
		if (_playerActions.isBallin == false)
		{
			reticleRenderer.enabled = true;
		}
	}
}