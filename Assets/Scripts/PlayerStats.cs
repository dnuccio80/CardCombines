using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class PlayerStats
{
    public static event EventHandler OnCoinsAmountChange;
    public static event EventHandler OnShowAllCardsAmontChange;
    public static event EventHandler OnShowCardMatchAmountChange;
    public static event EventHandler OnExtraTimeAmountChange;
    public static event EventHandler OnMaxLevelCompletedChange;

    private static int coins;
    private static int showAllCardsPotion;
    private static int showMatchCardPotion;
    private static int extraTimePotion;
    private static int maxLevelCompleted = 33;

    public static void IncrementCoinsAmount(object value)
    {
        coins++;
        OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
    }

    public static void IncrementShowAllCardsPotion(object value) {
        showAllCardsPotion++;
        OnShowAllCardsAmontChange?.Invoke(value, EventArgs.Empty);
    }

    public static void IncrementShowMatchCardPotion(object value)
    {
        showMatchCardPotion++;
        OnShowCardMatchAmountChange?.Invoke(value, EventArgs.Empty);
    }

    public static void IncrementExtraTimePotion(object value)
    {
        extraTimePotion++;
        OnExtraTimeAmountChange?.Invoke(value, EventArgs.Empty);
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



}
