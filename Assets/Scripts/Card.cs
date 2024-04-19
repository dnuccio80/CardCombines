using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public event EventHandler OnCardClicked;

    public void CardClicked()
    {
        OnCardClicked?.Invoke(this, EventArgs.Empty);
    }



}
