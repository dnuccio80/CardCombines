using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    
    List<Vector3> cardPositions = new List<Vector3>();

    private void Start()
    {
        GetCardPositions();
    }

    private void GetCardPositions()
    {
        foreach(Transform child in transform)
        {
            cardPositions.Add(child.localPosition);
        }

        MixCards();
    }

    private void MixCards()
    {
        foreach (Transform child in transform)
        {
            int cardIndex = Random.Range(0, cardPositions.Count);
            child.localPosition = cardPositions[cardIndex];
            cardPositions.RemoveAt(cardIndex);
        }


    }



}
