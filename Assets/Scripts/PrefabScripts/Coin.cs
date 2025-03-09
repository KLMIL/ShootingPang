using UnityEngine;

public class Coin : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    float changeTime;

    GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (rb.linearVelocity != Vector2.zero)
        {
            rb.linearVelocity -= rb.linearVelocity * Time.deltaTime; ;
        }
    }


    // ���� Coin ���� Eat ��ü�� ���� ��ũ��Ʈ�� ����ƴ� �κ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            gameManager.CollectCoin();
            Destroy(transform.parent.gameObject);

            // ���� �Դ� �Ҹ� ����
        }
    }
}
