using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManagerSBox : MonoBehaviour
{
    private Player player;

    public UnityEvent OnGameOver;
    public UnityEvent OnPause;
    public UnityEvent OnResume;

    private bool isPaused;
    
    [SerializeField] private bool isGameRunning = false;

    public static GameManagerSBox Instance;

    private void Awake()
    {
        SetSingleton();
    }

    private void SetSingleton()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PauseScreen()
    {
        if (!isPaused)
        {
            isPaused = true;
            Debug.Log("Game Paused");
            OnPause?.Invoke();
            Time.timeScale = 0f;
        }
        else
        {
            isPaused = false;
            Debug.Log("Game Resumed");
            OnResume?.Invoke();
            Time.timeScale = 1f;
        }
    }

    public bool IsPaused()
    {
        return isPaused;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        isGameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameRunning)
        {
            OnGameOver.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            PauseScreen();
        }
    }

    public Player GetPlayer()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        return player;
    }

    public void ChangeScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
