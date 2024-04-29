using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsAnimations : MonoBehaviour
{
    private const string BREAK_ANIMATION = "Break";

    [SerializeField] private Button button;
    [SerializeField] private BonusEarnedUI bonusEarnedUI;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        button.onClick.AddListener(() =>
        {
            animator.SetTrigger(BREAK_ANIMATION);
            bonusEarnedUI.Show();
        });
    }


}
