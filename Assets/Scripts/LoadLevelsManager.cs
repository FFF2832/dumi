using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelsManager : MonoBehaviour
{
    Animator animator;
    public Texture2D fingerCursorTexture; // 新增手指指针纹理
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        //轉場
        animator = GameObject.Find("Crossfade").GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelBuildIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelBuildIndex);
    }
    //  void OnMouseEnter()
    // {
    //     //Debug.Log("HOVER");
    //     Cursor.SetCursor(fingerCursorTexture, hotSpot, cursorMode); // 使用手指指针纹理
    
    // }

    // void OnMouseExit()
    // {
    //     // Pass 'null' to the texture parameter to use the default system cursor.
    //     Cursor.SetCursor(null, Vector2.zero, cursorMode);
    // }
}