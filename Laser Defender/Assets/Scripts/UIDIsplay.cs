using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDIsplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreUI;
    Score scoreKeeper;

    [Header("Player Health")]
    [SerializeField] Slider HealthSlider;
    [SerializeField] Health playerHealth;


     void Awake() 
    {
        scoreKeeper = FindObjectOfType<Score>();
    }

    void Start()
    {
        HealthSlider.maxValue = playerHealth.GetHealth();

        UpdateScoreUI();
    }

    void Update() 
    {
        UpdateHealthBar();    
    }

    public void UpdateScoreUI()
    {
        scoreUI.GetComponent<TextMeshProUGUI>().text = scoreKeeper.GetScore().ToString("0000");
    }

    public void UpdateHealthBar()
    {
            HealthSlider.value = playerHealth.GetHealth(); 
    }

}
