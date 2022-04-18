using System;
using UnityEngine;

public class ShopScreen : UIScreen
{
    [SerializeField] private StartScreen _startScreen;

    public static Action OnEnablingEvent;

    public override void Enable()
    {
        base.Enable();
        _startScreen.Disable();
        CanvasGroup.interactable = true;
        OnEnablingEvent?.Invoke();
    }

    public override void Disable()
    {
        base.Disable();
        _startScreen.Enable();
        CanvasGroup.interactable = false;
    }
}
