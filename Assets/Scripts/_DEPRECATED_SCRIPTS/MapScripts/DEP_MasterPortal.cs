using System.Collections.Generic;
using UnityEngine;

/*
 * [������ ��Ż]
 * ��Ż��� ����
 * ��Ż�� 2���̻��� ��Ż�� �� �����̹Ƿ�, �̸� �����ϴ� ����� ������
 */

public class DEP_MasterPortal : MonoBehaviour
{
    List<int> inObjectIDList;// = new List<int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inObjectIDList = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetIDList()
    {
        inObjectIDList.Clear();
    }

    public void AddID(int id)
    {
        inObjectIDList.Add(id);
    }



    public bool FindID(int findID)
    {
        bool isFind = false;

        foreach (int id in inObjectIDList)
        {
            if (id == findID)
            {
                isFind = true;
                break;
            }
        }

        return isFind;
    }
}
