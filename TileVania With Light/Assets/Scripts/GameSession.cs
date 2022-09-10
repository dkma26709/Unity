using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    int levelScore = 0;

    [SerializeField] TextMeshProUGUI LivesText;
    [SerializeField] TextMeshProUGUI ShotsText;
    [SerializeField] TextMeshProUGUI ScoreText;

    private void Awake() 
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
        ScoreText.text = this.score.ToString();
    }

    public void UpdateLevelScore()
    {
        levelScore = score;
        ScoreText.text = score.ToString(); 
    }

    void ResetScore()
    {
        score = levelScore;
        ScoreText.text = score.ToString(); 
    }

    public void UpdateShotText(int shotsLeft)
    {
        ShotsText.text = shotsLeft.ToString();
    }

    private void Start() 
    {
        LivesText.text = playerLives.ToString();   
        ScoreText.text = score.ToString(); 
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        ResetScore();
        SceneManager.LoadScene(FindObjectOfType<LevelExit>().GetLevel());
        LivesText.text = playerLives.ToString();    
    }

    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().DestroyScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

}
