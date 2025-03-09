using UnityEngine;
using UnityEngine.Rendering;

public class DEP_SoundsPlayer : MonoBehaviour
{
    public static DEP_SoundsPlayer Instance { get; private set; }
    private AudioSource audio;

    private void Awake()
    {
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // ���� ����Ǿ ������
        }
        else
        {
            Destroy(gameObject); // �ߺ��� �ν��Ͻ� ����
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip sfx, float volume)
    {
        audio.PlayOneShot(sfx, volume);
    }
    
    public void PlaySFX(AudioClip sfx)
    {
        PlaySFX(sfx, 0.8f);
    }

    public void PlaySFX(AudioClip sfx, float volume, float time)
    {
        PlaySFX(sfx, volume);
        Invoke("StopPlay", time);
    }

    public void StopPlay()
    {
        audio.Stop();
    }
}
