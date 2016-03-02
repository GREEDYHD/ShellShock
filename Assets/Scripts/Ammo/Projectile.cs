using UnityEngine;
using System.Collections;

namespace ShellShock
{
    public class Projectile : MonoBehaviour
    {
        protected float bouncesAllowed = 3;
        protected float currentBounces = 0;

        protected Vector2 mVelocity;

        private int mOwnerID;

        protected float skinWidth = 0.1f;
        protected float minimumExtent;
        protected float partialExtent;
        protected float sqrMinimumExtent;

        protected Vector2 mPreviousPosition;
        protected Rigidbody2D mRigidBody;
        protected int mDamage;

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

        public int OwnerID
        {
            get
            {
                return mOwnerID;
            }

            set
            {
                mOwnerID = value;
            }
        }

        void Start()
        {
            minimumExtent = Mathf.Min(Mathf.Min(GetComponent<CircleCollider2D>().bounds.extents.x, GetComponent<CircleCollider2D>().bounds.extents.y), GetComponent<CircleCollider2D>().bounds.extents.z);
            partialExtent = minimumExtent * (1.0f - skinWidth);
            sqrMinimumExtent = minimumExtent * minimumExtent;
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

        public virtual void Fire(Vector2 vel, int damage, int id)
        {
            mVelocity = vel;
            mOwnerID = id;
            mRigidBody = gameObject.GetComponent<Rigidbody2D>();
            mRigidBody.velocity = mVelocity;
            mDamage = damage;
            Vector3 dir = vel.normalized;
            //Debug.Log(dir);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Destroy(gameObject, 5f);
        }

        void OnCollisionEnter2D(Collision2D bulletCollider)
        {
            currentBounces++;
        }

        //Fixed Update runs on every physics tick
        void FixedUpdate()
        {
            //have we moved more than our minimum extent? 
            Vector2 movementThisStep = mRigidBody.position - mPreviousPosition;
            float movementSqrMagnitude = movementThisStep.sqrMagnitude;

            if (movementSqrMagnitude > sqrMinimumExtent)
            {
                float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);
                RaycastHit hitInfo;

                //check for obstructions we might have missed 
                if (Physics.Raycast(mPreviousPosition, movementThisStep, out hitInfo, movementMagnitude))
                {
                    if (!hitInfo.collider)
                        return;

                    if (hitInfo.collider.isTrigger)
                        hitInfo.collider.SendMessage("OnTriggerEnter", GetComponent<CircleCollider2D>());

                    if (!hitInfo.collider.isTrigger)
                        mRigidBody.position = (Vector2)hitInfo.point - (movementThisStep / movementMagnitude) * partialExtent;
                }
            }

            mPreviousPosition = mRigidBody.position;
        }
    }
}