using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    StartScreen startScreen;
    ScoreKeeper scoreKeeper;
    
    private void Awake() 
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
        startScreen = FindObjectOfType<StartScreen>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        startScreen.gameObject.SetActive(true);
        quiz.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowFinalScore();
        }
    }

    public void OnStartGame()
    {
        quiz.InitializzeQuiz(startScreen.GetNumberOfQuestionsWanted());
        scoreKeeper.SetQuestionCount(quiz);
        quiz.SetScoreText();

        startScreen.gameObject.SetActive(false);
        quiz.gameObject.SetActive(true);
    }

    public void OnReplayLevel()
    {
        Invoke("Replay", 1);
    }

    void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
