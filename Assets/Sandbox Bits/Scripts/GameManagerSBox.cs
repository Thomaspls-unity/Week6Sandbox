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
