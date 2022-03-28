public class ShopItemCharacterColor : ShopItem
{
    public override bool TryBuy()
    {
        if (SavingSystem.Instance.Data.Money < _price)
            return false;

        if (SavingSystem.Instance.Data.Shop.OpenedCharacterColors.Contains(_index))
            return false;

        SavingSystem.Instance.Data.Shop.OpenedCharacterColors.Add(_index);
        SavingSystem.Instance.Save();

        return true;
    }

    public override void TrySelect()
    {
        SavingSystem.Instance.Data.CurSelectedCharacterColorIndex = _index;
        SavingSystem.Instance.Save();
    }
}
