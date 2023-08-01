using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasController : MonoBehaviour
{
    //initial
    public Canvas initialCanvas;
    public Button howtoplayButton;
    public Button scoreButton;
    public Button playButton;

    public Canvas howtoplayCanvas;
    public Button backButton_htp;

    public Canvas scoreCanvas;
    public Button backButton_score;

    public Canvas choiceCanvas;
    public Button gotos;
    public Button gotor;
    public Button backButton_choice;

    public Canvas lvl_sCanvas;
    public Button backButton_lvls;

    public Canvas lvlv_rCanvas;
    public Button backButton_lvlr;

   

    public Button resbutt;



    void Start()
    {
        playButton.onClick.AddListener(SwitchToChoiceCanvas);
        howtoplayButton.onClick.AddListener(SwitchToHowToPlayCanvas);
        backButton_htp.onClick.AddListener(SwitchToInitialCanvas);
        scoreButton.onClick.AddListener(SwitchToScoreCanvas);
        backButton_score.onClick.AddListener(SwitchToInitialCanvas);
        backButton_choice.onClick.AddListener(SwitchToInitialCanvas);
        gotos.onClick.AddListener(SwitchToLvls);
        gotor.onClick.AddListener(SwitchToLvlr);
        backButton_lvlr.onClick.AddListener(SwitchToInitialCanvas);
        backButton_lvls.onClick.AddListener(SwitchToInitialCanvas);
        resbutt.onClick.AddListener(DeletePlayerData);
        
    }

    void DeletePlayerData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All player data deleted.");

        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void SwitchToHowToPlayCanvas()
    {
        initialCanvas.enabled = false;
        scoreCanvas.enabled = false;
        howtoplayCanvas.enabled = true;
        choiceCanvas.enabled = false;
        lvlv_rCanvas.enabled = false;
        lvl_sCanvas.enabled = false;
        Debug.Log("howtoplay");
    }

    void SwitchToScoreCanvas()
    {
        initialCanvas.enabled = false;
        scoreCanvas.enabled = true;
        howtoplayCanvas.enabled = false;
        choiceCanvas.enabled = false;
        lvlv_rCanvas.enabled = false;
        lvl_sCanvas.enabled = false;
        Debug.Log("score");
    }

    void SwitchToChoiceCanvas()
    {
        initialCanvas.enabled = false;
        scoreCanvas.enabled = false;
        howtoplayCanvas.enabled = false;
        choiceCanvas.enabled = true;
        lvlv_rCanvas.enabled = false;
        lvl_sCanvas.enabled = false;
    }

    void SwitchToLvlr()
    {
        lvlv_rCanvas.enabled = true;
        lvl_sCanvas.enabled = false;
        initialCanvas.enabled = false;
        scoreCanvas.enabled = false;
        howtoplayCanvas.enabled = false;
        choiceCanvas.enabled = false;
    }

    void SwitchToLvls()
    {
        lvlv_rCanvas.enabled = false;
        lvl_sCanvas.enabled = true;
        initialCanvas.enabled = false;
        scoreCanvas.enabled = false;
        howtoplayCanvas.enabled = false;
        choiceCanvas.enabled = false;
    }

    void SwitchToInitialCanvas()
    {
        initialCanvas.enabled = true;
        scoreCanvas.enabled = false;
        howtoplayCanvas.enabled = false;
        choiceCanvas.enabled = false;
        lvlv_rCanvas.enabled = false;
        lvl_sCanvas.enabled = false;
    }


}
