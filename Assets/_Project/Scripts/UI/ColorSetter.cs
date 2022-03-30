using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetter : MonoBehaviour
{
    private Image _image;
    private TMP_Text _text;
    private ParticleSystem _particleSystem;

    private Color UIColor => ColorManager.Instance.UIColor;

    private void Awake()
    {
        if (TryGetComponent(out Image image))
            _image = image;

        if (TryGetComponent(out TMP_Text text))
            _text = text;

        if (TryGetComponent(out ParticleSystem particle))
            _particleSystem = particle;
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

    public void SetColorImage(Color color)
    {
        if (_image != null)
            _image.color = color;
    }

    public void SetDefaultColorImage()
    {
        if (_image != null)
            _image.color = UIColor;
    }

    private void OnColorChanged()
    {
        if (_image != null)
            _image.color = UIColor;

        if (_text != null)
            _text.color = UIColor;

        if (_particleSystem != null)
        {
            var color = UIColor;
            color.a = 0.3f;

            _particleSystem.startColor = color;
            _particleSystem.Play();
        }
    }
}
