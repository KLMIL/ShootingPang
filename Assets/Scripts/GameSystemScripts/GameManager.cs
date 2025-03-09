using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using DataTypes;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // MonoBehaviour 변수


    // 게임 진행상황 변수
    int currentStage = 0;
    bool isGameInProgress = true;
    bool isGameReset = true;
    bool isStageEnd = false;

    int currentCoin; // remainCoin에서 변경
    int currentBullet; // 원래 PlayerController에 있어야 하는 변수 
    int[] currentItems; // 원래 ItemController(현 ItemManager)에 있던 변수


    // 게임 시스템 변수
    public List<GameObject> stagePrefabs;
    public List<GameObject> stageEventPanels;
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textBullet;

    GameObject currentStageReference;




    /*
     * Lifecycle Functions: MonoBehaviour 함수
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
        // 초기화 함수 작성 예정
    }



    /*
     * Game Progress Functions: 게임 진행상황과 관련된 함수
     */
    public void CollectCoin() // GainCoin에서 변경
    {
        // 코인 개수 변경하고 UI에 반영
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
        // Bullet 사용 로직 가져오기
        if (currentCoin != 0)
        {
            //isStageEnd = true; // 임시 제거. 없어도 되게 만들어야함.
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
        // 코인 획득 및 초기화
    }



    /*
     * Game System Functions: 게임 시스템과 관련된 함수
     */
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextStage()
    {
        StopAllCoroutines(); // 공 제거 관련 버그때문에 넣었던 코드

        /* 게임 종료 컨디션 */
        if (currentStage == 4)
        {
            // 모든 panel 비활성화
            for (int i = 0; i < stageEventPanels.Count; i++)
            {
                stageEventPanels[i].SetActive(false);
            }
            stageEventPanels[(int)GamePanel.GAME_END].SetActive(true);
        }

        /* 다음 스테이지 활성화 */
        stageEventPanels[(int)GamePanel.NEXT_STAGE].SetActive(true);

        Destroy(currentStageReference);
        currentStageReference = Instantiate(stagePrefabs[++currentStage]);

        isGameInProgress = true;
        isGameReset = true;

        // PlayerController에서 Bullet 재생성 함수 호출하고, 선택한 아이템 index 초기화
        // ItemController에서 아이템 사용 함수 호출
    }

    public void RetryNow()
    {
        //if (canRetry) // 이 조건 필요없는거 같아서 임시 제거
        //{
        StopAllCoroutines(); // 공 제거 관련 버그때문에 넣었던 코드

        stageEventPanels[(int)GamePanel.GAME_OVER].SetActive(true);
        Destroy(currentStageReference);
        currentStageReference = Instantiate(stagePrefabs[currentStage]);

        isGameInProgress = true;
        isGameReset = true; // 어디쓰는거지 1
        isStageEnd = false; // 어디쓰는거지 2

        // PlayerController Bullet 재생성 함수 호출, SelectItem과 PlayerAvailable 변수 초기화
        // ItemController에서 UseItem 호출

        //}
    }



    /* Getter */
    public int[] GetCurrentItems() // const 생각 해야함
    {
        return currentItems;
    }

    public void SetCurrentItems(int itemIndex)
    {
        currentItems[itemIndex]--;
    }
}
