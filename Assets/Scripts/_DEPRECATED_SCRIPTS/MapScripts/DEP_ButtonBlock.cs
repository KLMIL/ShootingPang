using UnityEngine;

public class DEP_ButtonBlock : MonoBehaviour
{
    public bool isPush;
    public AudioClip sfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPush = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isPush = true;

        DEP_SoundsPlayer.Instance.PlaySFX(sfx);
    }
}
