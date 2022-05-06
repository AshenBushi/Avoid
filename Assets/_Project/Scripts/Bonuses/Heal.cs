using DG.Tweening;
using UnityEngine;

public class Heal : Bonus
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        
        SoundManager.Instance.PlaySound(Sound.Heal);
        
        player.Heal();
        _mover.Kill();
        gameObject.SetActive(false);
    }

    protected override void UseBonus()
    {
        
    }
}
