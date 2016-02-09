using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour
{
    public GameObject ballObj;

    public bool isBallin = false; //curled up in a ball

    private SpriteRenderer playerRenderer;
    private Collider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButton("Player_" + GetComponent<Player>().PlayerNumber + "_Ball"))
        {
            Debug.Log(GetComponent<Player>().PlayerNumber);
            isBallin = true;
            PlayerRender();
            GetComponent<Aiming>().ReticleRender();
            ballObj.GetComponent<Ball>().BallRender();
        }

        if (Input.GetButtonUp("Player_" + GetComponent<Player>().PlayerNumber + "_Ball"))
        {
            isBallin = false;
            PlayerRender();
            GetComponent<Aiming>().ReticleRender();
            ballObj.GetComponent<Ball>().BallRender();
        }
    }

    void PlayerRender()
    {
        if (isBallin == false)
        {
            playerCollider.enabled = true;
            playerRenderer.enabled = true;
        }

        if (isBallin == true)
        {
            playerCollider.enabled = false;
            playerRenderer.enabled = false;
        }
    }
}
