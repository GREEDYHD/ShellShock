using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SpriteOrderSorting : MonoBehaviour
{
    public GameObject mPlayer;
    public Camera mMainCamera;

    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 2);
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mMainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (gameObject.tag == "Wall")
        {
            if (mMainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mMainCamera.transform.position.z)).y + 0.4f > transform.position.y)
            {
                GetComponent<SpriteRenderer>().sortingLayerName = "WallsInFront";
            }
            else
            {
                GetComponent<SpriteRenderer>().sortingLayerName = "WallsBehind";
            }

        }
        //Debug.Log(mMainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mMainCamera.transform.position.z)));
    }
}
