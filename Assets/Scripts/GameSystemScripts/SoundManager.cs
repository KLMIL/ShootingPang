using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource audio;

    // bullet Audio
    public AudioClip backgroundHitSound;
    public AudioClip pointCollectSound;
    public AudioClip bombCollectSound;
    public AudioClip bombSfx;
    public AudioClip magneticSfx;
    public AudioClip knockBackSfx;

    // Coin Audio
    // ���� ���� �� �Ҹ� sfx �־���� 


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();   
    }


    public void PlaySFX(AudioClip sfx, float volume, float time)
    {
        PlaySFX(sfx, volume);
        Invoke("StopPlay", time);
    }
    public void PlaySFX(AudioClip sfx, float volume)
    {
        audio.PlayOneShot(sfx, volume);
    }

    public void PlaySFX(AudioClip sfx)
    {
        PlaySFX(sfx, 0.8f);
    }


    private void StopPlay()
    {
        audio.Stop();
    }
}
