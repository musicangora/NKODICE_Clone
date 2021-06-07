using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcComb : MonoBehaviour
{
    void Start()
    {
        var givenList = new List<string>() { "う", "ち", "ん", "こ", "こ" };
        string chinko = isChinko(givenList) ? "ちんこ," : " ";
        string manko = isManko(givenList) ? "まんこ," : " ";
        string unko = isUnko(givenList) ? "うんこ," : " ";
        string ochinchin = isOchinchin(givenList) ? "おちんちん" : " ";

        string  printList = string.Join(", ", givenList.ToArray());
        Debug.Log("与えられたリスト：" + printList);
        Debug.Log("見つけた単語：" + chinko + manko + unko + ochinchin);
    }

    bool searchList(List<string> _givenList, string [] _searchList)
    {
        var _tmpList = new List<string>(_givenList);

        foreach (string _searchChar in _searchList)
        {
            if (!_tmpList.Contains(_searchChar)) return false;
            _tmpList.Remove(_searchChar);
        }
        return true;
    }


    public bool isChinko(List<string> _givenList)
    {
        var _searchWord = "ち ん こ";
        var _searchList = _searchWord.Split(' ');
        return searchList(_givenList, _searchList);
    }

    public bool isUnko(List<string> _givenList)
    {
        var _searchWord = "う ん こ";
        var _searchList = _searchWord.Split(' ');
        return searchList(_givenList, _searchList);
    }

    public bool isManko(List<string> _givenList)
    {
        var _searchWord = "ま ん こ";
        var _searchList = _searchWord.Split(' ');
        return searchList(_givenList, _searchList);
    }

    public bool isOchinchin(List<string> _givenList)
    {
        var _searchWord = "お ち ん ち ん";
        var _searchList = _searchWord.Split(' ');
        return searchList(_givenList, _searchList);
    }
}
