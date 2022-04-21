using UnityEngine;

public class BorderController : MonoBehaviour
{
    private ColorSetter _colorSetter;
    private bool _isDangerous = false;

    public ColorSetter ColorSetter => _colorSetter;
    public bool IsDangerous => _isDangerous;

    private void Awake()
    {
        _colorSetter = GetComponent<ColorSetter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isDangerous) return;
        if (!other.gameObject.TryGetComponent(out Player player)) return;

        player.TakeTotalDamage();
    }

    public void SetDangerous(Color color)
    {
        _isDangerous = true;
        _colorSetter.SetColorImage(color);
    }

    public void SetSafe()
    {
        _isDangerous = false;
        _colorSetter.SetDefaultColorImage();
    }
}
