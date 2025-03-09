using UnityEngine;

using DataTypes;
using System.Collections.Generic;
using UnityEngine.UI;


public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    private string[] itemStr =
    {
        "Bomb", "Magnet", "KnockBack", "Ghost", "Cleaner", "ZeroGravity"
    };
    

    GameManager gameManager;
    
    
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
            //playerHUDController.RefreshItemDisplay();
        }
    }

    public void ApplyItemEffect(int itemIndex)
    {
        // 아이템 능력 적용지점
    }


    // GETTER, SETTER
    public string GetItemNameByIndex(int index)
    {
        return itemStr[index];
    }
}
