using DG.Tweening;
using UnityEngine;

public class Enemy : Shot
{
    private int _damage;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Player player)) return;

        player.TakeDamage(_damage);
        Mover.Kill();
        gameObject.SetActive(false);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    public void Die()
    {
        Mover.Kill();
        MovingEnd();
        gameObject.SetActive(false);
    }
}
