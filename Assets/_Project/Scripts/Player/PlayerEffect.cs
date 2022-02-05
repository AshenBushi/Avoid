using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private BonusType _bonusType;
    private Player _player;
    private Animator _animator;
    private BonusInvulnerable _bonusInvulnerable;

    public BonusType BonusType => _bonusType;

    private void Awake()
    {
        if (_bonusType == BonusType.Invulnerable)
            _bonusInvulnerable = GetComponent<BonusInvulnerable>();

        _player = GetComponentInParent<Player>();
        _animator = GetComponent<Animator>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
