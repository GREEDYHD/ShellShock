using UnityEngine;
using System.Collections;

public class PlayerActions: MonoBehaviour 
{
	public GameObject ballObj;
	public Player playerScript;
	public bool isBallin = false; //curled up in a ball
	public int weaponNumber;
	private SpriteRenderer playerRenderer; 
	private Collider2D playerCollider; 
	
	void Start () 
	{
		playerCollider = GetComponent<Collider2D>(); 
		playerRenderer = GetComponent<SpriteRenderer>(); 
		playerScript = GetComponent<Player> ();
	}

	void Update () 
	{
		if(Input.GetButton("Player_" + GetComponent<Player>().PlayerNumber +  "_Ball"))
		{
			Debug.Log (GetComponent<Player>().PlayerNumber);
			isBallin = true;
			PlayerRender();
			GetComponent<Aiming>().ReticleRender();
			ballObj.GetComponent<Ball>().BallRender();
		}

		if(Input.GetButtonUp("Player_" + GetComponent<Player>().PlayerNumber + "_Ball"))
		{
			isBallin = false;
			PlayerRender();
			GetComponent<Aiming>().ReticleRender();
			ballObj.GetComponent<Ball>().BallRender();
		}
			if(Input.GetButtonUp("Player_" + GetComponent<Player>().PlayerNumber + "_Switch"))
		{
			if (weaponNumber < playerScript.weaponList.Length) 
			{
				weaponNumber++;
				playerScript.ChangeWeapon(weaponNumber);
				Debug.Log (weaponNumber);

			}
			if (weaponNumber == playerScript.weaponList.Length) 
			{
				weaponNumber = 0;
				playerScript.ChangeWeapon(weaponNumber);
			}
		}
		
	}

	void PlayerRender()
	{
		if (isBallin == false)
		{
			playerCollider.enabled = true;
			playerRenderer.enabled = true;
		}
		
		if (isBallin == true)
		{
			playerCollider.enabled = false;
			playerRenderer.enabled = false;
		}
	}
}
