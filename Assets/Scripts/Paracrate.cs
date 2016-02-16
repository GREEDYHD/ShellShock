using UnityEngine;
using System.Collections;

public class Paracrate : MonoBehaviour {

	public GameObject paracrateObj;
	public Vector2 tempDropCoordinates;
	public float leftXBoundary, rightXBoundary, topYBoundary, bottomYBoundary;
	private bool flyby = false;
	public float flybySpeed;
	public bool ammoDropped;

	// Use this for initialization
	void Start () 
	{
		ammoDropped = false;
		tempDropCoordinates = new Vector2(0,-7);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.T)) 
		{
			flyby = !flyby;
		}

		if (flyby) 
		{
			AmmoDrop();
		}
	}

	public void AmmoDrop()
	{
		//transform.Translate(Vector2.left * flybySpeed * Time.deltaTime);
		if (transform.position.x > -0.1 && transform.position.x < 0.1) 
		{
			Debug.Log ("Drop");
			Instantiate(paracrateObj, transform.position, Quaternion.identity);
		}
	}
}
