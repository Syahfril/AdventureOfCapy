using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MultipleChoices2 : MonoBehaviour
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
        {"Menghormati teman yang berbeda agama untuk menjalankan ibadah termasuk pengamalan Pancasila sila ke...", "satu", "dua", "tiga"},
        {"Sebagian besar penduduk Indonesia beragama...", "Islam", "Hindu", "Kristen"},
        {"Hidup rukun merupakan salah satu ciri bahwa kita menjaga...", "persatuan", "nama baik", "persetikaian"},
        {"Wayan beragama Hindu, Wayan melakukan ibadah di...", "pure", "masjid", "wihara"},
        {"Saat berkendara melewati tempat ibadah sebaiknya kita...", "mengurangi kecepatan", "membunyikan klakson", "ngebut berkendara"},
        {"Contoh permainan yang membutuhkan kerjasama adalah...", "sepak bola", "kelereng", "petak umpet"},
        {"Apabila buku yang kita pinjam di perpustakaan hilang maka kita wajib...", "menggantinya","meminjam lagi", "berbohong"},
        {"Kerja sama yang baik akan membuahkan...", "keberhasilan","kekalahan", "pertengkaran"},
        {"Kerja sama seluruh warga negara Indonesia dapat membangun bangsa menjadi negara yang...", "maju dan besar", "besar dan lemah", "kaya dan terpecah"},
        {"Bayu sebagai ketua kelas, ia membagi tugas secara adil kepada temannya yaitu...", "sesuai dengan kemampuan", "membedakan yang pandai", "membagi semaunya"}
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
