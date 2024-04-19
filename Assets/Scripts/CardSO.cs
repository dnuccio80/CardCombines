using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardSO : ScriptableObject
{

    [SerializeField] private Sprite cardImage;

    public Sprite CardImage { get { return cardImage; } }




}
