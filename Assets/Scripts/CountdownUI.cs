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
    private float countdownTimer;
    private float countdownTimerMax = 3f;
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
        countdownTimer -= Time.deltaTime;

        int countdownNumber = Mathf.CeilToInt(countdownTimer);

        if (previousCountdownNumber != countdownNumber)
        {
            previousCountdownNumber = countdownNumber;
            animator.SetTrigger(POPUP_ANIMATION);
            SoundManager.Instance.EmitCountdownSound();
        }

        UpdateVisual();

        if (countdownTimer <= 0) GameManager.Instance.CountdownTimerOver();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        countdownTimer = countdownTimerMax;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateVisual()
    {
        countdownTimerText.text = Mathf.CeilToInt(countdownTimer).ToString();
    }
}
