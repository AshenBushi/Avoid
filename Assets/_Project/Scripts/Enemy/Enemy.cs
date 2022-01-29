using DG.Tweening;
using UnityEngine;

public class Enemy : Item
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Player player)) return;

        player.TakeDamage(_damage);
        Mover.Kill();
        gameObject.SetActive(false);
    }
}
