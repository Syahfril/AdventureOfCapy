using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public int sceneIndexToReload; // Set this to the index of the scene you want to reload

    public void ReloadScene()
    {
        SceneManager.LoadScene(sceneIndexToReload, LoadSceneMode.Single);
    }
}
