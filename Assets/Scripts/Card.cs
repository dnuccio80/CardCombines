using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public event EventHandler OnCardClicked;
    public event EventHandler OnIncorrectCardFlipped;


    [SerializeField] private CardSO cardSO;

    public void CardClicked()
    {
        if(GameManager.Instance.GetCanFlipCard())
        {
            GameManager.Instance.FlipToFrontCard(this);
            OnCardClicked?.Invoke(this, EventArgs.Empty);
        }
        
    }

    public Sprite GetFrontCardImage()
    {
        return cardSO.CardImage;
    }

    public string GetCardName()
    {
        return cardSO.CardName;
    }

    public void CardDoesNotMatch()
    {
        OnIncorrectCardFlipped?.Invoke(this, EventArgs.Empty);
    }

   


}
