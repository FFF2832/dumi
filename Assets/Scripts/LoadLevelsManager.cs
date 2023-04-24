using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelsManager : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
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
}