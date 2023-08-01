using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Button button;

    void Start()
    {
        // Get the button component attached to this game object
        button = GetComponent<Button>();

        // Add a listener to the button's onClick event
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Change the button's text to "pressed"
        //button.GetComponentInChildren<Text>().text = "pressed";
        SceneManager.LoadScene("New Scene");
    }
}
