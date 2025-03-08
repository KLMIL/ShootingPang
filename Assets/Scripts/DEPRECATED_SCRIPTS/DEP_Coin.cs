using UnityEngine;

public class DEP_Coin : MonoBehaviour
{
    Rigidbody2D _rigid2D;
    SpriteRenderer _sprite;

    float changeTime;

    private void Start()
    {
        _rigid2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //�ӵ� ���� ����
        if (_rigid2D.linearVelocity != Vector2.zero)
        {
            _rigid2D.linearVelocity -= _rigid2D.linearVelocity * Time.deltaTime;
        }
    }
}
