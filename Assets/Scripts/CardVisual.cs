using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour
{
    [SerializeField] private Sprite backCardImage;
    [SerializeField] private Card card;
    private CardContainer cardContainer; 
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Sprite frontImage;

    private enum CardSide
    {
        front,
        back
    }

    private CardSide currentSide;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentSide = CardSide.back;
        cardContainer = GetComponentInParent<CardContainer>();
    }
    private void Start()
    {
        spriteRenderer.sprite = backCardImage;
        frontImage = card.GetFrontCardImage();

        card.OnCardClicked += Card_OnCardClicked;
        card.OnIncorrectCardFlipped += Card_OnIncorrectCardFlipped;
        card.OnShowCards += Card_OnShowMatchCards;
    }

    private void Card_OnShowMatchCards(object sender, System.EventArgs e)
    {
        StartCoroutine(ShowMatchCards());
    }

    private void Card_OnIncorrectCardFlipped(object sender, System.EventArgs e)
    {
        FlipToBack();
    }

    private void Card_OnCardClicked(object sender, System.EventArgs e)
    {
        if(currentSide == CardSide.back) FlipToFront();
    }

    private void FlipToFront()
    {
        animator.SetTrigger("FlipFront");
        currentSide = CardSide.front;
    }
    private void FlipToBack()
    {
        animator.SetTrigger("FlipBack");
        currentSide = CardSide.back;
    }

    public void SetFrontImage()
    {
        spriteRenderer.sprite = frontImage;
    }

    public void SetBackImage()
    {
        spriteRenderer.sprite = backCardImage;

    }

    public bool IsCardFlippedToFront()
    {
        return currentSide == CardSide.front;
    }

    private IEnumerator ShowMatchCards()
    {
        float timerShowCards = 1f;
        FlipToFront();
        yield return new WaitForSeconds(timerShowCards);
        FlipToBack();
    }

}
