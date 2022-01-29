using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColorManager : Singleton<ColorManager>
{
    public Color GameColor => SavingSystem.Instance.Data.GameColor;

    public event UnityAction OnColorChanged;

    public void ChangeColor(Image image)
    {
        SavingSystem.Instance.Data.GameColor = image.color;
        SavingSystem.Instance.Data.GameColorName = image.gameObject.name;
        SavingSystem.Instance.Save();

        OnColorChanged?.Invoke();
    }
}
