using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int correctlyAnsweredQuestions = 0;
    int questionCount;

    float maxPoints;

    float score;

    public void SetQuestionCount(Quiz quiz)
    {
        questionCount = quiz.GetNumberOfQuestions();
    }

    public void SetMaxPoints(float timeToShowCorrectAnswer)
    {
        maxPoints = timeToShowCorrectAnswer*questionCount;
    }

    public int GetCorrectlyAnsweredQuestions()
    {
        return correctlyAnsweredQuestions;
    }

    public float GetScore()
    {
        return score;
    }

    public string GetAnsweredQuestionsText()
    {
        return $"Guessed {correctlyAnsweredQuestions} out of {questionCount}";
    }

    public string GetScoreText()
    {
        return $"Score: {score} out of {maxPoints}";
    }

    public string GetQuestionsFinalScoreText()
    {
        return "You got guessed " + correctlyAnsweredQuestions + " out of " + questionCount + " correctly";
    }

    public void QuestionsAnsweredCorreclty(float timerValue, float timeTotal)
    {
        correctlyAnsweredQuestions++;
        score += (int)(timerValue/timeTotal*10);
    }
}
