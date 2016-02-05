using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float bouncesAllowed;
    public float currentBounces;

    Vector2 mVelocity;
    Rigidbody2D mRigidBody;
    int mDamage;

    public int Damage
    {
        get
        {
            return mDamage;
        }
        set
        {
            mDamage = value;
        }
    }

    void Update()
    {
        if (currentBounces > bouncesAllowed)
        {
            Destroy(gameObject);
        }
        Vector3 dir = mRigidBody.velocity.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Fire(Vector2 vel, int damage)
    {
        mVelocity = vel;
        mRigidBody = gameObject.GetComponent<Rigidbody2D>();
        mRigidBody.velocity = mVelocity;
        mDamage = damage;
        Vector3 dir = vel.normalized;
        Debug.Log(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D bulletCollider)
    {
        currentBounces++;
    }
}