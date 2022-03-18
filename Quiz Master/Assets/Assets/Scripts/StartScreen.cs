using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScreen : MonoBehaviour
{
    [SerializeField] GameObject InputField;
    
    int numberOfQuestionsWanted = 0;

    public void SetQuestionCount()
    {
        numberOfQuestionsWanted = int.Parse(InputField.GetComponentInChildren<TMP_InputField>().text);
    }

    public int GetNumberOfQuestionsWanted()
    {
        return numberOfQuestionsWanted;
    }
}
