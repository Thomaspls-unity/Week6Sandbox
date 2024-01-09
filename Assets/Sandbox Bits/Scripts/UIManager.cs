using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject settingsUI;
    // Start is called before the first frame update
    void Start()
    {
        settingsButton.onClick.AddListener(EnableUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnableUI()
    {
        settingsUI.SetActive(true);
    }
}
