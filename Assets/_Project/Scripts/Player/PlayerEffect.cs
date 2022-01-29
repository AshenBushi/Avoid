using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private TypeEffect _type;
    private Player _player;
    private Animator _animator;
    private BonusInvulnerable _bonusInvulnerable;

    public TypeEffect Type => _type;

    private void Awake()
    {
        if (_type == TypeEffect.invulnerable)
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
