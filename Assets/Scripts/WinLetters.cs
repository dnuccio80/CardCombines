using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class WinLetters : MonoBehaviour
{
    [SerializeField] private GameWinUI gameWinUI;

    private float xShowposition;
    private float xHidePosition = -1300f;
    private float yShowPosition = 200f;

     private void Start()
    {
        xShowposition = transform.localPosition.x;
        transform.localPosition = new Vector3(xHidePosition, 0, 0);
        gameWinUI.OnGameWinShow += GameWinUI_OnGameWinShow;
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
