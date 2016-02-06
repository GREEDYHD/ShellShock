using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public GameObject player;
	private SpriteRenderer ballRenderer;
	private Collider2D ballCollider;
	
	void Start () 
	{
		ballCollider = GetComponent<Collider2D>();
		ballRenderer = GetComponent<SpriteRenderer>();
		ballCollider.enabled = false;
		ballRenderer.enabled = false;
	}

	public void BallRender()
	{
		if (player.GetComponent<PlayerActions>().isBallin == true)
		{
			ballCollider.enabled = true;
			ballRenderer.enabled = true;
		}
		
		if (player.GetComponent<PlayerActions>().isBallin == false)
		{
			ballCollider.enabled = false;
			ballRenderer.enabled = false;
		}
	}
}