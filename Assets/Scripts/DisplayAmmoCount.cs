using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DisplayAmmoCount : MonoBehaviour
{
	public Pistol pistol;
	public AssaultRifle assualtRifle;
    public Shotgun shotgun;
	public Sniper sniper;
    public MiniGun minigun;
    public RocketLauncher rocketLauncher;
	public GrenadeLauncher grenadeLauncher;

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
					else if (player.mEquippedWeapon == pistol)
					{
						ammoCount.text = pistol.mAmmoRemaining.ToString();
					}
						else if (player.mEquippedWeapon == assualtRifle)
							{
								ammoCount.text = assualtRifle.mAmmoRemaining.ToString();
							}
							else if (player.mEquippedWeapon == sniper)
								{
									ammoCount.text = sniper.mAmmoRemaining.ToString();
								}
								else if (player.mEquippedWeapon == grenadeLauncher)
									{
										ammoCount.text = grenadeLauncher.mAmmoRemaining.ToString();
									}
    }

}

