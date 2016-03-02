using UnityEngine;
using System.Collections;
namespace ShellShock
{
    public class Movement : MonoBehaviour
    {
        public float mMovementSpeed;
        public PlayerActions _playerActions;
        Rigidbody2D mRigidBody2D;

        void Start()
        {
            mRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
            _playerActions = GetComponent<ShellShock.PlayerActions>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                mRigidBody2D.AddForce(new Vector2(0, mMovementSpeed));
            }
            if (Input.GetKey(KeyCode.A))
            {
                mRigidBody2D.AddForce(new Vector2(-mMovementSpeed, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                mRigidBody2D.AddForce(new Vector2(0, -mMovementSpeed));
            }
            if (Input.GetKey(KeyCode.D))
            {
                mRigidBody2D.AddForce(new Vector2(mMovementSpeed, 0));
            }

            if (_playerActions.isBallin == false)
            {
                mRigidBody2D.AddForce(mMovementSpeed * new Vector2(Input.GetAxisRaw("Player_" + GetComponent<ShellShock.Player>().PlayerNumber + "_LJoystickX"), Input.GetAxisRaw("Player_" + GetComponent<ShellShock.Player>().PlayerNumber + "_LJoystickY")));
            }

        }
    }
}