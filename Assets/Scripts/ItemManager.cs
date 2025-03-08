using UnityEngine;

using DataTypes;


public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    private string[] itemStr =
    {
        "Bomb", "Magnet", "KnockBack", "Ghost", "Cleaner", "ZeroGravity"
    };


    GameManager gameManager;
    PlayerHUDController playerHUDController;
    
    

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
        playerHUDController = PlayerHUDController.Instance;
    }



    public void UseItem(int itemIndex)
    {
        if (itemIndex == -1) return; // 아이템 선택하지 않은 경우
        
        if (gameManager.GetCurrentItems()[itemIndex] == 0)
        {
            return;
        }
        else
        {
            gameManager.SetCurrentItems(itemIndex);
            playerHUDController.RefreshItemDisplay();
        }
    }


    // GETTER, SETTER
    public string GetItemNameByIndex(int index)
    {
        return itemStr[index];
    }
}
