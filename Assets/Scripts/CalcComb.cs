using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcComb : MonoBehaviour
{
    void Start()
    {
        var givenList = new List<string>() { "��", "��", "��", "��", "��" };
        string chinko = isChinko(givenList) ? "����," : " ";
        string manko = isManko(givenList) ? "�܂�," : " ";
        string unko = isUnko(givenList) ? "����," : " ";
        string ochinchin = isOchinchin(givenList) ? "�����񂿂�" : " ";

        string  printList = string.Join(", ", givenList.ToArray());
        Debug.Log("�^����ꂽ���X�g�F" + printList);
        Debug.Log("�������P��F" + chinko + manko + unko + ochinchin);
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
        var _searchWord = "�� �� ��";
        var _searchList = _searchWord.Split(' ');
        return searchList(_givenList, _searchList);
    }

    public bool isUnko(List<string> _givenList)
    {
        var _searchWord = "�� �� ��";
        var _searchList = _searchWord.Split(' ');
        return searchList(_givenList, _searchList);
    }

    public bool isManko(List<string> _givenList)
    {
        var _searchWord = "�� �� ��";
        var _searchList = _searchWord.Split(' ');
        return searchList(_givenList, _searchList);
    }

    public bool isOchinchin(List<string> _givenList)
    {
        var _searchWord = "�� �� �� �� ��";
        var _searchList = _searchWord.Split(' ');
        return searchList(_givenList, _searchList);
    }
}
