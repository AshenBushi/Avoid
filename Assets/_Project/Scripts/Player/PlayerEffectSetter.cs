using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum BonusType
{
    Invulnerable,
    Freezing,
    Slowing,
    Accelerating,
    Destroying
}

public class PlayerEffectSetter : MonoBehaviour
{
    private List<PlayerEffect> _effects = new List<PlayerEffect>();

    private void Awake()
    {
        _effects.AddRange(GetComponentsInChildren<PlayerEffect>());
        
        for (var i = 0; i < _effects.Count; i++)
        {
            _effects[i].Hide();
        }
    }

    public void Play(BonusType bonusTypeAnimation)
    {
        ActivationEffect(true, bonusTypeAnimation);
    }

    public void Stop(BonusType bonusTypeAnimation)
    {
        ActivationEffect(false, bonusTypeAnimation);
    }

    private void ActivationEffect(bool isPlay, BonusType bonusType)
    {
        foreach (var effect in _effects.Where(effect => effect.BonusType == bonusType))
        {
            if (isPlay)
                effect.Show();
            else
                effect.Hide();
            break;
        }
    }
}