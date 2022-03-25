using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    int currentSceneIndex;

    private void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine("NextLevel");
        }    
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSecondsRealtime(1);
        if (SceneManager.sceneCountInBuildSettings < currentSceneIndex + 2)
        {
            SceneManager.LoadScene(0);
        }
        FindObjectOfType<ScenePersist>().DestroyScenePersist();
        SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<GameSession>().UpdateLevelScore();
    }

    public int GetLevel()
    {
        return currentSceneIndex;
    }
}
