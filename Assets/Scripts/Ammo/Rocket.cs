using UnityEngine;
using System.Collections;
namespace ShellShock
{
    public class Rocket : Projectile
    {

        void Awake()
        {
            bouncesAllowed = 20f;
        }
        void Update()
        {
            if (currentBounces > bouncesAllowed)
            {
                Destroy(gameObject);
            }
            Vector3 dir = (Vector2)transform.position - mRigidBody.velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        }

        void OnCollisionEnter2D(Collision2D bulletCollider)
        {
            currentBounces++;
        }
    }
}
