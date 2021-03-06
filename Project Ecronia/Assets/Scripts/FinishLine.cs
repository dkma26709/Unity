using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] int nextLevel = -1;

    [SerializeField] float delay = 0.5f;

    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            StartCoroutine("NextLevel");
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSecondsRealtime(delay);

        if (SceneManager.sceneCountInBuildSettings < currentSceneIndex + 1)
            SceneManager.LoadScene(0);

        else if (nextLevel != -1)
            SceneManager.LoadScene(nextLevel);

        else
            SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public int GetLevel()
    {
        return currentSceneIndex;
    }
}
