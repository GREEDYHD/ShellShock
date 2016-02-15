using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelEditor : MonoBehaviour
{

    public Camera mMainCamera;

    public List<GameObject> mGameObjectList;

    [SerializeField]
    int mGameObjectIndex = 0;

    [SerializeField]
    GameObject mSelectedGameObject;

    SpriteRenderer mCursorSprite, mCursorBackgroundSprite;
    GameObject mCursorGameObject, mCursorBackgroundObject;
    Vector3 mMenuStartPos, mMenuDragPos;

    GameObject mObjectUnderCursor;

    public List<GameObject> mPlacedObjects;


    public bool isRadialMenuActive = false;

    void Start()
    {
        Cursor.visible = false;
        mSelectedGameObject = mGameObjectList[mGameObjectIndex];
        //mSelectedGameObject.AddComponent<SpriteOrderSorting>();
        mPlacedObjects = new List<GameObject>();
        InitialiseCursorObject();
    }

    void InitialiseCursorObject()
    {
        mCursorGameObject = new GameObject();
        mCursorGameObject.name = "Preview_Object";

        mCursorSprite = mCursorGameObject.AddComponent<SpriteRenderer>();
        mCursorSprite.sprite = mSelectedGameObject.GetComponent<SpriteRenderer>().sprite;
        mCursorSprite.color = new Color(1f, 1f, 1f, 0.7f);
        mCursorSprite.sortingLayerName = "UI";

        mCursorBackgroundObject = new GameObject();
        mCursorBackgroundObject.name = "Preview_Object_BackGround";

        mCursorBackgroundSprite = mCursorBackgroundObject.AddComponent<SpriteRenderer>();
        mCursorBackgroundSprite.sprite = mCursorSprite.sprite;
        mCursorBackgroundSprite.sortingLayerName = "UI";
        mCursorBackgroundSprite.material.shader = Shader.Find("GUI/Text Shader");
        mCursorBackgroundSprite.sortingOrder = mCursorSprite.sortingOrder - 1;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(-mMainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mMainCamera.transform.position.z)), -Vector3.forward);
        Debug.DrawRay(-mMainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mMainCamera.transform.position.z)), -Vector3.forward);
        {
            if (hit.collider != null)
            {
                mObjectUnderCursor = hit.collider.gameObject;
                SetPreviewPostion(mObjectUnderCursor.transform.position);
            }
            else
            {
                mObjectUnderCursor = null;
            }
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (mObjectUnderCursor)
            {
                mPlacedObjects.Remove(mObjectUnderCursor);
                Destroy(mObjectUnderCursor);
            }
        }

        if (Input.mouseScrollDelta.y > 1f)
        {
            mGameObjectIndex = mGameObjectIndex < mGameObjectList.Count ? 0 : mGameObjectIndex++;
        }

        if (Input.mouseScrollDelta.y < -1f)
        {
            mGameObjectIndex = mGameObjectIndex > 0 ? mGameObjectList.Count : mGameObjectIndex--;
        }
        isRadialMenuActive = Input.GetMouseButton(1);

        mCursorGameObject.transform.position = GetSnapPos(mMainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mMainCamera.transform.position.z)));
        mCursorBackgroundSprite.transform.position = mCursorGameObject.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            mSelectedGameObject = Instantiate(mGameObjectList[mGameObjectIndex]);
            mSelectedGameObject.transform.position = mCursorGameObject.transform.position;
            mSelectedGameObject.AddComponent<SpriteOrderSorting>();
            mSelectedGameObject.name = mSelectedGameObject.GetComponent<SpriteRenderer>().sprite.name + "_GameObject";
            mPlacedObjects.Add(mSelectedGameObject);

            mSelectedGameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Z) && mPlacedObjects.Count > 0)
        {
            Destroy(mPlacedObjects[mPlacedObjects.Count - 1]);
            mPlacedObjects.RemoveAt(mPlacedObjects.Count - 1);
            Debug.Log("UNDO");
        }


        if (Input.GetMouseButtonDown(1))
        {
            mMenuStartPos = (mMainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mMainCamera.transform.position.z)));
            Debug.Log(mMenuStartPos);
        }

        if (Input.GetMouseButtonUp(1))
        {
            mMenuDragPos = (mMainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mMainCamera.transform.position.z)));
        }


        Debug.Log(((Vector2)mMainCamera.ScreenToWorldPoint(Input.mousePosition)).toIso());
        if (isRadialMenuActive)
        {
            mMenuDragPos = (mMainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)));
            Vector3 selDirection = (mMenuDragPos - mMenuStartPos).normalized;

            Debug.DrawLine(mMenuStartPos, mMenuStartPos + selDirection * 5);

            //Debug.Log(selDirection.SignedAngle());
            Debug.Log((selDirection.normalized.SignedAngle().DegreeToVector2()));
            //Debug.Log(selDirection.SignedAngle().Vector2FromAngle());
        }
    }

    Vector2 GetMousePos(Vector2 vec)
    {
        //float x = mMainCamera.ScreenToViewportPoint(vec).x;
        //float y = mMainCamera.ScreenToViewportPoint(vec).y;

        //float x = mMainCamera.ScreenToWorldPoint(vec).x;
        //float y = mMainCamera.ScreenToWorldPoint(vec).y;

        float x = SnapToGrid((int)vec.x, 5);
        float y = SnapToGrid((int)vec.y, 5);

        return new Vector2(x, y);
    }

    Vector2 GetSnapPos(Vector2 vec)
    {
        float x = new float();
        float y = new float();

        if ((int)vec.x % 4 == 0)
        {
            x = SnapToGrid((int)Mathf.RoundToInt(vec.x), 4);
            y = SnapToGrid((int)Mathf.RoundToInt(vec.y), 2);
        }
        else if ((int)vec.y % 4 == 0)
        {
            x = SnapToGrid((int)Mathf.RoundToInt(vec.x), 2);
            y = SnapToGrid((int)Mathf.RoundToInt(vec.y), 4) - 1;
        }
        else
        {
            x = SnapToGrid((int)Mathf.RoundToInt(vec.x), 2);
            y = SnapToGrid((int)Mathf.RoundToInt(vec.y), 2) + 1;
        }
        return new Vector2(x, y);
    }

    void SetPreviewPostion(Vector2 pos)
    {
        mCursorGameObject.transform.position = pos;
        mCursorBackgroundObject.transform.position = pos;
    }

    int SnapToGrid(int value, int snapNumber)
    {
        return snapNumber * (int)Mathf.Round(value / snapNumber);
    }
}
