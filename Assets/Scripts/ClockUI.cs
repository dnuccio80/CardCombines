using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public static ClockUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI timerText;

    private float TimerMax;
    private float timer;
    private bool isGamePlaying;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManger_OnGameStateChanged;
        timerText.text = string.Empty;
    }

    private void GameManger_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        isGamePlaying = e.gameState == GameManager.GameState.GamePlaying;
    }

    private void Update()
    {
        if (isGamePlaying)
        {
            timer -= Time.deltaTime;
            UpdateVisual();

            if (timer <= 0) GameManager.Instance.TimerPlayingIsOver();

        }
    }


    public void SetTimer(float _timer)
    {
        TimerMax = _timer;
        ResetTimer();
    }

    private void ResetTimer()
    {
        timer = TimerMax;
    }

    private void UpdateVisual()
    {
        timerText.text = MathF.Round(timer).ToString();
    }



}
