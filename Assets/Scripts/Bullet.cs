using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerController playercontroller;

    Rigidbody2D rb;
    LineRenderer lineRenderer;

    bool isStarted = false;
    bool isDragging = false;
    Vector2 releasePosition;

    public bool isDestroyed = false; // 필요없나?
    

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
