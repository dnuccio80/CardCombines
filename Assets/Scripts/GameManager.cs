using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public event EventHandler OnCardsMatches;
    public event EventHandler OnCardDoesNotMatches;
    public event EventHandler<OnGameStateChangedEventArgs> OnGameStateChanged;

    public class OnGameStateChangedEventArgs : EventArgs
    {
        public GameState gameState;
    }

    private Card cardA;
    private Card cardB;

    public enum GameState
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GamePaused,
        GameOver,
        GameWin
    }

    private GameState gameState;

    private void Awake()
    {
        Instance = this;
        gameState = GameState.WaitingToStart;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            ChangeGameState(GameState.GamePlaying);
        }

        switch(gameState)
        {
            case GameState.WaitingToStart:
                break; 
            case GameState.CountdownToStart:
                break;
            case GameState.GamePlaying:
                break;
            case GameState.GamePaused:
                break;
            case GameState.GameOver:
                break;
            case GameState.GameWin: 
                break;
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

    private void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
        OnGameStateChanged?.Invoke(this, new OnGameStateChangedEventArgs
        {
            gameState = _gameState
        });
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

    public bool IsGamePlaying()
    {
        return gameState == GameState.GamePlaying;
    }

    public void TimerPlayingIsOver()
    {
        ChangeGameState(GameState.GameOver);
    }
    
}
