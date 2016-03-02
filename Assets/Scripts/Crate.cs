using UnityEngine;
using System.Collections;
namespace ShellShock
{
    public class Crate : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.GetComponent<ShellShock.Player>())
            {
                coll.gameObject.GetComponent<ShellShock.Player>().ChangeWeapon(Random.Range(0, 7));
                //Destroy(gameObject.transform.parent.transform.parent.gameObject);
            }
        }
    }
}
