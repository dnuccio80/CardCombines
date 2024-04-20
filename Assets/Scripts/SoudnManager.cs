using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SoudnManager : MonoBehaviour
{
    public static SoudnManager Instance {  get; private set; }

    [SerializeField] private AudioClip winGameSound;
    [SerializeField] private AudioClip loseGameSound;
    [SerializeField] private AudioClip matchSuccessSound;
    [SerializeField] private AudioClip matchMissesSound;

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
}
