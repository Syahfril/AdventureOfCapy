using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    // Ensure only one instance of the script exists
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Play the background music on start
    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
