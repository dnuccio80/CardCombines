using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenuManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_VOLUME = "SoundVolume";

    [SerializeField] private AudioClip selectButtonSound;
    
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetSoundVolume();
    }

    private void SetSoundVolume()
    {
        float volumeDefect = .1f;
        audioSource.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME, volumeDefect);
    }

    public void PlaySelectButtonSound()
    {
        audioSource.PlayOneShot(selectButtonSound);
    }
}
