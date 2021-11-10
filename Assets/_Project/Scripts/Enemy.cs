using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private Tween _mover;
    private RectTransform _transform;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private int _damage;
    private float _moveDuration;

    public event UnityAction<Enemy> OnMovingEnd;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    public void Init(Vector3 startPosition, Vector3 endPosition, int damage, float moveDuration)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;
        _damage = damage;
        _moveDuration = moveDuration;

        gameObject.SetActive(true);
        
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        
        Debug.Log("Attack");
        player.TakeDamage(_damage);
        _mover.Kill();
        gameObject.SetActive(false);
    }

    private void Move()
    {
        _transform.localPosition = _startPosition;
        
        _mover = _transform.DOLocalMove(_endPosition, _moveDuration).SetEase(Ease.Linear).SetLink(gameObject);

        _mover.OnComplete(() =>
        {
            OnMovingEnd?.Invoke(this);
            
            gameObject.SetActive(false);
        });
    }
}
