using UnityEngine;

public class DEP_BeInvincible : MonoBehaviour
{
    LayerMask mask = 1 << 7;

    public void GetInvincible()
    {
        gameObject.layer = mask;
    }
}
