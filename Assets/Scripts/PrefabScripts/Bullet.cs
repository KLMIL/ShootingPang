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

    public bool isDestroyed = false; // �ʿ����?


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
            // �浹 �Ҹ� ���
        }
    }

    private void OnTriggerEnte2Dr(Collider2D other)
    {
        // ���� �� ����
    }



    public void OnMouseDownEvent()
    {
        // ���η����� ������ֱ�
    }

    public void OnMouseDragEvent()
    {
        // ��ġ ����ؼ� ����
    }

    public void OnMouseUpEvent()
    {
        // �߻��ϰ� ����ó�� -> ���Ŵ� ������ �ϴ°� ����. 
    }
}
