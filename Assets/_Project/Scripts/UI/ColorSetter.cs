using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ColorSetter : MonoBehaviour
{
    private Image _image;
    private TMP_Text _text;
    private ParticleSystem _particleSystem;

    private Color GameColor => ColorManager.Instance.GameColor;
    
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
        ColorManager.Instance.OnColorChanged -= OnColorChanged;
    }

    private void Start()
    {
        ColorManager.Instance.OnColorChanged += OnColorChanged;
        OnColorChanged();
    }

    private void OnColorChanged()
    {
        if (_image != null)
            _image.color = GameColor;

        if (_text != null)
            _text.color = GameColor;

        if (_particleSystem != null)
        {
            var color = GameColor;
            color.a = 0.3f;
            
            _particleSystem.startColor = color;
            _particleSystem.Play();
        }
    }
}
