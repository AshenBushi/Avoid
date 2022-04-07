using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSectionSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private float _duration;

    private ShopSectionContent _content;
    private ShopSectionNavigation _navigation;
    private int _currentPage = 0;
    private int _fastScrollIndex = 0;
    private bool _isFastScroll = false;

    private void Awake()
    {
        _content = GetComponentInChildren<ShopSectionContent>();
        _navigation = GetComponentInChildren<ShopSectionNavigation>();
    }

    private void Start()
    {
        SelectCurrentPage(0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > 2)
        {
            if (eventData.delta.x < 0)
                _fastScrollIndex = 1;
            else
                _fastScrollIndex = -1;
            _isFastScroll = true;
        }
        else
        {
            _isFastScroll = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isFastScroll)
        {
            if ((_currentPage + _fastScrollIndex) >= 0 && (_currentPage + _fastScrollIndex) < _content.Pages.Count)
            {
                _currentPage += _fastScrollIndex;
            }
        }
        else
        {
            var currentX = float.MaxValue;

            for (var i = 0; i < _content.Pages.Count; i++)
            {
                if (!(Mathf.Abs(_content.Pages[i].RectTransform.position.x) < currentX)) continue;

                currentX = Mathf.Abs(_content.Pages[i].RectTransform.position.x);
                _currentPage = i;
            }
        }

        SelectCurrentPage(_duration);
    }

    private void SelectCurrentPage(float duration)
    {
        _navigation.EnablePointCurrentPage(_currentPage);

        _content.RectTransform
            .DOLocalMove(
                new Vector3(-_content.Pages[_currentPage].RectTransform.localPosition.x + (_content.Pages[_currentPage].RectTransform.sizeDelta.x + _content.HorLayoutGroup.spacing) / 2,
                0f,
                0f),
                duration)
            .SetLink(gameObject);
    }
}
