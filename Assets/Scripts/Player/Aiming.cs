using UnityEngine;
using System.Collections;

namespace ShellShock
{
    public class Aiming : MonoBehaviour
    {
        public GameObject player;
        private PlayerActions _playerActions;
        private SpriteRenderer reticleRenderer;
        public SpriteManager spriteManager;

        Vector2 mDefaultPosition = new Vector2(0.0f, 0.0f);

        float Range = 1f; //Range the reticle can move from the origin(player)
        Vector2 mAimDirection;
        Vector2 mPreviousAimDirection = new Vector2(0.0f, 0.0f);
        Vector2 mCorrectedAimDirection = new Vector2(0.0f, 0.0f);

        public GameObject mReticle;

        void Start()
        {
            reticleRenderer = GetComponent<SpriteRenderer>();
            _playerActions = player.GetComponent<ShellShock.PlayerActions>();
            reticleRenderer.enabled = true;
        }

        public Vector2 AimDirection
        {
            get
            {
                return mAimDirection;
            }
            set
            {
                mAimDirection = value;
            }
        }

        public Vector2 CorrectedAimDirection
        {
            get
            {
                return -mCorrectedAimDirection.normalized;
            }

            set
            {
                mCorrectedAimDirection = value.normalized;
            }
        }

        void Update()
        {
            Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
            mAimDirection = new Vector2(Input.GetAxis("Player_" + GetComponent<ShellShock.Player>().PlayerNumber + "_RJoystickX"), Input.GetAxis("Player_" + GetComponent<ShellShock.Player>().PlayerNumber + "_RJoystickY")).normalized;


            //mReticle.gameObject.SetActive(false);
            if (mAimDirection != mPreviousAimDirection && mAimDirection.magnitude > 0)
            {
                //Get the angle in degrees between the aim direction and the up direction
                float angle = Vector2.Angle(mAimDirection, Vector2.up);
                //Gets the sign value for the degrees as Vector2.Angle will round 270 to 90 degrees
                //Then multiplies it by the angle so 20 degrees becomes -90 degrees
                float sinedAngle = Mathf.Sign(Vector3.Cross(mAimDirection, Vector3.up).z) * angle;
                //Calculates the numerator for the 8 sections.  
                int spriteNumber = Mathf.RoundToInt(((sinedAngle <= -157.5f ? 180 : sinedAngle) + 180) / 45);

                mCorrectedAimDirection = new Vector2((Mathf.Sin(spriteNumber * 45 * Mathf.Deg2Rad)), (Mathf.Cos(spriteNumber * 45 * Mathf.Deg2Rad))) * Range;

                mReticle.transform.position = mDefaultPosition + playerPosition - (mCorrectedAimDirection) * 1.5f;
                //Debug.DrawLine (playerPosition, playerPosition + mAimDirection * Range);

                spriteManager.ChangeSprite(spriteNumber);
                // SpriteManager.instance.ChangeSprite(spriteNumber);
                mPreviousAimDirection = mAimDirection;
            }
        }

        public void ReticleRender()
        {
            if (_playerActions.isBallin == true)
            {
                reticleRenderer.enabled = false;
            }

            if (_playerActions.isBallin == false)
            {
                reticleRenderer.enabled = true;
            }
        }
    }
}