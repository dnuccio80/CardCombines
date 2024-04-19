using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour
{

    [SerializeField] private CardSO cardSO;
    [SerializeField] private Sprite backCardImage;
    [SerializeField] private Card card;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

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
        
    }
    private void Start()
    {
        spriteRenderer.sprite = backCardImage;
        card.OnCardClicked += Card_OnCardClicked;
        currentSide = CardSide.back;
    }

    private void Card_OnCardClicked(object sender, System.EventArgs e)
    {
        switch (currentSide)
        {
            case CardSide.front:
                FlipToBack();
                break;
            case CardSide.back:
                FlipToFront();
                break;
        }
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
        spriteRenderer.sprite = cardSO.CardImage;
    }

    public void SetBackImage()
    {
        spriteRenderer.sprite = backCardImage;

    }


}
