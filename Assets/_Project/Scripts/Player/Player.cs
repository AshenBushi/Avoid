using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private PlayerMovement _playerMovement;
    private Animator _animator;
    private RectTransform _rectTransform;
    private Vector3 _standartScale;
    private bool _isCanTakingDamage = true;

    public int Health { get; private set; }

    public event UnityAction OnTookDamage;
    public event UnityAction OnHeal;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _rectTransform = GetComponent<RectTransform>();
        _standartScale = _rectTransform.localScale;

        Health = _maxHealth;
    }

    private void Die()
    {
        UIManager.Instance.GameOverScreen.Show();
        UIManager.Instance.GameScreen.Hide();

        SpawnersManager.Instance.EndSpawning();
    }

    public void AllowTakingDamage()
    {
        _isCanTakingDamage = true;
    }

    public void DisallowTakingDamage()
    {
        _isCanTakingDamage = false;
    }

    public void AllowMove()
    {
        _playerMovement.AllowMove();
    }

    public void DisallowMove()
    {
        _playerMovement.DisallowMove();
    }

    public void TakeDamage(int damage)
    {
        if (!_isCanTakingDamage) return;

        SoundManager.Instance.PlaySound(Sound.TakeDamage);

        VibrationManager.Instance.PlayVibration();

        Health -= damage;
        ReduceSize();

        _animator.Play("TakeDamage");

        OnTookDamage?.Invoke();

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Heal()
    {
        if (Health + 1 <= _maxHealth)
        {
            Health++;
            IncreaseSize();
        }

        OnHeal?.Invoke();
    }

    public void MaxHeal()
    {
        for (int i = 0; i < _maxHealth; i++)
        {
            Heal();
        }
    }

    private void ReduceSize()
    {
        var scale = _rectTransform.localScale;

        if (scale.x > 0.6f && scale.y > 0.6f)
        {
            scale = new Vector3(scale.x - 0.2f, scale.y - 0.2f);

            _rectTransform.DOScale(scale, 0.4f).SetLink(gameObject);
        }
    }

    private void IncreaseSize()
    {
        var scale = _rectTransform.localScale;

        if (scale.x < _standartScale.x && scale.y < _standartScale.y)
            scale = new Vector3(scale.x + 0.2f, scale.y + 0.2f);

        _rectTransform.DOScale(scale, 0.3f).SetLink(gameObject);
    }
}
