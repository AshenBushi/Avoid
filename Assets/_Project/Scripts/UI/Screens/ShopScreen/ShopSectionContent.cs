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

    public RectTransform RectTransform => _rectTransform;
    public HorizontalLayoutGroup HorLayoutGroup => _horLayoutGroup;
    public List<ShopSectionContentPage> Pages => _pages;

    public List<IShopItem> Items => _items;

    public event Action OnItemsAdded;

    private void Awake()
    {
        StartCoroutine(GetComponentsRoutine());
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
        }

        OnItemsAdded?.Invoke();
    }
}
