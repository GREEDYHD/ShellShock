using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public GameObject player;
	private PlayerActions _playerActions;
	private SpriteRenderer ballRenderer;
	private Collider2D ballCollider;

	// Use this for initialization
	void Start () 
	{
		ballCollider = GetComponent<Collider2D>();
		ballRenderer = GetComponent<SpriteRenderer>();
		ballCollider.enabled = false;
		ballRenderer.enabled = false;
		_playerActions = player.GetComponent<PlayerActions>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void BallRender()
	{
		if (_playerActions.isBallin == true)
		{
			ballCollider.enabled = true;
			ballRenderer.enabled = true;
		}
		
		if (_playerActions.isBallin == false)
		{
			ballCollider.enabled = false;
			ballRenderer.enabled = false;
		}
	}
}
