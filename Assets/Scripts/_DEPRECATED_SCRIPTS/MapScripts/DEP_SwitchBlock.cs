using UnityEngine;

public class DEP_SwitchBlock : MonoBehaviour
{
    public bool isOn;
    public AudioClip sfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOn = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOn = !isOn;

        //SoundsPlayer.Instance.PlaySFX(sfx);
    }
}
