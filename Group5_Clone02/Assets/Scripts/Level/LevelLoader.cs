using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float TransitionTime;
    public int NextLevelIndex;
    /*public void LoadLevelByInt(int level)
    {
        SceneManager.LoadScene(level);
    }
    */
    private void Update()
    {
       /* if (Input.GetKey(KeyCode.E))
        {
            LoadNextLevel();
        
        */
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(NextLevelIndex));
    }

    public IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        if (levelIndex == 0)
        {
            
            if (ScoreManager.Instance != null)
            {
                // Destroying ScoreManager
                Destroy(ScoreManager.Instance.gameObject);
            }
        }

        SceneManager.LoadScene(levelIndex);
    }

}
