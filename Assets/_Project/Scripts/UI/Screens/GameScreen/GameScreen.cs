using UnityEngine;

public class GameScreen : UIScreen
{
    [SerializeField] private BonusDisplay _bonusDisplay;

    public BonusDisplay BonusDisplay => _bonusDisplay;

    public void SmallDimm()
    {
        CanvasGroup.alpha = 0.6f;
    }

    public void Show()
    {
        CanvasGroup.alpha = 1f;
    }
}
