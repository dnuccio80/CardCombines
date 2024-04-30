using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PotionsSO : ScriptableObject
{
    [SerializeField] private string potionName;
    [SerializeField] private int cost;

    public string PotionName {  get { return potionName; } }
    public int Cost {  get { return cost; } }

}
