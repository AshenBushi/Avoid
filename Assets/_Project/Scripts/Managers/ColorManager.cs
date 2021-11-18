using System;
using System.Collections;
using System.Collections.Generic;
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
        SavingSystem.Instance.Save();
        
        OnColorChanged?.Invoke();
    }
}
