using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CardContainer : MonoBehaviour
{

    [SerializeField] private float timer;

    List<Vector3> cardPositions = new List<Vector3>();

    private void Start()
    {
        GetCardPositions();
        ClockUI.Instance.SetTimer(timer);
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
            int cardIndex = Random.Range(0, cardPositions.Count);

            child.DOLocalMove(cardPositions[cardIndex], 1f);
            child.DOScale(Vector3.one, 1f);
            cardPositions.RemoveAt(cardIndex);
        }


    }



}
