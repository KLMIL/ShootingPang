using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerController playercontroller;
    PlayerManager playerManager;

    Rigidbody2D rb;
    LineRenderer lineRenderer;

    bool isStarted = false;
    bool isDragging = false;
    Vector2 releasePosition;

    public bool isDestroyed = false; // 필요없나?


    private void Start()
    {
        playercontroller = PlayerController.Instance;
        playerManager = PlayerManager.Instance;

        rb = gameObject.GetComponent<Rigidbody2D>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity *= playerManager.speedDamping;
        if (rb.linearVelocity.magnitude < playerManager.stopThreshold)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BackGround")
            || collision.gameObject.CompareTag("Block"))
        {
            // 충돌 소리 재생
        }
    }

    private void OnTriggerEnte2Dr(Collider2D other)
    {
        // 딱히 뭐 안함
    }



    public void OnMouseDownEvent()
    {
        // 라인렌더러 만들어주기
    }

    public void OnMouseDragEvent()
    {
        // 위치 계산해서 조절
    }

    public void OnMouseUpEvent()
    {
        // 발사하고 제거처리 -> 제거는 딴데서 하는게 낫다. 
    }
}
