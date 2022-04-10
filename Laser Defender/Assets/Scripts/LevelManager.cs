using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delay = 1f;

    AudioPlayer audioPlayer;

    Score scoreKeeper;

    private void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<Score>();
    }
    public void LoadGame()
    {
        StartCoroutine(WaitandLoad("Game", delay));
        scoreKeeper.ResetScore();
        audioPlayer.PlayInGameMusic();
    }

    public void LoadMainMenu()
    {
        StartCoroutine(WaitandLoad("Main Menu", delay));
        audioPlayer.PlayMainMenuMusic();
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitandLoad("Game Over", delay));
        audioPlayer.PlayGameOverMusic();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    IEnumerator WaitandLoad(string sceneName, float delay) 
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneName);
    }
}
