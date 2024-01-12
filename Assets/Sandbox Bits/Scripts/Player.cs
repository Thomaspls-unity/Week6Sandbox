using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int score;
    private int highScore;

    public Action<int> OnScoreUpdated;
    public Action<int> OnHighScoreUpdated;
    // Start is called before the first frame update
    void Start()
    {
        InitialiseHighScore();
    }

    private void InitialiseHighScore()
    {
        OnScoreUpdated += SetScore;
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        else
        {
            highScore = PlayerPrefs.GetInt("Highscore");
            OnHighScoreUpdated.Invoke(highScore);
        }
        OnHighScoreUpdated += SetHighScore;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.S) && !GameManagerSBox.Instance.IsPaused())
        {
            OnScoreUpdated.Invoke(1);
        }
    }

    private void SetScore(int value)
    {
        score += value;
        CheckHighScore();
    }

    private void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            OnHighScoreUpdated.Invoke(highScore);
        }
    }
    private void SetHighScore(int value)
    {
        PlayerPrefs.SetInt("Highscore", value);
    }


    public int GetScore() 
    { 
        return score;
    }
}
