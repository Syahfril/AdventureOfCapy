using UnityEngine;
using UnityEngine.UI;

public class ScoreListDisplay : MonoBehaviour
{
    public Text scoreListText;

    void Start()
    {
        // Check if the score list data exists in PlayerPrefs
        if (PlayerPrefs.HasKey("ScoreCount"))
        {
            // Retrieve the score list from PlayerPrefs
            string scoreList = ":\n";
            int scoreCount = PlayerPrefs.GetInt("ScoreCount", 0);

            // Iterate over the saved scores
            for (int i = 1; i <= scoreCount; i++)
            {
                string playerName = PlayerPrefs.GetString("PlayerName" + i, "");
                int score = PlayerPrefs.GetInt("Score" + i, 0);
                scoreList += "Nama Pemain: " + playerName + ", Score: " + score + "\n";
            }

            // Update the UI Text component with the score list
            scoreListText.text = scoreList;
        }
        else
        {
            // No score list data available
            scoreListText.text = "No score data available.";
        }
    }
}
