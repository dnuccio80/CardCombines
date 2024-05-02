using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class CardContainer : MonoBehaviour
{
    public event EventHandler OnCardContainerHide;

    [SerializeField] private float timer;
    [SerializeField] private int levelNumber;
    
    private Transform levelContainerTransform; 
    private int cardsAmount;
    
    List<Vector3> cardPositions = new List<Vector3>();


    private void Awake()
    {
        levelContainerTransform = GetComponentInParent<LevelContainer>().transform;
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        Hide();
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        //if(e.gameState == GameManager.GameState.WaitingToStart)
        //{
        //    if (GameManager.Instance.GetLevelNumber() == levelNumber) Show();
        //    else Hide();
        //} 
    }

    private void GetCardPositions()
    {
        foreach(Transform child in transform)
        {
            cardsAmount++;
            cardPositions.Add(child.localPosition);
            child.localPosition = new Vector3(-10f,0f,0f);
            child.localScale = Vector3.one * 1.3f;
        }

        MixCards();
    }

    private void MixCards()
    {
        foreach (Transform child in transform)
        {
            int cardIndex = UnityEngine.Random.Range(0, cardPositions.Count);

            child.DOLocalMove(cardPositions[cardIndex], 1f);
            child.DOScale(Vector3.one, 1f)
                .OnComplete(() =>
                {
                    GameManager.Instance.StartCountdown();
                });
            cardPositions.RemoveAt(cardIndex);
        }

        GameManager.Instance.ChangeCardsToMatchAmount(cardsAmount);

    }

    private void Show()
    {
        gameObject.SetActive(true);
        levelContainerTransform.gameObject.SetActive(true);
        ClockUI.Instance.SetTimer(timer);
        GetCardPositions();
    }

    private void Hide()
    {
        cardPositions.Clear();
        levelContainerTransform.gameObject.SetActive(false);
        OnCardContainerHide?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(false);
    }



}
