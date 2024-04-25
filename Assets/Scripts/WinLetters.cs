using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class WinLetters : MonoBehaviour
{

    private float xShowposition;
    private float xHidePosition;
    private float yShowPosition;

    private void Start()
    {
        xShowposition = transform.localPosition.x;
        yShowPosition = 200f;
        xHidePosition = -1300f;
        GameWinUI.Instance.OnGameWinShow += GameWinUI_OnGameWinShow;
        GameWinUI.Instance.OnGameWinHide += GameWinUI_OnGameWinHide;
    }


    private void GameWinUI_OnGameWinShow(object sender, System.EventArgs e)
    {
        ShowLetter();
    }
    private void GameWinUI_OnGameWinHide(object sender, System.EventArgs e)
    {
        HideLetter();
    }

    private void ShowLetter()
    {
        transform.DOLocalMoveX(xShowposition, 1f)
            .OnComplete(() =>
            {
                transform.DOLocalMoveY(yShowPosition, 1f);
                transform.DOScale(1, 1f);
            });
    }
    
    
    
    private void HideLetter()
    {
        transform.localPosition = new Vector3(xHidePosition, 0f, 0f);
    }


}
