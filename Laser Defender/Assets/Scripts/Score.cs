using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    UIDIsplay ui;

    int score = 0;

    static Score instance;

    void Awake() 
    {
        ManageSingleton();
        ui = FindObjectOfType<UIDIsplay>();    
    }

    private void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() 
    {
        if (SceneManager.GetActiveScene().ToString() == "Game")
        {
            ui.UpdateScoreUI();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ModifyScore(int value)
    {
        Mathf.Clamp(score += value, 0, int.MaxValue);
        ui.UpdateScoreUI();
    }

    public void FindUI()
    {
        ui = FindObjectOfType<UIDIsplay>();
    }


}
