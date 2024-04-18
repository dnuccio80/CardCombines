using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadradoImage : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Animator animator;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void RotateCard()
    {
        animator.SetTrigger("Rotate");
    }

    public void ChangeColor()
    {
        spriteRenderer.color = Random.ColorHSV();
    }

}
