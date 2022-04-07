using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShopSectionNavigationPoint : MonoBehaviour
{
    [SerializeField] private Image _image;

    public bool IsEnable { get; private set; }

    private void Start()
    {
        ColorManager.Instance.OnUIColorChanged += OnColorChanged;
        OnColorChanged();
    }

    private void OnDisable()
    {
        ColorManager.Instance.OnUIColorChanged -= OnColorChanged;
    }

    public void Enable()
    {
        IsEnable = true;
        _image.DOFade(1f, 0.05f).SetLink(gameObject);
    }

    public void Disable()
    {
        IsEnable = false;
        _image.DOFade(0.4f, 0.05f).SetLink(gameObject);
    }

    public void OnColorChanged()
    {
        _image.color = ColorManager.Instance.UIColor;

        if (!IsEnable)
            Disable();
    }
}
