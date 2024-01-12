using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI gameOverTxt;

    public Button restartBtn;

    public List<GameObject> targets;
    public GameObject titleScreen;

    public bool isGameActive;

    private int score;
    private float spawnRate;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;

        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);

        spawnRate /= difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreTxt.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverTxt.gameObject.SetActive(true);
        isGameActive = false;
        restartBtn.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
