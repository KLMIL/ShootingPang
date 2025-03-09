using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 플레이어의 동작과 관련된 기능
    public static PlayerController Instance { get; private set; }

    PlayerManager playerManager;


    /* LifeCycle Function */
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
        playerManager = PlayerManager.Instance;
    }

    private void Update()
    {
        PlayerMouseEvent();
    }


    void PlayerMouseEvent()
    {

    }



    private void SelectItem(int itemIndex)
    {
        playerManager.SelectItem(itemIndex);
    }

}
