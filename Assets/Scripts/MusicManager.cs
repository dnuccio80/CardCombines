using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    public event EventHandler OnMusicVolumeChanged;

    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    [SerializeField] private AudioClip[] musicLevels;
    [SerializeField] private AudioClip selectionLevelShopMusic;
    [SerializeField] private AudioClip pauseMenuMusic;
    [SerializeField] private AudioClip gameOverMusic;
    [SerializeField] private AudioClip gameWinMusic;



    private AudioSource audioSource;
    private AudioClip gameClip;
    private float volume;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        GameManager.Instance.OnToggleGamePause += GameManager_OnToggleGamePause;
        SetInitialVolume();
        this.OnMusicVolumeChanged += MusicManager_OnMusicVolumeChanged;
    }

    private void GameManager_OnToggleGamePause(object sender, GameManager.OnToggleGamePauseEventArgs e)
    {
        if (e.gameState == GameManager.GameState.GamePlaying)
        {
            audioSource.clip = gameClip;
            audioSource.Play();
        }
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {

        switch (e.gameState)
        {
            case GameManager.GameState.LevelSelection:
                audioSource.clip = selectionLevelShopMusic;
                audioSource.Play();
                break;
            case GameManager.GameState.CountdownToStart:
                gameClip = musicLevels[UnityEngine.Random.Range(0, musicLevels.Length)];
                audioSource.clip = gameClip;
                audioSource.Play();
                break;
            case GameManager.GameState.GamePaused:
                audioSource.clip = pauseMenuMusic;
                audioSource.Play();
                break;
            case GameManager.GameState.GameWin:
                audioSource.clip = gameWinMusic;
                audioSource.Play();
                break;
            case GameManager.GameState.GameOver:
                audioSource.clip = gameOverMusic;
                audioSource.Play();
                break;

        }


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
