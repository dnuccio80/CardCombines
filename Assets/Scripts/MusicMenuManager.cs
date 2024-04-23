using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenuManager : MonoBehaviour
{

    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetMusicVolume();
    }

    private void SetMusicVolume()
    {
        float volumeDefect = .3f;
        audioSource.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, volumeDefect);
    }
}
