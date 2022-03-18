using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header ("Questions")]
    [SerializeField] TextMeshProUGUI TitleText;
    [SerializeField] List<QuestionSO> QuestionsMasterList;
    List<QuestionSO> Questions;
    [SerializeField] QuestionSO currectQuestion;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    int questionCount = 0;
    [SerializeField] int wantedNrOfQuestions = 7;

    [Header("Buttons")]
    [SerializeField] Sprite DefaultButtonSprite;
    [SerializeField] Sprite incorrectButtonAnswerSprite;
    [SerializeField] Sprite correctButtonAnswerSprite;
    bool hasAnsweredEarly = true;
    [SerializeField] AudioClip incorrectAnswerSound;
    [SerializeField] AudioClip correctAnswerSound;

    [Header("Image")]
    [SerializeField] GameObject pokemonImage;

    [Header("Title")]
    [SerializeField] string DefaultTitleText = "Who's That Pokemon";
    [SerializeField] int DefaultTitleSize = 68;
    [SerializeField] int SmallTitleSize = 68;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI QuestionScoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

    private void Awake() 
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void InitializzeQuiz(int questionCount)
    {
        wantedNrOfQuestions = questionCount;

        Questions = GenerateRandomQuestionList();

        progressBar.maxValue = Questions.Count;
        progressBar.value = 0;
    }

    public void StartQuiz(Button button)
    {
        button.gameObject.SetActive(false);
        
        DisplayQuestion();
        timer.IsReady();
    }

    public void SetScoreText()
    {
        scoreKeeper.SetMaxPoints(timer.GetTimeToCompleteQuestion());
        QuestionScoreText.text = scoreKeeper.GetAnsweredQuestionsText();
        ScoreText.text = scoreKeeper.GetScoreText();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            GetNextQuestion();
            hasAnsweredEarly = false;
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
        } 
        else if (progressBar.value == progressBar.maxValue)
        {
            isComplete = true;
        } 
    }

    public void OnAnswerSelected(int index)
    {
        DisplayAnswer(index);

        hasAnsweredEarly = true;
        timer.CancelTimer();
        SetButtonState(false);
    } 

    private void DisplayQuestion()
    {
        TitleText.fontSize = DefaultTitleSize;
        TitleText.text = DefaultTitleText;
        correctAnswerIndex = currectQuestion.GetCorrectAnswerIndex();
        pokemonImage.GetComponent<Image>().sprite = currectQuestion.GetBlackPokemon();

        for(int i=0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currectQuestion.GetAwnswer(i);
        }
    }

    void DisplayAnswer(int index)
    {
        if (index == correctAnswerIndex)
        {
            GetComponentInChildren<AudioSource>().PlayOneShot(correctAnswerSound);
            answerButtons[index].GetComponent<Image>().sprite = correctButtonAnswerSprite;
            scoreKeeper.QuestionsAnsweredCorreclty(timer.GetTimerValue(), timer.GetTimeToCompleteQuestion());
            SetScoreText();

        }
        else if (index == -1)
        {
            GetComponentInChildren<AudioSource>().PlayOneShot(incorrectAnswerSound);
            TitleText.fontSize = SmallTitleSize;
            answerButtons[correctAnswerIndex].GetComponent<Image>().sprite = correctButtonAnswerSprite;
        }
        else
        {
            GetComponentInChildren<AudioSource>().PlayOneShot(incorrectAnswerSound);
            TitleText.fontSize = SmallTitleSize;
            answerButtons[index].GetComponent<Image>().sprite = incorrectButtonAnswerSprite;
            answerButtons[correctAnswerIndex].GetComponent<Image>().sprite = correctButtonAnswerSprite;
        }

        TitleText.text = $"It's {answerButtons[correctAnswerIndex].GetComponentInChildren<TextMeshProUGUI>().text}!";
        pokemonImage.GetComponent<Image>().sprite = currectQuestion.GetVisiblePokemon();
    }


    private void SetButtonState(bool state)
    {
        for(int i=0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    private void GetNextQuestion()
    {
        if (questionCount != 0)
        {
            progressBar.value++;
        }

        if (questionCount < Questions.Count)
        {
            currectQuestion = Questions[questionCount];
            DisplayQuestion();
            SetButtonState(true);
            SetDefaultButtonSprites();
            ++questionCount;
        }
    }

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = DefaultButtonSprite;
        }
    }

    public int GetNumberOfQuestions()
    {
        return Questions.Count;
    }

    List<QuestionSO> GenerateRandomQuestionList()
    {
        List<QuestionSO> questionList = new List<QuestionSO>();
        List<int> randomInts = GenerateRandomListOfUniqueIntegers();
        
        foreach (var number in randomInts)
        {
            questionList.Add(QuestionsMasterList[number]);
        }
        return questionList;
    }

    List<int> GenerateRandomListOfUniqueIntegers()
    {
        List<int> randomInts = new List<int>();
        bool unique;

        if ( wantedNrOfQuestions > QuestionsMasterList.Count)
        {
            wantedNrOfQuestions = QuestionsMasterList.Count;
        }
        else if (wantedNrOfQuestions <= 0)
        {
            wantedNrOfQuestions = 1;
        }

        for (int i = 0; i < wantedNrOfQuestions; i++)
            {
                randomInts.Add(Random.Range(0, QuestionsMasterList.Count));
            }

            do
            {
            unique = true;

                for (int i = 0; i < randomInts.Count; i++)
                {
                    for (int j = 0; j < randomInts.Count; j++)
                    {
                        if (randomInts[i] == randomInts[j] && i != j)
                        {
                            randomInts.Remove(randomInts[j]);
                            randomInts.Add(Random.Range(0, QuestionsMasterList.Count));
                            unique = false;
                        }
                    }
                }
            } while (!unique);

        return randomInts;
    }
}
