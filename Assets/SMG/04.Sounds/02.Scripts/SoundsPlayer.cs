using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    public static SoundsPlayer Instance { get; private set; }
    private AudioSource audio;

    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 변경되어도 유지됨
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스 삭제
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip sfx)
    {
        audio.PlayOneShot(sfx);
    }

    public void PlaySFX(AudioClip sfx, float time)
    {
        audio.PlayOneShot(sfx);
        Invoke("StopPlay", time);
    }

    public void StopPlay()
    {
        audio.Stop();
    }
}
