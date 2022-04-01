public class ShopItemCharacter : ShopItem
{
    public override bool TryBuy()
    {
        if (SavingSystem.Instance.Data.Money < _price)
            return false;

        if (SavingSystem.Instance.Data.Shop.OpenedCharacters.Contains(_index))
            return false;

        SavingSystem.Instance.Data.Shop.OpenedCharacters.Add(_index);
        SavingSystem.Instance.Save();

        return true;
    }

    public override void TrySelect()
    {
        SavingSystem.Instance.Data.CurSelectedCharacterIndex = _index;

        if (!SavingSystem.Instance.Data.Shop.OpenedCharacters.Contains(_index))
            SavingSystem.Instance.Data.Shop.OpenedCharacters.Add(_index);

        SavingSystem.Instance.Save();

        ColorManager.Instance.ChangePlayerSkin();
    }
}
