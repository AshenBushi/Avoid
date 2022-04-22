using UnityEngine;

public class ShopItemBackground : ShopItem
{
    public override void Init(int index)
    {
        _index = index;
        _price = 50;

        if (SavingSystem.Instance.Data.Shop.OpenedBackgrounds.Contains(index))
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
        if (SavingSystem.Instance.Data.Shop.OpenedBackgrounds.Contains(_index)) return;
        if (!Bank.Instance.TryWithdrawMoney(_price)) return;

        DisableLockedIcon();
        SavingSystem.Instance.Data.Shop.OpenedBackgrounds.Add(_index);
        Select();
    }

    public override void Select()
    {
        SavingSystem.Instance.Data.Shop.CurSelectedBackgroundIndex = _index;
        SavingSystem.Instance.Save();
        base.Select();
    }

    public override void TryDisable()
    {
        base.TryDisable();
        if (_index == SavingSystem.Instance.Data.Shop.CurSelectedBackgroundIndex)
            TryEnable();
    }
}
