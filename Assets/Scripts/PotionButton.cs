using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionButton : MonoBehaviour
{
    [SerializeField] private PotionsSO potionSO;

    public int GetPotionCost()
    {
        return potionSO.Cost;
    }
}
