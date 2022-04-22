using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private BonusType _bonusType;
    [SerializeField] private float _playingTime = 0f;
    private Player _player;
    private PlayerColorSetter _playerColorSetter;
    private Image _image;

    public BonusType BonusType => _bonusType;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _player = GetComponentInParent<Player>();
        _playerColorSetter = GetComponentInParent<PlayerColorSetter>();
    }

    public void Play()
    {
        gameObject.SetActive(true);

        UIManager.Instance.GameScreen.BonusDisplay.ShowBonusIcon(_bonusType);

        switch (_bonusType)
        {
            case BonusType.InvulnerableShort:
                _player.DisallowTakingDamage();
                SoundManager.Instance.PlaySound(Sound.TakeDamage);
                break;
            case BonusType.Invulnerable:
                _player.DisallowTakingDamage();
                SoundManager.Instance.PlaySound(Sound.Heal);
                break;
            case BonusType.Freezing:
                _player.DisallowMove();
                SoundManager.Instance.PlaySound(Sound.TakeDamage);
                break;
        }

        StartCoroutine(StopEffectRoutine());
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetSprite(Sprite sprite)
    {
        if (_image == null) return;

        _image.sprite = sprite;
        _image.SetNativeSize();
    }

    private IEnumerator StopEffectRoutine()
    {
        yield return new WaitForSeconds(_playingTime);

        _player.AllowUsingBonus();

        switch (_bonusType)
        {
            case BonusType.InvulnerableShort:
                _player.AllowTakingDamage();
                break;
            case BonusType.Invulnerable:
                _player.AllowTakingDamage();
                break;
            case BonusType.Freezing:
                _player.AllowMove();
                break;
        }

        Hide();
        UIManager.Instance.GameScreen.BonusDisplay.Clear();
    }
}
