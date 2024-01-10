using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSBox : MonoBehaviour
{
    private Player player;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Player GetPlayer()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        return player;
    }
}
