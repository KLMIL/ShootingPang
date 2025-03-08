using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public struct StageData
{
    public int[] items;
    public int bullet;
    public int coin;

    public StageData(int[] items, int bullet, int coin)
    {
        this.items = items;
        this.bullet = bullet;
        this.coin = coin;
    }
}

public enum DEP_Panel
{
    gameOver = 0,
    nextStage = 1,
    gameEnd = 2
}


public class DEP_GameManager : MonoBehaviour
{
    public static DEP_GameManager Instance; // 싱글턴 인스턴스 객체

    [SerializeField] private List<GameObject> stages;
    //private List<StageData> stageInfo = new List<StageData>();
    int currentStage;

    [SerializeField] private TextMeshProUGUI coinText;
    public int remainCoin;

    [SerializeField] private List<GameObject> Panels;

    public bool isGameInProgress;
    public bool isGameReset;
   

    private GameObject currentStageReference;

    public bool canRetry;
    private bool isStageEnd;
    public int bulletUsed;

    int score;


    private void Awake()
    {
        // GameManager를 Singleton으로 변경
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
        currentStage = 0;
        currentStageReference = Instantiate(stages[currentStage]); 
        isGameInProgress = true;
        
        canRetry = true;
        isStageEnd = false;
    }


    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    

    public void NextStage()
    {
        StopAllCoroutines();

        if (currentStage == 3)
        {
            foreach (GameObject panel in Panels)
            {
                panel.SetActive(false);
            }
            Panels[(int)DEP_Panel.gameEnd].SetActive(true);
        }
        else
        {
            Panels[(int)DEP_Panel.nextStage].SetActive(false);

            isGameInProgress = true;
            isGameReset = true;

            Destroy(currentStageReference);
            currentStageReference = Instantiate(stages[++currentStage]);
                
            DEP_PlayerController.Instance.MakeBullet();
            DEP_ItemController.Instance.UnSelectItem();
            DEP_PlayerController.Instance.selectedItem = -1;
        }
    }

    // DEPRECATED
    //public void RetryStage()
    //{
    //    isGameInProgress = true;
    //    Destroy(currentStageReference);
    //    currentStageReference = Instantiate(stages[currentStage]);

    //    Panels[(int)Panel.gameOver].SetActive(true);
    //    isGameInProgress = false;
    //    //PlayerController.Instance.MakeBullet();
    //    ItemController.Instance.UnSelectItem();
    //    PlayerController.Instance.selectedItem = -1;
    //}

    public void GainCoin()
    {
        remainCoin--;
        coinText.SetText($"Rest Coin \n X {remainCoin}");

        if (remainCoin == 0)
        {
            isGameInProgress = false;
            //NextStage();
            Panels[(int)DEP_Panel.nextStage].SetActive(true);
        }
    }

    public void NoBullet()
    {
        if (remainCoin != 0)
        {
            isStageEnd = true;
            StartCoroutine(LateRetry(4.0f)); // 가장 문제되는 부분
        }
    }

    private IEnumerator LateRetry(float sec)
    {
        yield return new WaitForSeconds(sec);
        if (remainCoin == 0)
        {
            isGameInProgress = false;
            //NextStage();
            Panels[(int)DEP_Panel.nextStage].SetActive(true);
        }
        else
        {
            isGameInProgress = false;
            //RetryStage();
            RetryNow();
        }
    }


    public void RetryNow()
    {
        if (canRetry)
        {
            StopAllCoroutines();

            Panels[(int)DEP_Panel.gameOver].SetActive(false);
            Destroy(currentStageReference);
            currentStageReference = Instantiate(stages[currentStage]);
            isGameInProgress = true;
            isGameReset = true;
            //StartCoroutine(RestartCooltime());

            //Destroy(GameObject.Find("Bullet(Clone)"));
            DEP_PlayerController.Instance.MakeBullet();
            DEP_ItemController.Instance.UnSelectItem();
            DEP_PlayerController.Instance.selectedItem = -1;
            DEP_PlayerController.Instance.isPlayAvailable = true;

            isStageEnd = false;
        }
    }


    public void InitCoin(int numCoin)
    {
        remainCoin = numCoin;
        coinText.SetText($"Rest Coin \n X {remainCoin}");
    }




    public void AddScore(int amount)
    {
        score += amount;
    }


    public void UseShot() => ModifyShots(-1);

    public void ModifyShots(int amount)
    {

    }

    public bool CanShoot() => true;


}
