using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bonus : Item
{
    protected Player _player;

    protected override void OnTriggerEnter2D(Collider2D other)
    {

    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Player player)) return;
        if (player.IsUsingBonus) return;

        _player = player;

        //SoundManager.Instance.PlaySound(Sound.Heal);

        UseBonus();
        Mover.Kill();
        gameObject.SetActive(false);
    }

    protected abstract void UseBonus();
}