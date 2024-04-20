using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public event EventHandler OnCardClicked;
    public event EventHandler OnIncorrectCardFlipped;

    [SerializeField] private CardVisual cardVisual;
    [SerializeField] private CardSO cardSO;

    private bool cardMatched;

    public void CardClicked()
    {
        if (cardMatched || cardVisual.IsCardFlippedToFront()) return;

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

    public void CardHasBennMatched()
    {
        cardMatched = true;
    }

   


}
