using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private AudioSource backgroundAudio;

    private void Awake()
    {
        UpdateGameSettings();
        backgroundAudio.enabled = Utility.isMusicOn;
        backgroundAudio.volume = Utility.musicVolume;

        //backgroundAudio.playOnAwake = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameSettings()
    {
        musicToggle.isOn = Utility.isMusicOn;
        musicSlider.value = Utility.musicVolume;
    }
}
