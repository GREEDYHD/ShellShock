using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class IsometricLayerSorter : MonoBehaviour
{
    SpriteRenderer mSpriteRenderer;
    void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mSpriteRenderer.sortingOrder = (int)-transform.position.y;
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y > transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "WallsInFront";
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "WallsBehind";
        }
    }
}
