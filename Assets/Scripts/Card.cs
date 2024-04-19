using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public event EventHandler<OnCardClickedEventArgs> OnCardClicked;
    
    public class OnCardClickedEventArgs : EventArgs
    {
        public CardSO cardSO;
    }

    [SerializeField] private CardSO cardSO;

    public void CardClicked()
    {
        OnCardClicked?.Invoke(this, new OnCardClickedEventArgs
        {
            cardSO = cardSO
        }) ;
    }

    public Sprite GetFrontCardImage()
    {
        return cardSO.CardImage;
    }


}
