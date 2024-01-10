using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text scoreTxtUpdate;
    [SerializeField] private TMP_Text highScoreTxt;
    [SerializeField] private TMP_Text highScoreTxtUpdate;
    //[SerializeField] private Button settingsButton;
    //[SerializeField] private GameObject settingsUI;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerSBox.Instance.GetPlayer().OnScoreUpdated += UpdateScore;
        GameManagerSBox.Instance.GetPlayer().OnHighScoreUpdated += UpdateHighScore;

        //settingsButton.onClick.AddListener(EnableUI);
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

    //private void EnableUI()
    //{
    //    settingsUI.SetActive(true);
    //}
}
