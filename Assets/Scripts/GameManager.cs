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
    public event EventHandler<OnToggleGamePauseEventArgs> OnToggleGamePause;
    public event EventHandler OnShowMatchCardsButtonPressed;
    public event EventHandler OnShowAllCardsButtonPressed;

    public class OnToggleGamePauseEventArgs : EventArgs
    {
        public GameState gameState;
    }
    public class OnGameStateChangedEventArgs : EventArgs
    {
        public GameState gameState;
    }

    private Card cardA;
    private Card cardB;

    public enum GameState
    {
        LevelSelection,
        CountdownToStart,
        GamePlaying,
        GamePaused,
        GameOver,
        GameWin
    }

    private GameState gameState;

    private int cardsToMatchAmount;
    private int levelNumber;

    // CountdownToStart System
    private float countdownTimer;
    private float countdownTimerMax = 3f;

    // GamePlaying System
    private float playingTimer;


    // In case to Win
    private int coinsEarned;

    private void Awake()
    {
        Instance = this;
        gameState = GameState.LevelSelection;
    }

    private void Start()
    {
        this.OnCardsMatches += GameManager_OnCardsMatches;
        this.OnGameStateChanged += GameManager_OnGameStateChanged;
        this.OnShowMatchCardsButtonPressed += GameManager_OnShowMatchCardsButtonPressed;
        this.OnShowAllCardsButtonPressed += GameManager_OnShowAllCardsButtonPressed;
    }

    private void Update()
    {
        switch(gameState)
        {
            case GameState.LevelSelection:
                countdownTimer = countdownTimerMax;
                break;
            case GameState.CountdownToStart:
                countdownTimer -= Time.deltaTime;
                if(countdownTimer <= 0 )
                {
                    ChangeGameState(GameState.GamePlaying);
                }
                break;
            case GameState.GamePlaying:
                countdownTimer = countdownTimerMax;
                playingTimer -= Time.deltaTime;
                if (playingTimer <= 0) ChangeGameState(GameState.GameOver);
                break;

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

    private void GameManager_OnShowMatchCardsButtonPressed(object sender, EventArgs e)
    {
        if (cardA != null)
        {
            cardA.CardDoesNotMatch();
            CleanCards();
        }
    }

    private void GameManager_OnShowAllCardsButtonPressed(object sender, EventArgs e)
    {
        if (cardA != null)
        {
            cardA.CardDoesNotMatch();
            CleanCards();
        }
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
            PlayerStats.IncrementCoinsAmount(this, coinsEarned);
            PlayerStats.ChangeMaxLevelCompleted(this,levelNumber);
        } 
    }

    public void ToggleGamePause()
    {
        if (gameState == GameState.GamePlaying) ChangeGameState(GameState.GamePaused);
        else if (gameState == GameState.GamePaused) ChangeGameState(GameState.GamePlaying);

        OnToggleGamePause?.Invoke(this, new OnToggleGamePauseEventArgs
        {
            gameState = gameState
        });
    }

    public void StartGame(int _levelNumber)
    {
        levelNumber = _levelNumber;
        ChangeGameState(GameState.CountdownToStart);
    }

    public void SetPlayingConfig(float _timer, int cardsAmount, int coinsToEarn)
    {
        playingTimer = _timer;
        cardsToMatchAmount = cardsAmount;
        coinsEarned = coinsToEarn;
    }

    public void UsePotion_ExtraTime()
    {
        int incrementTimer = 5;
        playingTimer += incrementTimer;
    }
    public void UsePotion_ShowMatchCards()
    {
        OnShowMatchCardsButtonPressed?.Invoke(this, EventArgs.Empty);
    }

    public void UsePotion_ShowAllCards()
    {
        OnShowAllCardsButtonPressed?.Invoke(this, EventArgs.Empty);

    }

    public int GetLevelNumber()
    {
        return levelNumber;
    }

    public float GetCountdownTimer()
    {
        return countdownTimer;
    }

    public float GetPlayingTimer()
    {
        return playingTimer;
    }

    public int GetCoinsEarned()
    {
        return coinsEarned; 
    }

    


}
