using UnityEngine;
using System.Collections;

public class Tunnel : MonoBehaviour {

	public GameObject Tunnel0;
	public GameObject Tunnel1;
	public GameObject Tunnel2;
	public GameObject Tunnel3;

	int randTunnel = 0;
	
	// Use this for initialization
	void Start () {
		/*Tunnels [0] = Tunnel0;
		Tunnels [1] = Tunnel1;
		Tunnels [2] = Tunnel2;
		Tunnels [3] = Tunnel3;*/
	}
	
	// Update is called once per frame
	void Update () {
		if (randTunnel >= 4) {
			randTunnel = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		randTunnel += 1;
		if(coll.gameObject.GetComponentInParent<Player>().wTime <= 0.0f)
		{

			if (randTunnel == 0) {
				coll.transform.position = Tunnel0.transform.position;
			}
			else if (randTunnel == 1) {
				coll.transform.position = Tunnel1.transform.position;
			}
			else if (randTunnel == 2) {
				coll.transform.position = Tunnel2.transform.position;
			}
			else if (randTunnel == 3) {
				coll.transform.position = Tunnel3.transform.position;
			}
			//Problem is that you can teleport to random tunnels but you can also teleport to the same on you just walked into
			//Have to check whether you are colliding with the one you're teleporting to
		}
		coll.gameObject.GetComponentInParent<Player>().wTime = 1.5f;
	}
}
