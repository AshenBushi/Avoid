using UnityEngine;
using UnityEngine.UI;

public class PlayerColorSetter : MonoBehaviour
{
    private Image _image;
    private bool _isPlayer = false;
    private Color PlayerColor => ColorManager.Instance.PlayerColor;

    private void Awake()
    {
        if (TryGetComponent(out Image image))
            _image = image;

        _isPlayer = TryGetComponent(out Player player);
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
    }

    private void OnPlayerSkinChange(Sprite sprite)
    {
        if (!_isPlayer) return;

        if (_image != null)
            _image.sprite = sprite;
    }
}