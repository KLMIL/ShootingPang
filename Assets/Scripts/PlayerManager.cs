using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // ���� ���� ��ũ��Ʈ
    // �÷��̾��� ������ ���õ� ���
    public static PlayerManager Instance { get; private set; }

    public GameObject BulletPrefab;
    public bool isItemSelected = false;
    public List<ParticleSystem> itemParticles;

    GameManager gameManager;
    ItemManager itemManager;
    PlayerController playerController;
    PlayerHUDController playerHUDController;

    private int selectedItem = -1;
    private bool isSelectAvailable = false;
    private bool isBulletDestroyed = false;
    private bool isPlayAvailable = false;

    // Bullet ���� �ʵ�
    float maxBulletPower = 40f;
    float maxLineLength = 1.5f;
    float speedDamping = 0.98f;
    float stopThreshold = 0.1f;





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
        gameManager = GameManager.Instance;
        itemManager = ItemManager.Instance;
        playerController = PlayerController.Instance;
        playerHUDController = PlayerHUDController.Instance;
    }


    public void MakeBullet()
    {
        Instantiate(BulletPrefab, gameObject.transform.position, Quaternion.identity);
    }

    public void SelectItem(int itemIndex)
    {
        // itemManager�� UseItem() �Լ� ȣ�� �� selectedItem ���� �ʱ�ȭ 

    }
}
