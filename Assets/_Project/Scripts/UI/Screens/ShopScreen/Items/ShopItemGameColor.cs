using UnityEngine;

public class ShopItemGameColor : ShopItem
{
    public override void Init(int index)
    {
        _index = index;
        _price = 50;

        if (SavingSystem.Instance.Data.Shop.OpenedGameColors.Contains(index))
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
        if (SavingSystem.Instance.Data.Shop.OpenedGameColors.Contains(_index)) return;
        if (!Bank.Instance.TryWithdrawMoney(_price)) return;

        DisableLockedIcon();
        SavingSystem.Instance.Data.Shop.OpenedGameColors.Add(_index);
        Select();
    }

    public override void Select()
    {
        ColorManager.Instance.ChangeUIColor(_icon);
        SavingSystem.Instance.Data.Shop.CurSelectedGameColorIndex = _index;
        SavingSystem.Instance.Save();
        base.Select();
    }

    public override void TryDisable()
    {
        base.TryDisable();
        
    }

    public override void TryEnable()
    {
        if (_index == SavingSystem.Instance.Data.Shop.CurSelectedGameColorIndex)
            base.TryEnable();
    }
}
