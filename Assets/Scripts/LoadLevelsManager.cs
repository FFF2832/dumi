using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelsManager : MonoBehaviour
{
    Animator animator;
    public Texture2D fingerCursorTexture; // 新增手指指针纹理
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private bool UIstate;
  private static bool scene1Loaded = false;
 private static bool scene2Loaded = false;
    private void Awake()
    {
        //轉場
       // animator = GameObject.Find("Crossfade").GetComponent<Animator>();
      
    }
    private void Update(){
        //Debug.Log(scene1Loaded);
       
         UIstate=Enlarge.UpdateisMouseOverobj();
         if(DialogSystem.UpdatechangeScene()&& !scene1Loaded){
            scene1Loaded = true;
            SceneManager.LoadScene("SampleScene 1");
            Debug.Log("切到第一關"+scene1Loaded);
         }
         if(DialogSystem.UpdatechangeScene2()){
             scene2Loaded = true;
            SceneManager.LoadScene("Scene Disease");
            Debug.Log("切到第二關");
         }
        if(DialogSystem.UpdatechangeScene3()&& !scene2Loaded){
            SceneManager.LoadScene("Scene Disease");
            Debug.Log("切到第二關");
         }
    }
    private void OnDisable()
{
    // 腳本啟用時重置標誌
    scene1Loaded = true;
        scene2Loaded = true;
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