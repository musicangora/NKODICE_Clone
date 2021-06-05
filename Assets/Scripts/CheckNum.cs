using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNum : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public int GetNumber()
    {
        if (!_rb.IsSleeping()) return 0;

        int result = 0;

        // ワールドのupをローカルに変換
        Vector3 vector = transform.InverseTransformDirection(Vector3.up);

        if (isMaxX(vector)) result = (vector.x > 0f) ? 4 : 3;
        if (isMaxY(vector)) result = (vector.y > 0f) ? 5 : 2;
        if (isMaxZ(vector)) result = (vector.z > 0f) ? 1 : 6;

        return result;
    }
   
    bool isMaxX(Vector3 vector)
    {
        return ((Mathf.Abs(vector.x) > Mathf.Abs(vector.y)) && (Mathf.Abs(vector.x) > Mathf.Abs(vector.z))) ? true : false;
    }

    bool isMaxY(Vector3 vector)
    {
        return ((Mathf.Abs(vector.y) > Mathf.Abs(vector.x)) && (Mathf.Abs(vector.y) > Mathf.Abs(vector.z))) ? true : false;
    }

    bool isMaxZ(Vector3 vector)
    {
        return ((Mathf.Abs(vector.z) > Mathf.Abs(vector.y)) && (Mathf.Abs(vector.z) > Mathf.Abs(vector.x))) ? true : false;
    }

}
