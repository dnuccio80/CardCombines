using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownTimerText;

    private const string POPUP_ANIMATION = "PopupNumber";

    private Animator animator;
    private int previousCountdownNumber;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        Hide();
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.CountdownToStart) Show();
        else Hide();
    }

    private void Update()
    {

        int countdownNumber = Mathf.CeilToInt(GameManager.Instance.GetCountdownTimer());

        if (previousCountdownNumber != countdownNumber)
        {
            previousCountdownNumber = countdownNumber;
            animator.SetTrigger(POPUP_ANIMATION);
            SoundManager.Instance.EmitCountdownSound();
        }

        countdownTimerText.text = countdownNumber.ToString();

    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
