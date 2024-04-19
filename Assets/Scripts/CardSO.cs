using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardSO : ScriptableObject
{

    [SerializeField] private Sprite cardImage;
    [SerializeField] private string cardName;

    public Sprite CardImage { get { return cardImage; } }
    public string CardName { get {  return cardName; } }


}
