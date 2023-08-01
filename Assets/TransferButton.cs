using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransferButton : MonoBehaviour
{
    public InputField playerNameInput;

    public void TransferToSceneB()
    {
        string playerName = playerNameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save(); // Save the player name to PlayerPrefs
        SceneManager.LoadScene("SampleScene");
    }

}
