using UnityEngine;
using System.Collections;

public class SpriteOrderSorting : MonoBehaviour
{
    public GameObject mPlayer;
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 2);
    }

    void Update()
    {
        if (gameObject.tag == "Wall")
        {
            if (mPlayer.transform.position.y > transform.position.y)
            {
                GetComponent<SpriteRenderer>().sortingLayerName = "WallsInFront";
            }
            else
            {
                GetComponent<SpriteRenderer>().sortingLayerName = "WallsBehind";
            }
        }
    }
}
