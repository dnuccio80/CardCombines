using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class PlayerStats
{
    public static event EventHandler OnCoinsAmountChange;

    private static int coins;
    private static int showCardsPotion;
    private static int showMatchCardPotion;
    private static int extraTimePotion;

    public static void IncrementCoinsAmount(object value)
    {
        coins++;
        OnCoinsAmountChange?.Invoke(value, EventArgs.Empty);
    }

    public static void IncrementShowCarddPotion() {
        showCardsPotion++;
    }

    public static void IncrementShowMatchCardPotion()
    {
        showMatchCardPotion++;
    }

    public static void IncrementExtraTimePotion()
    {
        extraTimePotion++;
    }

    public static int GetCoinsAmount()
    {
        return coins;
    }

    public static int GetShowCardsPotionAmount()
    {
        return showCardsPotion;
    }

    public static int GetShowMatchCardPotionAmount()
    {
        return showMatchCardPotion;
    }

    public static int GetExtraTimePotionAmount()
    {
        return extraTimePotion;
    }



}
