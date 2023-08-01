using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayerData : MonoBehaviour
{
    public void DeleteAllPlayerData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All player data deleted.");

        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

    }
}
