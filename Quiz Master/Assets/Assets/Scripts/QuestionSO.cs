using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [SerializeField] string[] answers = new string[3];
    [Range(0,2)]
    [SerializeField] int indexOfAnswer = 0;
    [SerializeField] Sprite blackPokemon;
    [SerializeField] Sprite visiblePokemon;

    public int GetCorrectAnswerIndex()
    {
        return indexOfAnswer;
    }

    public string GetAwnswer(int index)
    {
        return answers[index];
    }

    public Sprite GetBlackPokemon()
    {
        return blackPokemon;
    }

        public Sprite GetVisiblePokemon()
    {
        return visiblePokemon;
    }
}
