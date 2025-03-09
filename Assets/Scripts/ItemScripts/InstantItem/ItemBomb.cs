using UnityEngine;

public class ItemBomb : _InstantItem
{
    [SerializeField]
    private float explosionRange = 5.0f;

    // 터지는 효과. collider 충돌 이용
    // 기존 코드에서는 collider.enable = true를 이용함
}
