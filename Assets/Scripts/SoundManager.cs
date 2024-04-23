using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {  get; private set; }

    [SerializeField] private AudioClip winGameSound;
    [SerializeField] private AudioClip loseGameSound;
    [SerializeField] private AudioClip matchSuccessSound;
    [SerializeField] private AudioClip matchMissesSound;
    [SerializeField] private AudioClip countdownSound;
    [SerializeField] private AudioClip flipCardSound;

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnCardsMatches += GameManager_OnCardsMatches;
        GameManager.Instance.OnCardDoesNotMatches += GameManager_OnCardDoesNotMatches;
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

    public void EmitWinGameSound()
    {
        audioSource.PlayOneShot(winGameSound);

    }
    public void EmitLoseGameSound()
    {
        audioSource.PlayOneShot(loseGameSound);

    }

    public void EmitCountdownSound()
    {
        audioSource.PlayOneShot(countdownSound);
    }

    public void EmitFlipCardSound()
    {
        audioSource.PlayOneShot(flipCardSound); 
    }
}
