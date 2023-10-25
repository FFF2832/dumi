using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private void Start()
    {
   
        RestartGame();
    }

    public static void RestartGame()
    {
        // 這個方法應該在遊戲重新開始時調用，以重置所有物品的狀態
        itemOnworld[] allItems = FindObjectsOfType<itemOnworld>();
        foreach (itemOnworld item in allItems)
        {
            // 設置isCollected為false
            item.isCollected = false;
            //PlayerPrefs.SetInt("IsCollected_branch", 0);
        }
    }
}
