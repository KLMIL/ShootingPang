using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DEP_PlayerController : MonoBehaviour
{
    public static DEP_PlayerController Instance { get; private set; }

    [SerializeField] private GameObject BulletPrefab;
    public bool isBulletSelected = false;

    private DEP_ItemController itemController;
    public int selectedItem;
    public bool selectAvailable;

    [SerializeField] private TextMeshProUGUI bulletText;
    public int bulletPossess;
    public bool bulletDestroyed;

    public bool isPlayAvailable;


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
        itemController = DEP_ItemController.Instance;
        selectAvailable = true;
        selectedItem = -1;

        Instantiate(BulletPrefab, gameObject.transform.position, Quaternion.identity);

        //bulletPossess = 5; // Temp bullet 
        //UpdateBulletPossess();

        bulletDestroyed = false;
        isPlayAvailable = true;
    }

    private void Update()
    {
        SelectItemEvent();
        SelectRetryEvent();
    }

    public void MakeBullet()
    {
        Instantiate(BulletPrefab, gameObject.transform.position, Quaternion.identity);
    }


    public void UseItem(int item)
    {
        if (itemController.UseItem(item))
        {
            isBulletSelected = false;
        }
        selectedItem = -1;
    }


    private void SelectItemEvent()
    {

        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown((KeyCode)(KeyCode.Alpha1 + i)) && selectAvailable && itemController.IsItemRemain(i))
            {
                if (selectedItem == i)
                {
                    selectedItem = -1;
                    itemController.UnSelectItem();
                }
                else
                {
                    selectedItem = i;
                    itemController.SelectItem(i);
                    isBulletSelected = true;
                }
            }
        }
    }

    private void SelectRetryEvent()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DEP_GameManager.Instance.RetryNow();
        }
    }

    public void UpdateBulletPossess()
    {
        bulletText.text = "Rest Bullet \n";
        bulletText.text += $"X {bulletPossess}";
    }

    public void BulletUsed()
    {
        bulletPossess--;
        UpdateBulletPossess();

        if (bulletPossess == 0)
        {
            //bulletAvailable = false;
            //StartCoroutine(LateCallNoBullet());

            isPlayAvailable = false;
            DEP_GameManager.Instance.NoBullet();
        }
    }

    private IEnumerator LateCallNoBullet()
    {
        yield return new WaitForSeconds(3.0f);
        DEP_GameManager.Instance.NoBullet();
        //bulletAvailable = true;
    }

    public void InitBullet(int numBullet)
    {
        bulletPossess = numBullet;
        UpdateBulletPossess();
    }

    public void InitPosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}