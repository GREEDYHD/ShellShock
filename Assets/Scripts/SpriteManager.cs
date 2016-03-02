using UnityEngine;
using System.Collections;

namespace ShellShock
{
    public class SpriteManager : MonoBehaviour
    {

        public Sprite[] playerSprites;
        public GameObject player;
        private SpriteRenderer playerSR;

        public static SpriteManager instance;

        void Start()
        {
            instance = this;
            playerSR = player.GetComponent<SpriteRenderer>();

        }

        void Update()
        {
            //ChangeSprite (9);
        }

        public void ChangeSprite(int spriteNum)
        {
            if (spriteNum > 8 && spriteNum < 0)
            {
                Debug.LogError(spriteNum);
            }
            playerSR.sprite = playerSprites[spriteNum];
        }
    }
}
