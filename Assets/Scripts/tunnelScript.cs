using UnityEngine;
using System.Collections;

public class tunnelScript : MonoBehaviour {

    public GameObject tunnelMan;

    int tunnelNo;

    int randTunnelLink;
    // Use this for initialization
    void Start () {
        tunnelMan.GetComponent<Tunnel>().tunnels.Add(this.gameObject);
        tunnelNo = tunnelMan.GetComponent<Tunnel>().tunnelNo;
        tunnelMan.GetComponent<Tunnel>().tunnelNo++;
        randTunnelLink = tunnelMan.GetComponent<Tunnel>().randTunnel;
    }
	
	// Update is called once per frame
	void Update () {
        if (randTunnelLink >= 3)
        {
            randTunnelLink = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<Player>() && coll.gameObject.GetComponentInParent<Player>().waitTime <= 0.0f)
        {
            if (randTunnelLink != tunnelNo)
            {
                if (randTunnelLink == 0)
                {
                    coll.transform.position = tunnelMan.GetComponent<Tunnel>().tunnels[0].transform.position;
                }
                else if (randTunnelLink == 1)
                {
                    coll.transform.position = tunnelMan.GetComponent<Tunnel>().tunnels[1].transform.position;
                }
                else if (randTunnelLink == 2)
                {
                    coll.transform.position = tunnelMan.GetComponent<Tunnel>().tunnels[2].transform.position;
                }
                else if (randTunnelLink == 3)
                {
                    coll.transform.position = tunnelMan.GetComponent<Tunnel>().tunnels[3].transform.position;
                }
            }
            //Problem is that you can teleport to random tunnels but you can also teleport to the same on you just walked into
            //Have to check whether you are colliding with the one you're teleporting to
            randTunnelLink += 1;
            coll.gameObject.GetComponentInParent<Player>().waitTime = 0.5f;
        }
    }
}
