using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerColorSetter : MonoBehaviour
{
    private Image _image;
    private bool _isPlayerComponent = false;
    private bool _isOutlineCurrentColor = false;

    private Color PlayerColor => ColorManager.Instance.PlayerColor;
    public Image Image => _image;

    public static event UnityAction OnImageColorChangedEvent;

    private void Awake()
    {
        if (TryGetComponent(out Image image))
            _image = image;

        if (GetComponentInParent<Player>())
            _isPlayerComponent = true;

        if (GetComponent<ShopOutlineCurrentColor>())
            _isOutlineCurrentColor = true;
    }

    private void OnDisable()
    {
        ColorManager.Instance.OnPlayerColorChanged -= OnColorChanged;
        ColorManager.Instance.OnPlayerSkinChange -= OnPlayerSkinChange;
    }

    private void Start()
    {
        ColorManager.Instance.OnPlayerColorChanged += OnColorChanged;
        ColorManager.Instance.OnPlayerSkinChange += OnPlayerSkinChange;
        OnColorChanged();
    }

    private void OnColorChanged()
    {
        if (_image != null)
            _image.color = PlayerColor;

        if (!_isPlayerComponent)
        {
            if (_isOutlineCurrentColor)
            {
                _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1f);
                return;
            }

            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0.4f);
            OnImageColorChangedEvent?.Invoke();
            return;
        }

        _image.material.color = PlayerColor;
    }

    private void OnPlayerSkinChange(Sprite sprite)
    {
        if (!_isPlayerComponent) return;

        if (_image == null) return;

        _image.sprite = sprite;
        _image.material.color = PlayerColor;
        _image.SetNativeSize();
    }
}