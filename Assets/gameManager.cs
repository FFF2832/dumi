using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [System.Serializable]
    public struct ObjectState
    {
        public GameObject gameObject;
        public Vector3 position;
        public Quaternion rotation;
        public bool isDeleted;  // 新增標誌，標記物件是否已被刪除
    }

    public ObjectState[] objectStates;

    public void SaveObjectStates()
    {
        objectStates = new ObjectState[SceneManager.sceneCount];

        // 保存每個場景中的物件狀態
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            objectStates[i].gameObject = SceneManager.GetSceneAt(i).GetRootGameObjects()[0];
            objectStates[i].position = objectStates[i].gameObject.transform.position;
            objectStates[i].rotation = objectStates[i].gameObject.transform.rotation;
            objectStates[i].isDeleted = false;  // 初始時標誌為未刪除
        }
    }

    public void MarkObjectDeleted(GameObject gameObject)
    {
        // 尋找指定物件，並將其標記為已刪除
        for (int i = 0; i < objectStates.Length; i++)
        {
            if (objectStates[i].gameObject == gameObject)
            {
                objectStates[i].isDeleted = true;
                break;
            }
        }
    }

    public bool IsObjectDeleted(GameObject gameObject)
    {
        // 檢查指定物件是否已刪除
        for (int i = 0; i < objectStates.Length; i++)
        {
            if (objectStates[i].gameObject == gameObject)
            {
                return objectStates[i].isDeleted;
            }
        }
        return false;
    }
}
