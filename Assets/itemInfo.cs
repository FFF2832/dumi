using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInfo : MonoBehaviour
{
    public GameObject itemOrigin;
    public static int GetItemID(item itemObject)
    {
        if (itemObject == null)
        {
            return -1; // 或適當的預設值
        }
        else
        {
            return itemObject.itemID;
        }
    }

}
