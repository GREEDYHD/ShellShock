using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Author: Julian Stopher
public class DisplayAmmoCount : MonoBehaviour
{

    public Shotgun shotgun;
    public MiniGun minigun;
    public RocketLauncher rocketLauncher;

    public Text ammoCount;

    //going to need some way of telling each others ammo counts apart.
    public int playerID;

    public Player player;


    void Start()
    {



    }


    void Update()
    {
        //change the ammo count depending on which weapon the player has equipped.
        if (player.mEquippedWeapon == shotgun)
        {
            ammoCount.text = shotgun.mAmmoRemaining.ToString();
        }
            else if (player.mEquippedWeapon == minigun)
            {
                ammoCount.text = minigun.mAmmoRemaining.ToString();
            }
                else if (player.mEquippedWeapon == rocketLauncher)
                {
                    ammoCount.text = rocketLauncher.mAmmoRemaining.ToString();
                }
    }

}

