using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PlayerHUDController : MonoBehaviour
{
    public static PlayerHUDController Instance { get; private set; }


    GameManager gameManager;
    ItemManager itemManager;

    public List<Image> imgItem;


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
    }

    public void RefreshItemDisplay()
    {
        for (int i = 0; i < imgItem.Count; i++)
        {
            int[] currentItems = gameManager.GetCurrentItems();
            TextMeshProUGUI imgText = imgItem[i].GetComponentInChildren<TextMeshProUGUI>();
            if (imgText != null)
            {
                if (currentItems[i] == 0)
                {
                    imgText.text = "X";
                }
                else
                {
                    imgText.text = $"{itemManager.GetItemNameByIndex(i)} \n {currentItems[i]}";
                }
            }
        }
    }

    public void SetItemImageColor(int itemIndex, Color color)
    {
        ClearItemImageColor();
        imgItem[itemIndex].color = Color.cyan;
    }

    public void ClearItemImageColor()
    {
        for (int i = 0; i < imgItem.Count; i++)
        {
            imgItem[i].color = Color.white;
        }
    }
}
