using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RaphExtends
{


    //VECTORS
    public static Vector2 ToVector2XY(this Vector3 v)
    {

        ///<summary>
        ///<para>return new Vector2(v.x, v.y);</para>
        ///</summary>
        return new Vector2(v.x, v.y);

    }

    public static Vector2 ToVector2YZ(this Vector3 v)
    {
        return new Vector2(v.y, v.z);
    }

    public static Vector2 ToVector2XZ(this Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }
    ///<summary>
    ///return new Vector3(v.x, v.y, 0)
    ///</summary>
    public static Vector3 ToVector3Z(this Vector2 v)
    {


        ///</summary>
        return new Vector3(v.x, v.y, 0);
    }

    public static Vector3 ToVector3Y(this Vector2 v)
    {
        ///<summary>
        ///<para> return new Vector3(v.x, 0, v.y);</para>
        ///</summary>
        return new Vector3(v.x, 0, v.y);
    }

    public static Vector3 ToVector3X(this Vector2 v)
    {
        ///<summary>
        ///<para>return new Vector3(0, v.x, v.y);</para>
        ///</summary>
        return new Vector3(0, v.x, v.y);
    }

    public static Vector2 Abs(this Vector2 v)
    {
        return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
    }



    public static Transform Find(this Transform t, string name)
    {
        return GameObject.Find(name).transform;
    }


}

public class InputExtend : Input
{
    public static Vector2 WorldMousePos() { return Camera.main.ScreenToWorldPoint(Input.mousePosition); }

    public static Vector2 Direction2D()
    {
        Vector2 res = Vector2.zero;
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.I))
            res.y = 1;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.K))
            res.y = -1;

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.J))
            res.x = -1;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.L))
            res.x = 1;

        res = res.normalized;

        return res;
    }
}