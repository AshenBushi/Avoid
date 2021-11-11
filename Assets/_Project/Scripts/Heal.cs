using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Heal : Shot
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        
        SoundManager.Instance.PlaySound(Sound.Heal);
        
        player.Heal();
        Mover.Kill();
        gameObject.SetActive(false);
    }
}
