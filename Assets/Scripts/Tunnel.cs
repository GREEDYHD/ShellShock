using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ShellShock
{
    public class Tunnel : MonoBehaviour
    {

        public List<GameObject> tunnels = new List<GameObject>();

        public int tunnelNo = 0;
        public int randTunnel = 0;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (randTunnel >= 4)
            {
                randTunnel = 0;
            }
        }


    }
}
