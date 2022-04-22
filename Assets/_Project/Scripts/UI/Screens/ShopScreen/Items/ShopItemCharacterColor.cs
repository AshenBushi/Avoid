using UnityEngine;

public class ShopItemCharacterColor : ShopItem
{
    public override void Init(int index)
    {
        _index = index;
        _price = 50;

        if (SavingSystem.Instance.Data.Shop.OpenedCharacterColors.Contains(index))
        {
            _button.onClick.AddListener(Select);
            DisableLockedIcon();
            return;
        }

        _button.onClick.AddListener(Buy);
    }

    public override void Buy()
    {
        if (!_isLocked) return;
        if (SavingSystem.Instance.Data.Shop.OpenedCharacterColors.Contains(_index)) return;
        if (!Bank.Instance.TryWithdrawMoney(_price)) return;

        DisableLockedIcon();
        SavingSystem.Instance.Data.Shop.OpenedCharacterColors.Add(_index);
        Select();
    }

    public override void Select()
    {
        ColorManager.Instance.ChangePlayerColor(_icon);
        SavingSystem.Instance.Data.Shop.CurSelectedCharacterColorIndex = _index;
        SavingSystem.Instance.Save();
        base.Select();
    }

    public override void TryDisable()
    {
        if (_index == SavingSystem.Instance.Data.Shop.CurSelectedCharacterColorIndex) return;

        base.TryDisable();
    }

    public override void TryEnable()
    {
        if (_index == SavingSystem.Instance.Data.Shop.CurSelectedCharacterColorIndex)
            base.TryEnable();
    }
}
