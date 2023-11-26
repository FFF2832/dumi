using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // 定義一個事件
    public static event System.Action OnGameModeExit;

    private void OnDisable()
    {
        // 在遊戲物件被禁用時（例如離開遊玩模式時）觸發事件
        OnGameModeExit?.Invoke();
    }

    // 在其他地方，例如遊戲管理器或其他適當的地方，訂閱事件
    void Start()
    {
        OnGameModeExit += ResetValues;
    }

    void ResetValues()
    {
        // 在這裡重新設定數值
        // PlayerPrefs.SetInt("IsCollected_branch", 0);
        //PlayerPrefs.SetInt("PlayerLevel", 0);
        // 其他需要歸零的數值...
      //  PlayerPrefs.Save();
    }

    public static void RestartGame()
    {
        // // 這個方法應該在遊戲重新開始時調用，以重置所有物品的狀態
        // itemOnworld[] allItems = FindObjectsOfType<itemOnworld>();
        // foreach (itemOnworld item in allItems)
        // {
        //     // 設置isCollected為false
        //     item.isCollected = false;
        //     //PlayerPrefs.SetInt("IsCollected_branch", 0);
        // }
       // PlayerPrefs.SetInt("IsCollected_branch", 0);
    }
}
