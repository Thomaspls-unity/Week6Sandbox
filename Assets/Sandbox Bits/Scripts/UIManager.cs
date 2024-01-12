using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Score System")]
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text scoreTxtUpdate;
    [SerializeField] private TMP_Text highScoreTxt;
    [SerializeField] private TMP_Text highScoreTxtUpdate;

    [Header("UI System")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private Button retryBtn;
    [SerializeField] private Button menuBtn;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerSBox.Instance.GetPlayer().OnScoreUpdated += UpdateScore;
        GameManagerSBox.Instance.GetPlayer().OnHighScoreUpdated += UpdateHighScore;
        GameManagerSBox.Instance.OnGameOver.AddListener(ShowGameOverUI);
        GameManagerSBox.Instance.OnPause.AddListener(ShowPauseUI);
        GameManagerSBox.Instance.OnResume.AddListener(HidePauseUI);
        retryBtn.onClick.AddListener(ReloadGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHighScore(int value) 
    {
        highScoreTxt.SetText($"Highscore: {value}");
        StartCoroutine(NewHighScore());
    }

    private void UpdateScore(int value)
    {
        scoreTxt.SetText($"Score: {GameManagerSBox.Instance.GetPlayer().GetScore()}");
        StartCoroutine(ShowTextAdded(value));
    }

    IEnumerator ShowTextAdded(int value)
    {
        scoreTxtUpdate.SetText($"Added +{value}");
        yield return new WaitForSeconds(.2f);
        scoreTxtUpdate.SetText("");
    }

    IEnumerator NewHighScore()
    {
        highScoreTxtUpdate.SetText("New High Score!");
        yield return new WaitForSeconds(.4f);
        highScoreTxtUpdate.SetText("");
    }

    private void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void ShowPauseUI()
    {
        pauseUI.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void HidePauseUI()
    {
        pauseUI.SetActive(false);
        pauseButton.SetActive(true);
    }

    private void ReloadGame()
    {
        GameManagerSBox.Instance.ChangeScene("SandboxGame");
    }
}
