using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    public event EventHandler OnMusicVolumeChanged;

    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    private AudioSource audioSource;
    private float volume;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetInitialVolume();
        this.OnMusicVolumeChanged += MusicManager_OnMusicVolumeChanged;
    }

    private void MusicManager_OnMusicVolumeChanged(object sender, EventArgs e)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);
    }

    public void IncrementMusicVolume()
    {
        volume += .1f;
        if(volume > 1f) volume = 0f;
        OnMusicVolumeChanged?.Invoke(this, EventArgs.Empty);
    }


    private void SetInitialVolume()
    {
        float defeatValue = .2f;
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, defeatValue);
        audioSource.volume = volume;
    }
    public float GetMusicVolume()
    {
        return volume;
    }

}
