using UnityEngine;
using UnityEngine.UI;

public class ShowHideUI : MonoBehaviour
{
    public GameObject uiObject;

    public void ToggleUI()
    {
        uiObject.SetActive(!uiObject.activeSelf);
    }
}