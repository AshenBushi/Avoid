using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColorManager : Singleton<ColorManager>
{
    [SerializeField] private List<Sprite> _playerSkinsSprites;

    public Color UIColor => SavingSystem.Instance.Data.UIColor;
    public Color PlayerColor => SavingSystem.Instance.Data.PlayerColor;

    public event UnityAction OnUIColorChanged, OnPlayerColorChanged;
    public event UnityAction<Sprite> OnPlayerSkinChange;

    private void Start()
    {
        ChangePlayerSkin();
    }

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

    public void ChangePlayerSkin()
    {
        if (_playerSkinsSprites[SavingSystem.Instance.Data.CurSelectedCharacterIndex] != null)
            OnPlayerSkinChange?.Invoke(_playerSkinsSprites[SavingSystem.Instance.Data.CurSelectedCharacterIndex]);
        else
            OnPlayerSkinChange?.Invoke(_playerSkinsSprites[0]);
    }
}
