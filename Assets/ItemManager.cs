using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [System.Serializable]
    public class ItemData
    {
        public string itemName;
        public bool isCollected;
    }

    public void CollectItem(string itemName)
    {
        // 更新物品狀態並保存
        // ...
    }

    public bool IsItemCollected(string itemName)
    {
        // 檢查物品狀態
        // ...
        return true;
    }
}
