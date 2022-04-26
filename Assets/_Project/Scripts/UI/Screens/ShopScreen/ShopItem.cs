using System;
using System.Collections.Generic;
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

    public event Action OnItemSelectedEvent;

    public int Index => _index;
    public bool IsLocked => _isLocked;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    public abstract void Init(int index);

    public abstract void Buy();

    public virtual void Select()
    {
        OnItemSelectedEvent?.Invoke();
        _icon.color = new Color(_icon.color.r, _icon.color.g, _icon.color.b, 1f);
    }

    public virtual void TryDisable()
    {
        _icon.color = new Color(_icon.color.r, _icon.color.g, _icon.color.b, 0.4f);
    }

    public virtual void TryEnable()
    {
        _icon.color = new Color(_icon.color.r, _icon.color.g, _icon.color.b, 1f);
    }

    protected void EnableLockedIcon()
    {
        _lockIcon.gameObject.SetActive(true);
    }

    protected void DisableLockedIcon()
    {
        _lockIcon.gameObject.SetActive(false);
    }
}
