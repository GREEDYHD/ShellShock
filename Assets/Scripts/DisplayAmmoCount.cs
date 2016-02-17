using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DisplayAmmoCount : MonoBehaviour
{
    public Text ammoCount;
    public int playerID;

    public Player player;


    void Start()
    {



    }


    void Update()
    {
		ammoCount.text = player.mEquippedWeapon.mAmmoRemaining.ToString ();
    }

}

