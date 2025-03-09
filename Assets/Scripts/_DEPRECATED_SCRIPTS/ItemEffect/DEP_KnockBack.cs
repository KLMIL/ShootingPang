using UnityEngine;

public class DEP_KnockBack : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] LayerMask layerMask;

    [SerializeField] float pushPower;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Push();
        }
    }

    //Ÿ�� ����
    public void Push()
    {
        //��ĵ�� ������Ʈ��
        RaycastHit2D[] targets2D = Physics2D.CircleCastAll(transform.position, radius, Vector2.up, 0, layerMask);

        foreach (RaycastHit2D target2D in targets2D)
        {
            if (target2D.transform.CompareTag("Block"))
            {
                Vector2 dir = target2D.transform.position - transform.position;
                dir = dir.normalized;

                Rigidbody2D _rigid2D = target2D.transform.GetComponent<Rigidbody2D>();
                _rigid2D.AddForce(dir* pushPower, ForceMode2D.Impulse);
            }
        }
    }
}
