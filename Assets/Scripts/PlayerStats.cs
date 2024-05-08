using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public static class PlayerStats
{
    public static event EventHandler OnCoinsAmountChange;
    public static event EventHandler OnShowAllCardsAmontChange;
    public static event EventHandler OnShowCardMatchAmountChange;
    public static event EventHandler OnExtraTimeAmountChange;
    public static event EventHandler OnMaxLevelCompletedChange;
    public static event EventHandler OnWithoutEnoughCoins;
    public static event EventHandler OnPotionUsed;


    private static int coins;
    private static int showAllCardsPotion;
    private static int showMatchCardPotion;
    private static int extraTimePotion;
    private static int maxLevelCompleted;
    private static int levelToPlay;

    public static void IncrementCoinsAmount(object value, int _coinsEarned)
    {
        coins += _coinsEarned;
        OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
    }

    public static void TryIncrementExtraTimePotion(object value, int cost)
    {
        if(coins >= cost)
        {
            extraTimePotion++;
            coins -= cost;
            OnExtraTimeAmountChange?.Invoke(value, EventArgs.Empty);
            OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
        }
        else
        {
            OnWithoutEnoughCoins?.Invoke(value, EventArgs.Empty);

        }
    }

    public static void TryIncrementShowMatchCardPotion(object value, int cost)
    {
        if(coins >= cost)
        {
            showMatchCardPotion++;
            coins -= cost;
            OnShowCardMatchAmountChange?.Invoke(value, EventArgs.Empty);
            OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
        }
        else
        {
            OnWithoutEnoughCoins?.Invoke(value, EventArgs.Empty);

        }
    }

    public static void TryIncrementShowAllCardsPotion(object value, int cost) {
        
        if(coins >= cost)
        {
            showAllCardsPotion++;
            coins -= cost;
            OnShowAllCardsAmontChange?.Invoke(value, EventArgs.Empty);
            OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
        }
        else
        {
            OnWithoutEnoughCoins?.Invoke(value, EventArgs.Empty);
        }

    }
    public static void SellPotions(int extraTimePotionsToSell, int showMatchCardsPotionsToSell, int showAllCardsPotionsToSell, int coinsEarned)
    {
        extraTimePotion -= extraTimePotionsToSell;
        showMatchCardPotion -= showMatchCardsPotionsToSell;
        showAllCardsPotion -= showAllCardsPotionsToSell;
        coins += coinsEarned;

    }

    public static void TryUsePotion_ExtraTime(object value)
    {
        if (extraTimePotion == 0) return;

        extraTimePotion--;
        GameManager.Instance.UsePotion_ExtraTime();
        OnPotionUsed?.Invoke(value, EventArgs.Empty);

    }

    public static void TryUsePotion_ShowMatchCards(object value)
    {
        if (showMatchCardPotion == 0) return;

        showMatchCardPotion--;
        GameManager.Instance.UsePotion_ShowMatchCards();
        OnPotionUsed?.Invoke(value, EventArgs.Empty);

    }

    public static void TryUsePotion_ShowAllCards(object value)
    {
        if (showAllCardsPotion == 0) return;

        showAllCardsPotion--;
        GameManager.Instance.UsePotion_ShowAllCards();
        OnPotionUsed?.Invoke(value, EventArgs.Empty);

    }

    public static void ChangeMaxLevelCompleted(object value, int levelComplete)
    {
        if (maxLevelCompleted > levelComplete) return;

        maxLevelCompleted = levelComplete;
        OnMaxLevelCompletedChange?.Invoke(value, EventArgs.Empty);
    }

    public static int GetCoinsAmount()
    {
        return coins;
    }

    public static int GetShowAllCardsPotionAmount()
    {
        return showAllCardsPotion;
    }

    public static int GetShowMatchCardPotionAmount()
    {
        return showMatchCardPotion;
    }

    public static int GetExtraTimePotionAmount()
    {
        return extraTimePotion;
    }

    public static int GetMaxLevelCompleted()
    {
        return maxLevelCompleted;
    }

    public static void SetLevelToPlay(int _levelToPlay)
    {
        levelToPlay = _levelToPlay;
    }

    public static int GetLevelToPlay()
    {
        return levelToPlay;
    }


}
