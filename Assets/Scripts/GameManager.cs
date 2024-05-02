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
        Wait,
        WaitingToStart,
        CountDownNew,
        CountdownToStart,
        GamePlaying,
        GamePaused,
        GameOver,
        GameWin
    }

    private GameState gameState;

    private int cardsToMatchAmount;
    private int levelNumber;

    private void Awake()
    {
        Instance = this;
        gameState = GameState.Wait;
        //StartGame(PlayerStats.GetLevelToPlay());

    }

    private void Start()
    {
        this.OnCardsMatches += GameManager_OnCardsMatches;
        this.OnGameStateChanged += GameManager_OnGameStateChanged;
        StartGame();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //levelNumber = PlayerStats.GetLevelToPlay();
            //ChangeGameState(GameState.CountDownNew);
            StartGame();
            Debug.Log(gameState + " " +  levelNumber);
        }
    }

    private void GameManager_OnGameStateChanged(object sender, OnGameStateChangedEventArgs e)
    {
        if(e.gameState == GameState.GamePaused) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    private void GameManager_OnCardsMatches(object sender, EventArgs e)
    {
        cardA.CardHasBennMatched();
        cardB.CardHasBennMatched();

        DecreaseCardToMatchAmount();
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
            OnCardsMatches?.Invoke(this,EventArgs.Empty);
            CleanCards();
        } else
        {
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

    public void CountdownTimerOver()
    {
        ChangeGameState(GameState.GamePlaying);
    }

    public void GameWin()
    {
        ChangeGameState(GameState.GameWin);
    }

    public void StartCountdown()
    {
        ChangeGameState(GameState.CountdownToStart);
    }

    public void ChangeCardsToMatchAmount(int value)
    {
        cardsToMatchAmount = value;
    }

    private void DecreaseCardToMatchAmount()
    {
        int cardsMatched = 2;

        cardsToMatchAmount -= cardsMatched;

        if (cardsToMatchAmount == 0)
        {
            ChangeGameState(GameState.GameWin);
            PlayerStats.ChangeMaxLevelCompleted(this,levelNumber);
        } 
    }

    public void ToggleGamePause()
    {
        if (gameState == GameState.GamePlaying) ChangeGameState(GameState.GamePaused);
        else if (gameState == GameState.GamePaused) ChangeGameState(GameState.GamePlaying);
    }

    public void StartGame()
    {
        levelNumber = PlayerStats.GetLevelToPlay();
        ChangeGameState(GameState.CountDownNew);

        Debug.Log(levelNumber);
        Debug.Log(gameState);
    }

    public int GetLevelNumber()
    {
        return levelNumber;
    }
    
}
