public class ShopItemCharacter : ShopItem
{
    public override void Init(int index)
    {
        _index = index;
        _price = 100;

        if (SavingSystem.Instance.Data.Shop.OpenedCharacters.Contains(index))
        {
            _button.onClick.AddListener(Select);
            DisableLockedIcon();
            return;
        }

        _button.onClick.AddListener(Buy);
    }

    public override void Buy()
    {
        if (SavingSystem.Instance.Data.Shop.OpenedCharacters.Contains(_index))
        {
            Select();
            return;
        }

        if (!_isLocked) return;

        if (!Bank.Instance.TryWithdrawMoney(_price)) return;

        DisableLockedIcon();

        SavingSystem.Instance.Data.Shop.OpenedCharacters.Add(_index);

        Select();
    }

    public override void Select()
    {
        ColorManager.Instance.ChangePlayerSkin();
        SavingSystem.Instance.Data.Shop.CurSelectedCharacterIndex = _index;
        SavingSystem.Instance.Save();
        base.Select();
    }

    public override void TryDisable()
    {
        if (_index == SavingSystem.Instance.Data.Shop.CurSelectedCharacterIndex) return;

        base.TryDisable();
    }

    public override void TryEnable()
    {
        if (_index == SavingSystem.Instance.Data.Shop.CurSelectedCharacterIndex)
            base.TryEnable();
    }
}
