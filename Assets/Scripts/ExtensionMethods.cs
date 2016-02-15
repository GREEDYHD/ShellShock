using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{
    public static Vector2 Vector2(this Vector3 vec)
    {
        return new Vector2(vec.x, vec.y);
    }

    //public static Vector3 Vector3_2D(this Vector3 vec)
    //{
    //    return new Vector3(vec.x, vec.y, 0);
    //}

    public static float SignedAngle(this Vector3 dir)
    {
        return dir.x < 0 ? 360 - (Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1) : Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
    }

    public static float SignedAngle(this Vector2 dir)
    {
        return dir.x < 0 ? 360 - (Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1) : Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
    }

    public static Vector2 Vector2FromAngle(this float angle)
    {
        return new Vector2(Mathf.Acos(angle * Mathf.Deg2Rad), Mathf.Asin(angle * Mathf.Deg2Rad));
    }

    public static Vector2 RadianToVector2(this float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
    public static Vector2 RadianToVector2(float radian, float length)
    {
        return RadianToVector2(radian) * length;
    }
    public static Vector2 DegreeToVector2(this float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    public static Vector2 DegreeToVector2(float degree, float length)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad) * length;
    }
    public static Vector2 toIso(this Vector2 vec)
    {
        return new Vector2((vec.x - vec.y), (vec.x + vec.y) / 2.0f);
    }
    public static Vector3 toCart(this Vector3 vec)
    {
        return (new Vector3((vec.y * 2.0f + vec.x) / 2.0f, (2 * vec.y - vec.x) / 2.0f, 0.0f));
    }
}
