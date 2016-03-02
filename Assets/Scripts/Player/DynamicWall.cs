using UnityEngine;
using System.Collections;

namespace ShellShock
{
    public class DynamicWall : MonoBehaviour
    {
        public Animator wallAnim;
        // Use this for initialization
        void Start()
        {
            wallAnim = GetComponent<Animator>();
            wallAnim.enabled = false;
        }

        void Update()
        {
            if (Input.GetButton("Fire2"))
            {
                Walls();
            }
        }

        void Walls()
        {
            wallAnim.enabled = true;
        }
    }
}
