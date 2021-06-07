using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] DicePrefabs;
    public Text resultText;

    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    private List<CheckNum> checkNums = new List<CheckNum>();
    private CalcComb calcComb;

    private string[] numList = new string[5];

    // Start is called before the first frame update
    void Start()
    {
        calcComb = GetComponent<CalcComb>();

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

        var given_list = GetNumArray();
        resultText.text = printResult(given_list);
        
    }

    private void Reset(GameObject  gameObject)
    {
        var _rotate = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        var _position = new Vector3(Random.Range(-1.5f, 3.0f), Random.Range(5.0f, 8.0f), Random.Range(1.0f, 3.0f));
        gameObject.transform.Rotate(_rotate);
        gameObject.transform.position = _position;
    }

    private List<string> GetNumArray()
    {
        var i = 0;
        foreach (var checknum in checkNums)
        {
            numList[i] = checknum.GetNumber();
            i++;
        }
        return numList.ToList<string>();
     }

    string printResult(List<string> givenList)
    {
        string chinko = calcComb.isChinko(givenList) ? "CHINKO " : " ";
        string manko = calcComb.isManko(givenList) ? "MANKO " : " ";
        string unko = calcComb.isUnko(givenList) ? "UNKO " : " ";
        string ochinchin = calcComb.isOchinchin(givenList) ? "OCHINCHIN " : " ";

        string printList = string.Join(", ", givenList.ToArray());
        Debug.Log("与えられたリスト：" + printList);
        Debug.Log("見つけた単語：" + chinko + manko + unko + ochinchin);

        return chinko + manko + unko + ochinchin;
    }

}
