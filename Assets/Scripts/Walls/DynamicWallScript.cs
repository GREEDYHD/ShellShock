using UnityEngine;
using System.Collections;

namespace ShellShock
{
    public class DynamicWallScript : MonoBehaviour
    {

        public DynamicWallManager wallManager;
        private Animator wallAnimator;
        public float repeatTime = 5f;
        //public Animation wallAnim;

        // Use this for initialization
        void Start()
        {
            wallAnimator = GetComponent<Animator>();
            //wallAnim = GetComponent<ShellShock.Animation> ();
            wallAnimator.SetBool("isDown", false);
        }

        // Update is called once per frame
        void Update()
        {
            repeatTime -= Time.deltaTime;
            if (repeatTime <= 0.0f)
            {
                WallChange();
            }
        }

        void WallChange()
        {
            //Debug.Log("Wall Change");
            if (wallAnimator.GetBool("isDown") == true) //Walls are down
            {
                WallsUp();
                //Debug.Log("Wall Up");
            }

            else if (wallAnimator.GetBool("isDown") == false)
            {
                WallsDown();
                //Debug.Log("Wall Down");
            }

            repeatTime = 5f;
        }

        void WallsDown()
        {
            wallAnimator.SetBool("isDown", true); //Walls go down
        }

        void WallsUp()
        {
            wallAnimator.SetBool("isDown", false); //Walls go up
        }
    }
}
