using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public abstract class Item : MonoBehaviour
{
    private RectTransform _transform;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _moveDuration;
    private float _moverTimeScaleDefault;
    protected int _damage;

    protected Tween Mover;

    public event UnityAction<Item> OnMovingEnd;

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
        Mover.timeScale = _moverTimeScaleDefault;
        Mover.timeScale *= 1.4f;
    }

    public virtual void SetSpeedDown()
    {
        Mover.timeScale = _moverTimeScaleDefault;
        Mover.timeScale /= 1.5f;
    }

    public virtual void SetDamageDone(int damage)
    {
        _damage = damage;
    }

    public virtual void Deactivation()
    {
        if (!gameObject.activeSelf) return;

        Mover.Kill();
        MovingEnd();
        gameObject.SetActive(false);
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);

    protected virtual void Move()
    {
        _transform.localPosition = _startPosition;

        Mover = _transform.DOLocalMove(_endPosition, _moveDuration).SetEase(Ease.Linear).SetLink(gameObject);
        _moverTimeScaleDefault = Mover.timeScale;

        Mover.OnComplete(() =>
        {
            MovingEnd();

            gameObject.SetActive(false);
        });
    }

    protected virtual void MovingEnd()
    {
        OnMovingEnd?.Invoke(this);
    }
}
