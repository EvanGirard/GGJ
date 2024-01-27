using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

// MusicScript is a class that manage the music
public class MusicScript : MonoBehaviour
{
    private AudioSource audioSource;
    private float musicVolume = 0f;
    public GameObject ObjectMusic;
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;

    
    private void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = ObjectMusic.GetComponent<AudioSource>();
        
        
        musicVolume = PlayerPrefs.GetFloat("volume"); // Remember the volume 
        audioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
        
    }


    private void Update()
    {
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume",musicVolume);
        volumeText.text = Mathf.RoundToInt(musicVolume * 100).ToString();
    }

    // Update the volume
    // @param volume the volume of the music
    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}