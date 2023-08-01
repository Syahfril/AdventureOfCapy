using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using UnityEngine.SceneManagement;

public class MultipleChoices_schooledition3 : MonoBehaviour
{
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Text questionText;
    public Text scoreText;
    public GameObject quizPopup;
    public Button resetButton;
    public Text playerNameText;
    private string playerName;
    
    private bool clicked = false;
    private int currentQuestion = 0;
    public Question[] questions;

    private int score = 0;

    private void Start()
    {
        buttonA.onClick.AddListener(ChooseButtonA);
        buttonB.onClick.AddListener(ChooseButtonB);
        buttonC.onClick.AddListener(ChooseButtonC);

        playerName = PlayerPrefs.GetString("PlayerName");

        // Display the player name in the UI
        playerNameText.text = "Player Name: " + playerName;
        scoreText.text = "Score: " + score;

        resetButton.onClick.AddListener(ResetQuiz);
        
        ShowNextQuestion();
    }

    public void LoadByIndex(int sceneIndex)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneIndex);

    }

    private void ChooseButtonA()
    {
        CheckAnswer(false);
    }

    private void ChooseButtonB()
    {
        CheckAnswer(true);
    }

    private void ChooseButtonC()
    {
        CheckAnswer(true);
    }

    private void CheckAnswer(bool isButtonACorrect)
    {
        if (!clicked)
        {
            bool isCorrect = questions[currentQuestion].IsCorrectAnswer(isButtonACorrect);

            if (isCorrect)
            {
                score += 10;
                scoreText.text = "Score: " + score;
            }
            else
            {
                Debug.Log("Incorrect answer.");
            }

            currentQuestion++;
            if (currentQuestion >= questions.Length)
            {
                Debug.Log("End of game");
                SaveScore();
                quizPopup.SetActive(true);
                HideQuestionAndAnswers();
            }
            else
            {
                ShowNextQuestion();
            }
        }
    }

    private void ShowNextQuestion()
    {
        clicked = false;
        Question nextQuestion = questions[currentQuestion];
        questionText.text = nextQuestion.questionText;
        buttonA.image.sprite = nextQuestion.buttonASprite;
        buttonB.image.sprite = nextQuestion.buttonBSprite;
        buttonC.image.sprite = nextQuestion.buttonCSprite;
    }

    private void SaveScore()
    {
        // Save the current score to player preferences
        PlayerPrefs.SetInt("Score", score);

        // Save the current player name with a unique key
        int scoreCount = PlayerPrefs.GetInt("ScoreCount", 0) + 1;
        PlayerPrefs.SetInt("ScoreCount", scoreCount);
        PlayerPrefs.SetString("PlayerName" + scoreCount, playerName);
        PlayerPrefs.SetInt("Score" + scoreCount, score);
        PlayerPrefs.Save();
    }

    private void ResetQuiz()
    {
        currentQuestion = 0;
        score = 0;
        ShowNextQuestion();
        quizPopup.SetActive(false);
        ShowQuestionAndAnswers();

        PlayerPrefs.DeleteKey("PlayerName");
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.Save();

        scoreText.text = "Score: " + score;
        playerNameText.text = "Player Name: ";
    }

    private void HideQuestionAndAnswers()
    {
        questionText.gameObject.SetActive(false);
        buttonA.gameObject.SetActive(false);
        buttonB.gameObject.SetActive(false);
        buttonC.gameObject.SetActive(false);
    }

    private void ShowQuestionAndAnswers()
    {
        questionText.gameObject.SetActive(true);
        buttonA.gameObject.SetActive(true);
        buttonB.gameObject.SetActive(true);
        buttonC.gameObject.SetActive(true);
    }

   
}

[System.Serializable]
public class Question
{
    public string questionText;
    public Sprite buttonASprite;
    public Sprite buttonBSprite;
    public Sprite buttonCSprite;
    public bool isButtonACorrect;

    public Question(string text, Sprite spriteA, Sprite spriteB, Sprite spriteC, bool isCorrect)
    {
        questionText = text;
        buttonASprite = spriteA;
        buttonBSprite = spriteB;
        buttonCSprite = spriteC;
        isButtonACorrect = isCorrect;
    }

    public bool IsCorrectAnswer(bool isButtonA)
    {
        return isButtonA == isButtonACorrect;
    }
}
