using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopNavigation : MonoBehaviour
{
    private int _currentPage = 0;
    private List<ShopPage> _pages = new List<ShopPage>();
    private List<ShopNavigationTab> _shopTab = new List<ShopNavigationTab>();

    public static Action<int> OnSelectTab;

    private void Awake()
    {
        StartCoroutine(GetComponentsRoutine());
    }

    private void OnDisable()
    {
        OnSelectTab -= SelectTab;
    }

    private IEnumerator GetComponentsRoutine()
    {
        _shopTab = GetComponentsInChildren<ShopNavigationTab>().ToList();
        _pages = transform.parent.GetComponentsInChildren<ShopPage>().ToList();
        yield return null;

        for (int i = 0; i < _shopTab.Count; i++)
        {
            _shopTab[i].Init(i);
        }

        for (int i = 0; i < _pages.Count; i++)
        {
            _pages[i].Init(i);
        }
        yield return null;

        ActivatedPages();
        ActivatedTabs();

        OnSelectTab += SelectTab;
    }

    private void ActivatedPages()
    {
        for (int i = 0; i < _pages.Count; i++)
        {
            if (i == _currentPage)
                _pages[i].Show();
            else
                _pages[i].Hide();
        }
    }

    private void ActivatedTabs()
    {
        for (int i = 0; i < _shopTab.Count; i++)
        {
            if (i == _currentPage)
                _shopTab[i].Show();
            else
                _shopTab[i].Hide();
        }
    }

    private void SelectTab(int indexTab)
    {
        _currentPage = indexTab;

        ActivatedPages();
        ActivatedTabs();
    }
}
