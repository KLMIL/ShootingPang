using System.Collections;
using UnityEngine;

public  class DEP_Effect : MonoBehaviour
{
    public GameObject[] effects;
    int i = 0;

    private void Update()
    {
        StartCoroutine(Test());
    }

    //�׽�Ʈ
    IEnumerator Test()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            effects[i % 4].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            effects[i % 4].SetActive(false);
            i++;
        }
    }

    //i��° ���ӿ�����Ʈ Ȱ��ȭ
    //����Ʈ ��Ȱ��ȭ�� �Ѿ��� �����Ǵ� �ɷ�
    public void PlayEffect(int i)
    {
        if (i >= effects.Length) return;
        
        effects[i].SetActive(true);
    }
}
