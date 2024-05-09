using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {  get; private set; }

    private const string PLAYER_PREFS_SOUND_VOLUME = "SoundVolume";


    public event EventHandler OnSoundVolumeChanged;

    [SerializeField] private AudioClip matchSuccessSound;
    [SerializeField] private AudioClip matchMissesSound;
    [SerializeField] private AudioClip countdownSound;
    [SerializeField] private AudioClip flipCardSound;
    [SerializeField] private AudioClip selectButtonSound;
    [SerializeField] private AudioClip coinEarned;
    [SerializeField] private AudioClip potionBought;
    [SerializeField] private AudioClip clockFasterSound;
    [SerializeField] private AudioClip cashRegisterSound;
    [SerializeField] private AudioClip errorSound;
    [SerializeField] private AudioClip wooshSound;
    [SerializeField] private AudioClip deniedSound;

    private AudioSource audioSource;
    private float volume;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnCardsMatches += GameManager_OnCardsMatches;
        GameManager.Instance.OnCardDoesNotMatches += GameManager_OnCardDoesNotMatches;
        this.OnSoundVolumeChanged += SoundManager_OnSoundVolumeChanged;
        SetSoundVolume();
    }

    private void SoundManager_OnSoundVolumeChanged(object sender, EventArgs e)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_VOLUME, volume);
    }

    private void GameManager_OnCardsMatches(object sender, System.EventArgs e)
    {
        EmitCardMatchSuccess();
    }

    private void GameManager_OnCardDoesNotMatches(object sender, System.EventArgs e)
    {
        EmitCardMatchMisses();
    }

    public void EmitCardMatchSuccess()
    {
        audioSource.PlayOneShot(matchSuccessSound);
    }  

    public void EmitCardMatchMisses()
    {
        audioSource.PlayOneShot(matchMissesSound);
    }

    public void EmitCountdownSound()
    {
        audioSource.PlayOneShot(countdownSound);
    }

    public void EmitFlipCardSound()
    {
        audioSource.PlayOneShot(flipCardSound); 
    }

    public void EmitSelectButtonSound()
    {
        audioSource.PlayOneShot(selectButtonSound);
    }

    public void EmitCoinEarnedSound()
    {
        audioSource.PlayOneShot(coinEarned);
    }

    public void EmitPotionBoughtSound()
    {
        audioSource.PlayOneShot(potionBought);
    }

    public void EmitClockFasterSound()
    {
        audioSource.PlayOneShot(clockFasterSound);
    }

    public void EmitCashRegisterSound()
    {
        audioSource.PlayOneShot(cashRegisterSound);
    }

    public void EmitErrorSound()
    {
        audioSource.PlayOneShot(errorSound);
    }

    public void EmitWooshSound()
    {
        audioSource.PlayOneShot(wooshSound);
    }

    public void EmitDeniedSound()
    {
        audioSource.PlayOneShot(deniedSound);
    }

    public void IncrementSoundVolume()
    {
        volume += .1f;
        if(volume > 1f) volume = 0f;
        OnSoundVolumeChanged?.Invoke(this, EventArgs.Empty);
    }

    private void SetSoundVolume()
    {
        float volumeDefect = .3f;
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME, volumeDefect);
        audioSource.volume = volume;
    }

    public float GetSoundVolume()
    {
        return volume;
    }
}
