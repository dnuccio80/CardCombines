using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if(!rayHit.collider) return;

        if(rayHit.collider.TryGetComponent<Card>(out Card card))
        {
            card.CardClicked();
        } else if(rayHit.collider.TryGetComponent<Potion>(out Potion potion))
        {
            potion.TryUsePotion();
        }
        

    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(!context.started) return;
        GameManager.Instance.ToggleGamePause();
    }


}

