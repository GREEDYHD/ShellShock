using UnityEngine;
using System.Collections;
namespace ShellShock
{
    public class Ball : MonoBehaviour
    {

        public GameObject player;
        private SpriteRenderer ballRenderer;
        private Collider2D ballCollider;
        private Rigidbody2D rb;

        void Start()
        {
            ballCollider = GetComponent<Collider2D>();
            ballRenderer = GetComponent<SpriteRenderer>();
            rb = player.GetComponentInParent<Rigidbody2D>();
            ballCollider.enabled = false;
            ballRenderer.enabled = false;
        }

        public void BallRender()
        {
            if (player.GetComponent<ShellShock.PlayerActions>().isBallin == true)
            {
                Debug.Log("Hi");
                Debug.Log(rb.drag);
                float tCount = 0.0f;
                tCount += Time.deltaTime;
                rb.drag = 8.5f;
                //rb.velocity = rb.AddForce(new Vector2(rb.drag);
                if (tCount >= 3.0f)
                {
                    ballCollider.enabled = true;
                    ballRenderer.enabled = true;
                }

            }

            if (player.GetComponent<ShellShock.PlayerActions>().isBallin == false)
            {
                rb.drag = 100;
                //rb.AddForce(new Vector2(player.transform.position.x, rb.drag));
                // rb.AddForce(new Vector2(rb.drag, player.transform.position.y));
                ballCollider.enabled = false;
                ballRenderer.enabled = false;
            }
        }
    }
}