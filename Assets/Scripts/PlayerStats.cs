using System;
using UnityEngine;

public static class PlayerStats
{
    public static event EventHandler OnCoinsAmountChange;
    public static event EventHandler OnShowAllCardsAmontChange;
    public static event EventHandler OnShowCardMatchAmountChange;
    public static event EventHandler OnExtraTimeAmountChange;
    public static event EventHandler OnMaxLevelCompletedChange;
    public static event EventHandler OnWithoutEnoughCoins;
    public static event EventHandler OnPotionUsed;

    private const string PLAYERPREFS_COINS = "Coins";
    private const string PLAYERPREFS_EXTRATIME_POTIONS_AMOUNT = "ExtraTimePotionsAmount";
    private const string PLAYERPREFS_SHOWMATCHCARDS_POTIONS_AMOUNT = "ShowMatchCardsPotionsAmount";
    private const string PLAYERPREFS_SHOWALLCARDS_POTIONS_AMOUNT = "ShowAllCardsPotionsAmount";
    private const string PLAYERPREFS_LEVEL_REACHED = "LevelReached";

    private static int coins;
    private static int showAllCardsPotion;
    private static int showMatchCardPotion;
    private static int extraTimePotion;
    private static int maxLevelCompleted = 29;
    private static int levelToPlay;

    public static void IncrementCoinsAmount(object value, int _coinsEarned)
    {
        coins += _coinsEarned;
        SaveData();
        OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
    }

    public static void TryIncrementExtraTimePotion(object value, int cost)
    {
        if(coins >= cost)
        {
            extraTimePotion++;
            coins -= cost;
            SaveData();
            OnExtraTimeAmountChange?.Invoke(value, EventArgs.Empty);
            OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
            SoundManager.Instance.EmitPotionBoughtSound();
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
            SaveData();
            OnShowCardMatchAmountChange?.Invoke(value, EventArgs.Empty);
            OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
            SoundManager.Instance.EmitPotionBoughtSound();

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
            SaveData();
            OnShowAllCardsAmontChange?.Invoke(value, EventArgs.Empty);
            OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
            SoundManager.Instance.EmitPotionBoughtSound();

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

        if (coinsEarned > 0)
        {
            SoundManager.Instance.EmitCashRegisterSound();
            SaveData();
        }

    }

    public static void TryUsePotion_ExtraTime(object value)
    {
        if (extraTimePotion == 0) return;

        extraTimePotion--;

        SaveData();
        GameManager.Instance.UsePotion_ExtraTime();
        SoundManager.Instance.EmitClockFasterSound();
        OnPotionUsed?.Invoke(value, EventArgs.Empty);
    }

    public static void TryUsePotion_ShowMatchCards(object value)
    {
        if (showMatchCardPotion == 0) return;
        showMatchCardPotion--;
        SaveData();
        GameManager.Instance.UsePotion_ShowMatchCards();
        OnPotionUsed?.Invoke(value, EventArgs.Empty);

    }

    public static void TryUsePotion_ShowAllCards(object value)
    {
        if (showAllCardsPotion == 0) return;

        showAllCardsPotion--;
        SaveData();
        GameManager.Instance.UsePotion_ShowAllCards();
        OnPotionUsed?.Invoke(value, EventArgs.Empty);

    }

    public static void ChangeMaxLevelCompleted(object value, int levelComplete)
    {
        if (maxLevelCompleted > levelComplete) return;

        maxLevelCompleted = levelComplete;
        SaveData();
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

    public static void LoadData()
    {
        coins = PlayerPrefs.GetInt(PLAYERPREFS_COINS, 0);
        extraTimePotion = PlayerPrefs.GetInt(PLAYERPREFS_EXTRATIME_POTIONS_AMOUNT,0);
        showMatchCardPotion = PlayerPrefs.GetInt(PLAYERPREFS_SHOWMATCHCARDS_POTIONS_AMOUNT, 0);
        showAllCardsPotion = PlayerPrefs.GetInt(PLAYERPREFS_SHOWALLCARDS_POTIONS_AMOUNT, 0);
        maxLevelCompleted = PlayerPrefs.GetInt(PLAYERPREFS_LEVEL_REACHED);
    }

    private static void SaveData()
    {
        PlayerPrefs.SetInt(PLAYERPREFS_COINS, coins);
        PlayerPrefs.SetInt(PLAYERPREFS_EXTRATIME_POTIONS_AMOUNT, extraTimePotion);
        PlayerPrefs.SetInt(PLAYERPREFS_SHOWMATCHCARDS_POTIONS_AMOUNT, showMatchCardPotion);
        PlayerPrefs.SetInt(PLAYERPREFS_SHOWALLCARDS_POTIONS_AMOUNT, showAllCardsPotion);
        PlayerPrefs.SetInt(PLAYERPREFS_LEVEL_REACHED, maxLevelCompleted);
    }


}
