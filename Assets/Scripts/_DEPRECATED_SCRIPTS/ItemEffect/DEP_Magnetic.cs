using UnityEngine;

public class DEP_Magnetic : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] LayerMask layerMask;

    //Ÿ�� ����
    public void Pull()
    {
        //��ĵ�� ������Ʈ��
        RaycastHit2D[] targets2D = Physics2D.CircleCastAll(transform.position, radius, Vector2.up, 0, layerMask);
        
        
        //Debug.Log(targets2D.Length);

        foreach (RaycastHit2D target2D in targets2D)
        {
            if (target2D.transform.CompareTag("Coin"))
            {
                Vector2 dir = transform.position - target2D.transform.position;
                float pullPower = dir.magnitude;
                dir = dir.normalized * pullPower;

                Rigidbody2D _rigid2D = target2D.transform.GetComponent<Rigidbody2D>();
                _rigid2D.AddForce(dir, ForceMode2D.Impulse);
            }
        }
    }
}
