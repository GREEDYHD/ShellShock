using UnityEngine;
using System.Collections;

namespace ShellShock
{
    public class MovementISO : MonoBehaviour
    {

        public SpriteManager spriteManager;

        // Use this for initialization
        void Start()
        {
            //spriteManager = GetComponent<ShellShock.SpriteManager> ();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                spriteManager.ChangeSprite(1);

            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                spriteManager.ChangeSprite(2);

            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                spriteManager.ChangeSprite(3);

            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                spriteManager.ChangeSprite(4);
            }

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                spriteManager.ChangeSprite(0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                spriteManager.ChangeSprite(5);
            }
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                spriteManager.ChangeSprite(6);
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                spriteManager.ChangeSprite(7);
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                spriteManager.ChangeSprite(8);
            }
        }
    }
}
