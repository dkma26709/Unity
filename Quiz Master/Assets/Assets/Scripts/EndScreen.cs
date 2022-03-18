using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalQuestionScoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;

    private void Awake() 
    {
       scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        finalQuestionScoreText.text = scoreKeeper.GetQuestionsFinalScoreText();
        finalScoreText.text = scoreKeeper.GetScoreText();
    }
}
