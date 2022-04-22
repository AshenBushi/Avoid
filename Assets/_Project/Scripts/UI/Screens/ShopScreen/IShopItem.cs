using System;

public interface IShopItem
{
    public int Index { get; }
    public void Init(int index);
    public void Buy();
    public void Select();
    public void TryEnable();
    public void TryDisable();
    public event Action OnItemSelectedEvent;
}
