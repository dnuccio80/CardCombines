using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionsInGameUI : MonoBehaviour
{

    [SerializeField] private Button extraTimePotionButton;
    [SerializeField] private Button showMatchCardsPotionButton;
    [SerializeField] private Button showAllCardsPotionButton;
    [SerializeField] private TextMeshProUGUI extraTimeText;
    [SerializeField] private TextMeshProUGUI showMatchCardsText;
    [SerializeField] private TextMeshProUGUI showAllCardsText;

    private float timer;
    private float timerMax = 5f;
    private bool canUsePotion;

    private void Awake()
    {
        extraTimePotionButton.onClick.AddListener(() =>
        {
            if (!GameManager.Instance.IsGamePlaying() || !canUsePotion) return;
            PlayerStats.TryUsePotion_ExtraTime(this);
            UpdateVisual();
        });

        showMatchCardsPotionButton.onClick.AddListener(() =>
        {
            if (!GameManager.Instance.IsGamePlaying() || !canUsePotion) return;
            PlayerStats.TryUsePotion_ShowMatchCards(this);
            UpdateVisual();
        });

        showAllCardsPotionButton.onClick.AddListener(() =>
        {
            if (!GameManager.Instance.IsGamePlaying() || !canUsePotion) return;
            PlayerStats.TryUsePotion_ShowAllCards(this);
            UpdateVisual();
        });
    }

    private void Start()
    {
        UpdateVisual();
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        PlayerStats.OnPotionUsed += PlayerStats_OnPotionUsed;
    }

    private void PlayerStats_OnPotionUsed(object sender, EventArgs e)
    {
        timer = 0;
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.GamePlaying) UpdateVisual();
    }

    private void UpdateVisual()
    {
        extraTimeText.text = "x" + PlayerStats.GetExtraTimePotionAmount().ToString();
        showMatchCardsText.text = "x" + PlayerStats.GetShowMatchCardPotionAmount().ToString();
        showAllCardsText.text = "x" + PlayerStats.GetShowAllCardsPotionAmount().ToString();
    }

    private void Update()
    {
        if (timer < timerMax) timer += Time.deltaTime;

        canUsePotion = timer >= timerMax;
        EnableButtons();
    }

    private void EnableButtons()
    {
        if (canUsePotion)
        {
            extraTimePotionButton.enabled = true;
            showMatchCardsPotionButton.enabled = true;
            showAllCardsPotionButton.enabled = true;
        } else
        {
            extraTimePotionButton.enabled = false;
            showMatchCardsPotionButton.enabled = false;
            showAllCardsPotionButton.enabled = false;
        }
    }


    public float GetTimer_Percent()
    {
        return timer/timerMax;
    }

}
