using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public abstract class Item : MonoBehaviour
{
    protected RectTransform _transform;
    protected Vector3 _startPosition;
    protected Vector3 _endPosition;
    protected float _moveDuration;
    protected int _damage;

    protected Tween _mover;

    [HideInInspector] public UnityEvent<Item> OnEndedMoving = new UnityEvent<Item>();

    protected virtual void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    public virtual void Init(Vector3 startPosition, Vector3 endPosition, float moveDuration)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;
        _moveDuration = moveDuration;

        gameObject.SetActive(true);

        Move();
    }

    public virtual void SetSpeedUp()
    {
        if (_mover != null)
            _mover.timeScale = 1.5f;
    }

    public virtual void SetSpeedDown()
    {
        if (_mover != null)
            _mover.timeScale = 0.8f;
    }

    public virtual void SetDamageDone(int damage)
    {
        _damage = damage;
    }

    public virtual void Deactivation()
    {
        if (!gameObject.activeSelf) return;

        _mover.Kill();
        EndMoving();
        gameObject.SetActive(false);
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);

    protected virtual void Move()
    {
        _transform.localPosition = _startPosition;

        _mover = _transform.DOLocalMove(_endPosition, _moveDuration).SetEase(Ease.Linear).SetLink(gameObject);

        _mover.OnComplete(() =>
        {
            EndMoving();
            gameObject.SetActive(false);
        });
    }

    public virtual void EndMoving()
    {
        OnEndedMoving?.Invoke(this);
    }
}
