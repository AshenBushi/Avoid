using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SoundSwitcher : MonoBehaviour
{
    [SerializeField] private Color _disabled;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        ColorManager.Instance.OnColorChanged += OnColorChanged;
        _image.color = SoundManager.Instance.VolumeState ? ColorManager.Instance.GameColor : _disabled;
    }

    private void OnDisable()
    {
        ColorManager.Instance.OnColorChanged -= OnColorChanged;
    }

    public void SwitchSound()
    {
        _image.color = SoundManager.Instance.SwitchVolume() ? ColorManager.Instance.GameColor : _disabled;
    }

    private void OnColorChanged()
    {
        if (SavingSystem.Instance.Data.VolumeState)
            _image.color = ColorManager.Instance.GameColor;
    }
}
