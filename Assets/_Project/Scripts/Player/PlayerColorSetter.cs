using UnityEngine;
using UnityEngine.UI;

public class PlayerColorSetter : MonoBehaviour
{
    private Image _image;

    private Color PlayerColor => ColorManager.Instance.PlayerColor;

    private void Awake()
    {
        if (TryGetComponent(out Image image))
            _image = image;
    }

    private void OnDisable()
    {
        ColorManager.Instance.OnUIColorChanged -= OnColorChanged;
    }

    private void Start()
    {
        ColorManager.Instance.OnUIColorChanged += OnColorChanged;
        OnColorChanged();
    }

    private void OnColorChanged()
    {
        if (_image != null)
            _image.color = PlayerColor;
    }
}
