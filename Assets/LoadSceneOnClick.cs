using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class LoadSceneOnClick : MonoBehaviour
{
    public InputField playerNameInput;

    public void LoadByIndex(int sceneIndex)
    {
        string playerName = playerNameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneIndex);
    }
}
