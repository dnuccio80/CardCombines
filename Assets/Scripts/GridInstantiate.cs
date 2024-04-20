using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInstantiate : MonoBehaviour
{

    [SerializeField] private Transform cardPrefab;
    [SerializeField] private float number;
    private float offset = 1.7f;
    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            for(int j = 0; j < number; j++) 
            {
                Transform newCard = Instantiate(cardPrefab) as Transform;
                newCard.transform.position = new Vector3(i * offset, j * offset, 0f);
            }
        }
    }

}
