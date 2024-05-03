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
        Hide();
    }

    private void GameManger_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        isGamePlaying = e.gameState == GameManager.GameState.GamePlaying;
        (e.gameState != GameManager.GameState.LevelSelection ? (Action)Show : Hide)();
    }

    private void Update()
    {
        if (isGamePlaying)
        {
            UpdateVisual(GameManager.Instance.GetPlayingTimer());
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateVisual(float timer)
    {
        timerText.text = MathF.Round(timer).ToString();
    }



}
