﻿using UnityEngine;
using System.Collections;

public class Crate : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<Player>())
        {
            coll.gameObject.GetComponent<Player>().ChangeWeapon(Random.Range(0, 7));
            //Destroy(gameObject.transform.parent.transform.parent.gameObject);
        }
    }
}
