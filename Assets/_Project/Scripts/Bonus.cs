using DG.Tweening;
using UnityEngine;

public abstract class Bonus : Shot
{
    protected Player _player;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Player player)) return;

        _player = player;

        //SoundManager.Instance.PlaySound(Sound.Heal);

        UsingEffect();
        Mover.Kill();
        gameObject.SetActive(false);
    }

    protected abstract void UsingEffect();
}