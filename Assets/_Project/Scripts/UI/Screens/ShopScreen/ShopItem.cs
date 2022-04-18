using UnityEngine;
using UnityEngine.UI;

public abstract class ShopItem : MonoBehaviour, IShopItem
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected Image _lockIcon;

    protected Button _button;
    protected int _index;
    protected int _price;
    protected bool _isLocked = true;

    public int Index => _index;
    public bool IsLocked => _isLocked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    public abstract void Init(int index);

    public abstract void Buy();

    public virtual void Select() { }

    protected void EnableLockedIcon()
    {
        _lockIcon.gameObject.SetActive(true);
    }

    protected void DisableLockedIcon()
    {
        _lockIcon.gameObject.SetActive(false);
    }
}
