public class ShopItemGameColor : ShopSectionContentItem
{
    public override bool TryBuy()
    {
        if (SavingSystem.Instance.Data.Money < _price)
            return false;

        if (SavingSystem.Instance.Data.Shop.OpenedGameColors.Contains(_index))
            return false;

        SavingSystem.Instance.Data.Shop.OpenedGameColors.Add(_index);
        SavingSystem.Instance.Save();

        return true;
    }

    public override void TrySelect()
    {
        SavingSystem.Instance.Data.CurSelectedGameColorIndex = _index;
        SavingSystem.Instance.Save();
    }
}
