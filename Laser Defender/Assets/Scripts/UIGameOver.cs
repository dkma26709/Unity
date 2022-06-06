using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    Score scoreKeeper;

    private void Awake() 
    {
        scoreKeeper = FindObjectOfType<Score>();
    }
    void Start()
    {
        scoreText.text = "Score: " + scoreKeeper.GetScore();
    }
}
