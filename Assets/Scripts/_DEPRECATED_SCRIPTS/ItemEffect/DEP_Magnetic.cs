using UnityEngine;

public class DEP_Magnetic : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] LayerMask layerMask;

    //타겟 당기기
    public void Pull()
    {
        //스캔된 오브젝트들
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
