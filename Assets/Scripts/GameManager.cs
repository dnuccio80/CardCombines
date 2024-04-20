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

    private void Start()
    {
        this.OnCardsMatches += GameManager_OnCardsMatches;
    }

    private void GameManager_OnCardsMatches(object sender, EventArgs e)
    {
        cardA.CardHasBennMatched();
        cardB.CardHasBennMatched();
    }

    public void FlipToFrontCard(Card card)
    {
        if (cardA != null && cardB != null) return;

        float timeToCheckMatch = .4f;

        if(cardA == null) cardA = card;
        else
        {
            cardB = card;
            Invoke("CheckCardMatches", timeToCheckMatch);
        } 

    }

    private void CheckCardMatches()
    {
        if(cardA.GetCardName() == cardB.GetCardName())
        {
            Debug.Log("Las cartas coinciden");
            OnCardsMatches?.Invoke(this,EventArgs.Empty);
            CleanCards();
        } else
        {
            Debug.Log("Las cartas no coinciden");
            OnCardDoesNotMatches?.Invoke(this,EventArgs.Empty);
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
