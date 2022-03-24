using UnityEngine;

public interface IShopItem
{
    public int Index { get; }

    public void Init(int index);
    public bool TryBuy();
    public void TrySelect();
}
