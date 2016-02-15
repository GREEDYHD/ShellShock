using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour
{
    public GameObject player;
    private PlayerActions _playerActions;
    private SpriteRenderer reticleRenderer;

    Vector2 mDefaultPosition = new Vector2(0.0f, 0.0f);

    float Range = 1f; //Range the reticle can move from the origin(player)
    Vector2 mAimDirection;
    Vector2 mPreviousAimDirection = new Vector2(0.0f, 0.0f);
    Vector2 mCorrectedAimDirection = new Vector2(0.0f, 0.0f);

    public GameObject mReticle;

    void Start()
    {
        reticleRenderer = GetComponent<SpriteRenderer>();
        _playerActions = player.GetComponent<PlayerActions>();
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
            return - mCorrectedAimDirection.normalized;
        }

        set
        {
            mCorrectedAimDirection = value.normalized;
        }
    }

    public float AimAngle
    {
        get
        {
            return mAimAngle;
        }

        set
        {
            mAimAngle = value;
        }
    }

    private float mAimAngle;
    void Update()
    {
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        mAimDirection = new Vector2(Input.GetAxis("Player_" + GetComponent<Player>().PlayerNumber + "_RJoystickX"), Input.GetAxis("Player_" + GetComponent<Player>().PlayerNumber + "_RJoystickY")).normalized;

        //mReticle.gameObject.SetActive(false);
        if (mAimDirection != mPreviousAimDirection && mAimDirection.magnitude > 0)
        {
            //Rounds to the nearest 45 degrees to match the sprite
            int spriteNumber = Mathf.RoundToInt(((mAimDirection.SignedAngle() <= -157.5f ? 180 : mAimDirection.SignedAngle()) + 180) / 45);

            mCorrectedAimDirection = new Vector2((Mathf.Sin(spriteNumber * 45 * Mathf.Deg2Rad)), (Mathf.Cos(spriteNumber * 45 * Mathf.Deg2Rad))).normalized * Range;

            mReticle.transform.position = mDefaultPosition + playerPosition - mCorrectedAimDirection * 2;

            SpriteManager.instance.ChangeSprite(spriteNumber);
            mPreviousAimDirection = mAimDirection;
        }
    }

    void ChangePlayerSprite()
    {
        
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