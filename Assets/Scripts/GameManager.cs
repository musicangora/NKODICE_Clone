using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] DicePrefabs;
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    private List<CheckNum> checkNums = new List<CheckNum>();

    int[] numList = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject dicePrefab in DicePrefabs)
        {
            Reset(dicePrefab);

            var _rb = dicePrefab.GetComponent<Rigidbody>();
            _rb.useGravity = false;
            rigidbodies.Add(_rb);

            var _cn = dicePrefab.GetComponent<CheckNum>();
            checkNums.Add(_cn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.useGravity = true;
                var torque = new Vector3(Random.Range(1f, 15f), Random.Range(0f, 20f), Random.Range(1f, 18f));
                rigidbody.AddTorque(torque, ForceMode.Impulse);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            foreach (GameObject dicePrefab in DicePrefabs)
            {
                Reset(dicePrefab);
            }
        }

        GetNumArray();
        
    }

    private void Reset(GameObject  gameObject)
    {
        var _rotate = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        var _position = new Vector3(Random.Range(-1.5f, 3.0f), Random.Range(5.0f, 8.0f), Random.Range(1.0f, 3.0f));
        gameObject.transform.Rotate(_rotate);
        gameObject.transform.position = _position;
    }

    private void GetNumArray()
    {
        var i = 0;
        foreach (var checknum in checkNums)
        {
            numList[i] = checknum.GetNumber();
            i++;
        }
        if (numList.Sum() > 0)
        {
            Debug.Log(string.Join(", ", numList));
        }
     }

}
