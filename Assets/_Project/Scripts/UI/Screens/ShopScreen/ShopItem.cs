using UnityEngine;
using UnityEngine.UI;

public abstract class ShopItem : MonoBehaviour, IShopItem
{
    [SerializeField] protected Image _icon;

    protected Button _button;
    protected int _index;
    protected int _price;

    public int Index => _index;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(TrySelect);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TrySelect);
    }

    public virtual void Init(int index)
    {
        _index = index;
    }

    public abstract bool TryBuy();

    public abstract void TrySelect();

}
