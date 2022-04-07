using System.Collections.Generic;
using UnityEngine;

public class ShopSectionNavigation : MonoBehaviour
{
    [SerializeField] private ShopSectionNavigationPoint _templatePoint;
    [SerializeField] private ShopSectionContent _shopSectionContent;

    private List<ShopSectionNavigationPoint> _points = new List<ShopSectionNavigationPoint>();

    private void Awake()
    {
        _shopSectionContent.OnEndedGettingComponents += SetPoints;
    }

    private void OnDisable()
    {
        _shopSectionContent.OnEndedGettingComponents -= SetPoints;
    }

    public void SetPoints()
    {
        if (_shopSectionContent.Pages.Count == 1 || _points.Count > 0) return;

        for (int i = 0; i < _shopSectionContent.Pages.Count; i++)
        {
            _points.Add(Instantiate(_templatePoint, transform));
        }

        for (int i = 0; i < _points.Count; i++)
        {
            _points[i].Disable();
        }

        EnablePointCurrentPage(0);
    }

    public void EnablePointCurrentPage(int index)
    {
        if (index > _points.Count || index < 0) return;

        for (int i = 0; i < _points.Count; i++)
        {
            if (i == index)
                _points[i].Enable();
            else _points[i].Disable();
        }
    }
}
