using UnityEngine;

public class ShopScreen : UIScreen
{
    public override void Enable()
    {
        base.Enable();
        CanvasGroup.interactable = true;
    }

    public override void Disable()
    {
        base.Disable();
        CanvasGroup.interactable = false;
    }
}
