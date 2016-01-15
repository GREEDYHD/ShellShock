using UnityEngine;
using System.Collections;

public class PlayerActions: MonoBehaviour 
{
	public GameObject player;
	private Ball ballScript;
	private Aiming reticleScript;
	public GameObject ballObj;
	public GameObject reticleObj;

	public bool isBallin = false; //curled up in a ball

	private SpriteRenderer playerRenderer; 
	private Collider2D playerCollider; 

	// Use this for initialization
	void Start () 
	{
		playerCollider = GetComponent<Collider2D>(); 
		playerRenderer = GetComponent<SpriteRenderer>(); 
		ballScript = ballObj.GetComponent<Ball>();
		reticleScript = reticleObj.GetComponent<Aiming>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Ball"))
		{
			isBallin = !isBallin;
			PlayerRender();
			reticleScript.ReticleRender();
			ballScript.BallRender();
		}

		if(Input.GetButtonUp("Ball"))
		{
			isBallin = !isBallin;
			PlayerRender();
			reticleScript.ReticleRender();
			ballScript.BallRender();
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
