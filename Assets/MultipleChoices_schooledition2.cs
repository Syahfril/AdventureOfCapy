using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MultipleChoices_schooledition2 : MonoBehaviour
{
    public Text questionText;
    public Button[] answerButtons;
    public Text scoreText;
    public GameObject quizPopup;
    public Button resetButton;
    //public Text scoreListText;
    public Text playerNameText;
    private string playerName;

    public Button backButt;

    public Image questionImage;
    public Sprite[] questionImages;



    private int currentQuestionIndex = 0;
    private int score = 0;

    private string[,] questionsAndAnswers = {
        {"Segala sesuatu yang menempati ruang dan mempunyai massa disebut....", "Benda", "Berat", "Ciptaan"},
        {"Manusia, hewan, dan tumbuhan merupakan ....", "Benda padat", "Benda padat", "Benda mati"},
        {"Warna, bentuk, dan ukuran suatu benda merupakan pengelompokan benda berdasarkan sifat ....", "Fisik", "Biologis", "Kimiawi"},
        {"Kelemahan benda yang terbuat dari kayu adalah ....", "Mudah terbakar", "Mudah dibentuk", "Mudah dijual"},
        {"Gambar di bawah adalah perubahan wujud dari cair menjadi padat disebut ....", "Membeku", "Mencair", "Menguap"},
        {"Penguapan adalah perubahan wujud dari benda .... ke benda ....", "Cair-gas", "Padat-cair", "Gas-cair"},
        {"Bentuknya tidak dapat dilihat dan hanya dapat dirasakan adalah ciri-ciri ....", "Benda gas", "Benda padat", "Hantu"},
        {"Angin, udara, dalam balon, asap termasuk benda ....", "Gas", "Cair", "Padat"},
        {"Berat benda dapat berubah-ubah tergantung pada gaya gravitasi di tempat tersebut. Arti kata yang tercetak tebal adalah ....", "Gaya tarik bumi", "Gaya dorong benda", "Benda padat"},
        {"Angin berhembus sepoi-sepoi. Arti kata yang tercetak tebal adalah ....", "Udara yang bergerak", "Udara berbentuk gas", "Udara yang dingin"}
    };


    void Start()
    {
        SetQuestion(currentQuestionIndex);
        resetButton.onClick.AddListener(ResetQuiz);

        playerName = PlayerPrefs.GetString("PlayerName");

        // Display the player name in the UI
        playerNameText.text = "Player Name: " + playerName;
        scoreText.text = "Score: " + score;

        // Display the score list
        //DisplayScoreList();
    }

    public void LoadByIndex(int sceneIndex)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneIndex);

    }


    void SetQuestion(int questionIndex)
    {
        quizPopup.SetActive(false);

        questionText.text = questionsAndAnswers[questionIndex, 0];

        if (questionIndex < questionImages.Length)
        {
            questionImage.sprite = questionImages[questionIndex];
            questionImage.gameObject.SetActive(true);
        }
        else
        {
            questionImage.gameObject.SetActive(false);
        }


        string[] answerTexts = new string[answerButtons.Length];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerTexts[i] = questionsAndAnswers[questionIndex, i + 1];
        }
        System.Random rng = new System.Random();
        int n = answerTexts.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = answerTexts[k];
            answerTexts[k] = answerTexts[n];
            answerTexts[n] = value;
        }

        // Set the answer button texts
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = answerTexts[i];
        }
    }

    public void AnswerButtonClicked(Button button)
    {
        if (button.GetComponentInChildren<Text>().text == questionsAndAnswers[currentQuestionIndex, 1])
        {

            score = score + 10;
            scoreText.text = "Score: " + score;

        }
        else
        {
            StartCoroutine(ChangeButtonColor(button, Color.red, 0.5f));
            Debug.Log("Incorrect answer.");
        }



        currentQuestionIndex++;
        if (currentQuestionIndex < questionsAndAnswers.GetLength(0))
        {
            SetQuestion(currentQuestionIndex);
        }
        else
        {
            // End of questions
            Debug.Log("End of questions.");
            savethescore();
            quizPopup.SetActive(true); // Show the popup

            HideQuestionAndAnswers();
        }
    }



    private IEnumerator ChangeButtonColor(Button button, Color color, float duration)
    {
        Color originalColor = button.image.color;
        button.image.color = color;
        yield return new WaitForSeconds(duration);
        button.image.color = originalColor;
    }



    private void savethescore()
    {

        PlayerPrefs.SetInt("Score", score);

        int scoreCount = PlayerPrefs.GetInt("ScoreCount", 0);
        scoreCount++;
        PlayerPrefs.SetInt("ScoreCount", scoreCount);


        PlayerPrefs.SetString("PlayerName" + scoreCount, playerName);


        PlayerPrefs.SetInt("Score" + scoreCount, score);
        PlayerPrefs.Save();
    }



    private void ResetQuiz()
    {
        currentQuestionIndex = 0;
        score = 0;
        SetQuestion(currentQuestionIndex);
        quizPopup.SetActive(false); // Hide the popup
        ShowQuestionAndAnswers();


        PlayerPrefs.DeleteKey("PlayerName");
        PlayerPrefs.DeleteKey("Score");

        PlayerPrefs.Save();


        scoreText.text = "Score: " + score;

        // Display the score list
        //DisplayScoreList();
    }


    private void HideQuestionAndAnswers()
    {
        questionText.gameObject.SetActive(false);
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    private void ShowQuestionAndAnswers()
    {
        questionText.gameObject.SetActive(true);
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(true);
        }
    }
}
