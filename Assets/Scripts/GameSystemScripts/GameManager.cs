using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using DataTypes;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // MonoBehaviour ����


    // ���� �����Ȳ ����
    int currentStage = 0;
    bool isGameInProgress = true;
    bool isGameReset = true;
    bool isStageEnd = false;

    int currentCoin; // remainCoin���� ����
    int currentBullet; // ���� PlayerController�� �־�� �ϴ� ���� 
    int[] currentItems; // ���� ItemController(�� ItemManager)�� �ִ� ����


    // ���� �ý��� ����
    public List<GameObject> stagePrefabs;
    public List<GameObject> stageEventPanels;
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textBullet;

    GameObject currentStageReference;




    /*
     * Lifecycle Functions: MonoBehaviour �Լ�
     */
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // �ʱ�ȭ �Լ� �ۼ� ����
    }



    /*
     * Game Progress Functions: ���� �����Ȳ�� ���õ� �Լ�
     */
    public void CollectCoin() // GainCoin���� ����
    {
        // ���� ���� �����ϰ� UI�� �ݿ�
        currentCoin--;
        textCoin.SetText($"Rest Coin \n X {currentCoin}");

        if (currentCoin == 0)
        {
            isGameInProgress = false;
            stageEventPanels[(int)GamePanel.NEXT_STAGE].SetActive(true);
        }
    }

    public void UsedBullet() // NoBullet
    {
        // Bullet ��� ���� ��������
        if (currentCoin != 0)
        {
            //isStageEnd = true; // �ӽ� ����. ��� �ǰ� ��������.
            isGameInProgress = false;
            RetryNow();
        }
        else
        {
            isGameInProgress = true;
            stageEventPanels[(int)GamePanel.NEXT_STAGE].SetActive(true);
        }
    }

    public void InitCoin()
    {
        // ���� ȹ�� �� �ʱ�ȭ
    }



    /*
     * Game System Functions: ���� �ý��۰� ���õ� �Լ�
     */
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextStage()
    {
        StopAllCoroutines(); // �� ���� ���� ���׶����� �־��� �ڵ�

        /* ���� ���� ����� */
        if (currentStage == 4)
        {
            // ��� panel ��Ȱ��ȭ
            for (int i = 0; i < stageEventPanels.Count; i++)
            {
                stageEventPanels[i].SetActive(false);
            }
            stageEventPanels[(int)GamePanel.GAME_END].SetActive(true);
        }

        /* ���� �������� Ȱ��ȭ */
        stageEventPanels[(int)GamePanel.NEXT_STAGE].SetActive(true);

        Destroy(currentStageReference);
        currentStageReference = Instantiate(stagePrefabs[++currentStage]);

        isGameInProgress = true;
        isGameReset = true;

        // PlayerController���� Bullet ����� �Լ� ȣ���ϰ�, ������ ������ index �ʱ�ȭ
        // ItemController���� ������ ��� �Լ� ȣ��
    }

    public void RetryNow()
    {
        //if (canRetry) // �� ���� �ʿ���°� ���Ƽ� �ӽ� ����
        //{
        StopAllCoroutines(); // �� ���� ���� ���׶����� �־��� �ڵ�

        stageEventPanels[(int)GamePanel.GAME_OVER].SetActive(true);
        Destroy(currentStageReference);
        currentStageReference = Instantiate(stagePrefabs[currentStage]);

        isGameInProgress = true;
        isGameReset = true; // ��𾲴°��� 1
        isStageEnd = false; // ��𾲴°��� 2

        // PlayerController Bullet ����� �Լ� ȣ��, SelectItem�� PlayerAvailable ���� �ʱ�ȭ
        // ItemController���� UseItem ȣ��

        //}
    }



    /* Getter */
    public int[] GetCurrentItems() // const ���� �ؾ���
    {
        return currentItems;
    }

    public void SetCurrentItems(int itemIndex)
    {
        currentItems[itemIndex]--;
    }
}
