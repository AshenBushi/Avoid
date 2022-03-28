public class ShopItemGameColor : ShopItem
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
        ColorManager.Instance.ChangeColor(_icon);
        SavingSystem.Instance.Data.CurSelectedGameColorIndex = _index;
        SavingSystem.Instance.Save();
    }
}
