using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopNavigationTab : MonoBehaviour
{
    private int _index;
    private Image _image;
    private Button _button;

    public int Index => _index;

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void Init(int index)
    {
        _index = index;

        _image = GetComponent<Image>();
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnClick);
    }

    public void Show()
    {
        _image.DOFade(1f, 0.1f).SetLink(gameObject);
    }

    public void Hide()
    {
        _image.DOFade(0.7f, 0.1f).SetLink(gameObject);
    }

    private void OnClick()
    {
        ShopNavigation.OnSelectTab?.Invoke(_index);
    }
}
