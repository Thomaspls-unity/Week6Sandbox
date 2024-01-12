using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private AudioSource backgroundAudio;

    private void Awake()
    {
        UpdateGameSettings();
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicValue);
        musicToggle.onValueChanged.AddListener(SetMusicOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameSettings()
    {
        bool musicIntToBool = PlayerPrefs.GetInt("Music_Toggle") == 0 ? false : true; //0 represents false.
        musicToggle.isOn = musicIntToBool;
        musicSlider.value = PlayerPrefs.GetFloat("Music_Volume");
    }

    public void SetMusicValue(float value)
    {
        Utility.musicVolume = value;
        SavePlayerSettings();
    }

    public void SetMusicOn(bool value)
    {
        Utility.isMusicOn = value;
        SavePlayerSettings();
    }

    public void SavePlayerSettings()
    {
        PlayerPrefs.SetFloat("Music_Volume", Utility.musicVolume);

        int musicBoolToInt = Utility.isMusicOn ? 1 : 0; //Translating the Boolean to a binary code in order to take in an integer.
        PlayerPrefs.SetInt("Music_Toggle", musicBoolToInt);

    }
}
