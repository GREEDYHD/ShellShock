using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ShellShock
{
    public class DisplayAmmoCount : MonoBehaviour
    {
        public Text ammoCount;
        public int playerID;

        public Player player;

        void Update()
        {
            if (player.mEquippedWeapon)
            {
                ammoCount.text = player.mEquippedWeapon.RemainingAmmo.ToString();
            }
        }
    }
}

