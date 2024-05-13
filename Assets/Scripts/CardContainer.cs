using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class CardContainer : MonoBehaviour
{
    public event EventHandler OnCardContainerHide;

    List<Vector3> cardPositions = new List<Vector3>();

    List<Card> cardsDontMatchedList = new List<Card>(); 

    private LevelContainer levelContainer;

    private void Awake()
    {
        levelContainer = GetComponentInParent<LevelContainer>();
    }

    private void Start()
    {
        GameManager.Instance.OnShowMatchCardsButtonPressed += GameManager_OnShowMatchCardsButtonPressed;
        GameManager.Instance.OnShowAllCardsButtonPressed += GameManager_OnShowAllCardsButtonPressed;
        levelContainer.OnLevelPlaying += LevelContainer_OnLevelPlaying;
        InitCardsDontMatchedList();
    }

    private void LevelContainer_OnLevelPlaying(object sender, EventArgs e)
    {
        GetCardPositions();
    }

    private void GameManager_OnShowMatchCardsButtonPressed(object sender, EventArgs e)
    {
       if(gameObject.activeInHierarchy)
        {
            ShowMatchCardsOnce();
        }
    }
    private void GameManager_OnShowAllCardsButtonPressed(object sender, EventArgs e)
    {
        if (gameObject.activeInHierarchy)
        {
            ShowAllCards();
        }
    }

    private void GetCardPositions()
    {
        foreach(Transform child in transform)
        {
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
            child.DOScale(Vector3.one, 1f);
            cardPositions.RemoveAt(cardIndex);
        }
    }


    private void Hide()
    {
        cardPositions.Clear();
        OnCardContainerHide?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(false);
    }

    private void InitCardsDontMatchedList()
    {
        foreach (Transform child in transform)
        {
            Card card = child.GetComponent<Card>();
            cardsDontMatchedList.Add(card);
        }
    }

    public void RemoveCardFromListNotMatched(Card card)
    {
        cardsDontMatchedList.Remove(card);
    }

    private void ShowMatchCardsOnce()
    {
        Card cardA = cardsDontMatchedList[UnityEngine.Random.Range(0,cardsDontMatchedList.Count)];

        cardsDontMatchedList.Remove(cardA);

        for(int i = 0; i < cardsDontMatchedList.Count; i++)
        {
            if (cardsDontMatchedList[i].GetCardName() == cardA.GetCardName())
            {
                cardsDontMatchedList.Add(cardA);
                cardA.ShowCards();
                cardsDontMatchedList[i].ShowCards();
                break;

            }
        }
    }

    private void ShowAllCards()
    {
        for(int i = 0;i < cardsDontMatchedList.Count; i++)
        {
            cardsDontMatchedList[i].ShowCards();
        }
    }
}
