using UnityEngine;

public class StageSetter : MonoBehaviour
{
    [SerializeField] private int[] items = new int[4];
    [SerializeField] private int numCoin;
    [SerializeField] private int numBullet;
    [SerializeField] private Vector3 playerPosition;
    [SerializeField] private int cameraSize;


    private void Awake()
    {
        SetStage();
    }

    private void SetStage()
    {
        DEP_ItemController.Instance.InitItem(items);
        DEP_GameManager.Instance.InitCoin(numCoin);
        DEP_PlayerController.Instance.InitBullet(numBullet);
        DEP_PlayerController.Instance.InitPosition(playerPosition);
        Camera.main.orthographicSize = cameraSize;
    }

    public int GetCoinNum()
    {
        return numCoin;
    }

    public int GetBulletNum()
    {
        return numBullet;
    }
}
