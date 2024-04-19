using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public event EventHandler OnCardsMatches;
    public event EventHandler OnCardDoesNotMatches;

    private Card cardA;
    private Card cardB;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            CleanCards();
        }
    }
    public void FlipToFrontCard(Card card)
    {

        if (cardA != null && cardB != null) return;

        if(cardA == null) cardA = card;
        else
        {
            cardB = card;
            Invoke("CheckCardMatches", 1f);
        } 

    }

    private void CheckCardMatches()
    {
        if(cardA.GetCardName() == cardB.GetCardName())
        {
            Debug.Log("Las cartas coinciden");
            CleanCards();
        } else
        {
            Debug.Log("Las cartas no coinciden");
            cardA.CardDoesNotMatch();
            cardB.CardDoesNotMatch();
            CleanCards();
        }
    }

    public void CleanCards()
    {
        cardA = null;
        cardB = null;
    }

    public bool GetCanFlipCard()
    {
        return cardA == null || cardB == null;
    }
}
