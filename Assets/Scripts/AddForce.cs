using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGravity = false;

    void Start()
    {
        rb =  GetComponent<Rigidbody>();
        Reset();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isGravity)
        {
            rb.useGravity = true;
            var torque = new Vector3(Random.Range(1f, 15f), Random.Range(0f, 20f), Random.Range(1f, 18f));
            rb.AddTorque(torque, ForceMode.Impulse);
            var velocity = new Vector3(Random.Range(-3f, 3f), Random.Range(-2f, 2f), Random.Range(-3f, 3f));
            rb.AddForce(velocity, ForceMode.Impulse);
            isGravity = true;
        }

        if(Input.GetMouseButtonDown(1))
        {
            Reset();
        }
    }

    private void Reset()
    {
        var rotate = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        transform.Rotate(rotate);
        var position = new Vector3(0f, 7f, 0f);
        transform.position = position;
    }
}
