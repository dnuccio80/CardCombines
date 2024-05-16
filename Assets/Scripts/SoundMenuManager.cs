using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip selectButtonSound;
    [SerializeField] private AudioClip wooshSound;

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
        float volume = .1f;
        audioSource.volume = volume;
    }

    public void PlaySelectButtonSound()
    {
        audioSource.PlayOneShot(selectButtonSound);
    }

    public void PlayWooshSound()
    {
        audioSource.PlayOneShot(wooshSound);
    }
}
