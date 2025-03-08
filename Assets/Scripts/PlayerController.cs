using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �÷��̾��� ���۰� ���õ� ���
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
        // KeyDown Event Listener �Լ�
    }


    private void SelectItem(int itemIndex)
    {
        playerManager.SelectItem(itemIndex);
    }

}
