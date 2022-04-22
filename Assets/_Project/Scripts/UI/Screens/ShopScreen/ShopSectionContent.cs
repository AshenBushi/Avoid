using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopSectionContent : MonoBehaviour
{
    private RectTransform _rectTransform;
    private HorizontalLayoutGroup _horLayoutGroup;
    private List<IShopItem> _items = new List<IShopItem>();
    private List<ShopSectionContentPage> _pages = new List<ShopSectionContentPage>();
    private bool _isGetted = false;

    public RectTransform RectTransform => _rectTransform;
    public HorizontalLayoutGroup HorLayoutGroup => _horLayoutGroup;
    public List<ShopSectionContentPage> Pages => _pages;
    public List<IShopItem> Items => _items;

    public event Action OnEndedGettingComponents;

    private void Awake()
    {
        StartCoroutine(GetComponentsRoutine());
        ShopScreen.OnEnablingEvent += ShopItemsUpdate;
    }

    private void Start()
    {
        ColorManager.Instance.OnPlayerColorChanged += TrySetEnableCurrentItems;
        PlayerColorSetter.OnImageColorChangedEvent += TrySetEnableCurrentItems;
    }

    private void OnDisable()
    {
        ShopScreen.OnEnablingEvent -= ShopItemsUpdate;
        ColorManager.Instance.OnPlayerColorChanged -= TrySetEnableCurrentItems;
        PlayerColorSetter.OnImageColorChangedEvent -= TrySetEnableCurrentItems;
    }

    private void ShopItemsUpdate()
    {
        if (!_isGetted) return;

        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].Init(i);
            _items[i].TryEnable();
        }
    }

    private IEnumerator GetComponentsRoutine()
    {
        _rectTransform = GetComponent<RectTransform>();
        _horLayoutGroup = GetComponent<HorizontalLayoutGroup>();

        _pages = GetComponentsInChildren<ShopSectionContentPage>().ToList();

        for (int i = 0; i < _pages.Count; i++)
        {
            _pages[i].Init();
        }

        yield return null;

        _items = GetComponentsInChildren<IShopItem>().ToList();

        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].Init(i);
            _items[i].OnItemSelectedEvent += DeselectAllItems;
            _items[i].TryDisable();
        }

        _isGetted = true;
        OnEndedGettingComponents?.Invoke();
    }

    private void DeselectAllItems()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].TryDisable();
        }
    }

    private void TrySetEnableCurrentItems()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].TryEnable();
        }
    }
}
