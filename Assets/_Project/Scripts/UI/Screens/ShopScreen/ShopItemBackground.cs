public class ShopItemBackground : ShopItem
{
    public override bool TryBuy()
    {
        if (SavingSystem.Instance.Data.Money < _price)
            return false;

        if (SavingSystem.Instance.Data.Shop.OpenedBackgrounds.Contains(_index))
            return false;

        SavingSystem.Instance.Data.Shop.OpenedBackgrounds.Add(_index);
        SavingSystem.Instance.Save();

        return true;
    }

    public override void TrySelect()
    {
        SavingSystem.Instance.Data.CurSelectedBackgroundIndex = _index;
        SavingSystem.Instance.Save();
    }
}
