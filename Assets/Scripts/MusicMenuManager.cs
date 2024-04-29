using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenuManager : MonoBehaviour
{

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
        float volume = .3f;
        audioSource.volume = volume;
    }
}
