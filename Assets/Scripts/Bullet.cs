using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerController playercontroller;

    Rigidbody2D rb;
    LineRenderer lineRenderer;

    bool isStarted = false;
    bool isDragging = false;
    Vector2 releasePosition;

    public bool isDestroyed = false; // �ʿ����?
    

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
