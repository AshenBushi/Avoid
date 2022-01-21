using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public abstract class Shot : MonoBehaviour
{
    private RectTransform _transform;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _moveDuration;
    private float _moverTimeScaleDefault;

    protected Tween Mover;

    public event UnityAction<Shot> OnMovingEnd;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    public void Init(Vector3 startPosition, Vector3 endPosition, float moveDuration)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;
        _moveDuration = moveDuration;

        gameObject.SetActive(true);

        Move();
    }

    public void SetSpeedUp()
    {
        Mover.timeScale = _moverTimeScaleDefault;
        Mover.timeScale *= 1.2f;
    }

    public void SetSpeedDown()
    {
        Mover.timeScale = _moverTimeScaleDefault;
        Mover.timeScale /= 1.5f;
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);

    private void Move()
    {
        _transform.localPosition = _startPosition;

        Mover = _transform.DOLocalMove(_endPosition, _moveDuration).SetEase(Ease.Linear).SetLink(gameObject);
        _moverTimeScaleDefault = Mover.timeScale;

        Mover.OnComplete(() =>
        {
            OnMovingEnd?.Invoke(this);

            gameObject.SetActive(false);
        });
    }
}
