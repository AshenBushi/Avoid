using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColorManager : Singleton<ColorManager>
{
    public Color UIColor => SavingSystem.Instance.Data.UIColor;
    public Color PlayerColor => SavingSystem.Instance.Data.PlayerColor;

    public event UnityAction OnUIColorChanged, OnPlayerColorChanged;

    public void ChangeUIColor(Image image)
    {
        SavingSystem.Instance.Data.UIColor = image.color;
        SavingSystem.Instance.Data.UIColorName = image.gameObject.name;
        SavingSystem.Instance.Save();

        OnUIColorChanged?.Invoke();
    }

    public void ChangePlayerColor(Image image)
    {
        SavingSystem.Instance.Data.PlayerColor = image.color;
        SavingSystem.Instance.Save();

        OnPlayerColorChanged?.Invoke();
    }
}
