using UnityEngine;

public class ShopScreen : UIScreen
{
    [SerializeField] private StartScreen _startScreen;

    public override void Enable()
    {
        base.Enable();
        _startScreen.Disable();
        CanvasGroup.interactable = true;
    }

    public override void Disable()
    {
        base.Disable();
        _startScreen.Enable();
        CanvasGroup.interactable = false;
    }
}
