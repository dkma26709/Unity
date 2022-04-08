using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    UIDIsplay ui;

    int score = 0;

    void Awake() 
    {
        ui = FindObjectOfType<UIDIsplay>();    
    }

    void Start() 
    {
        ui.UpdateScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    void ResetScore()
    {
        score = 0;
        ui.UpdateScoreUI();
    }

    public void ModifyScore(int value)
    {
        Mathf.Clamp(score += value, 0, int.MaxValue);
        ui.UpdateScoreUI();
    }


}
