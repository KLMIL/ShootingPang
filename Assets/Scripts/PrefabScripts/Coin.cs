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


    // 원래 Coin 밑의 Eat 객체에 따로 스크립트로 선언됐던 부분
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            gameManager.CollectCoin();
            Destroy(transform.parent.gameObject);

            // 동전 먹는 소리 실행
        }
    }
}
