using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public event EventHandler OnCardClicked;
    public event EventHandler OnIncorrectCardFlipped;
    public event EventHandler OnShowCards;

    [SerializeField] private CardVisual cardVisual;
    [SerializeField] private CardSO cardSO;
    private CardContainer cardContainer;


    private bool cardMatched;

    private void Awake()
    {
        cardContainer = GetComponentInParent<CardContainer>();

    }

    public void CardClicked()
    {
        if (cardMatched || cardVisual.IsCardFlippedToFront() || !GameManager.Instance.IsGamePlaying()) return;

        if(GameManager.Instance.GetCanFlipCard())
        {
            GameManager.Instance.FlipToFrontCard(this);
            SoundManager.Instance.EmitFlipCardSound();
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
        cardContainer.RemoveCardFromListNotMatched(this);
    }

    public void ShowCards()
    {
        OnShowCards?.Invoke(this, EventArgs.Empty);    
    }
   
}
