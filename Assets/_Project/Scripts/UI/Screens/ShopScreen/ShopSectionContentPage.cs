using UnityEngine;

public class ShopSectionContentPage : MonoBehaviour
{
    private RectTransform _rectTransform;
    public RectTransform RectTransform => _rectTransform;

    public void Init()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
}
