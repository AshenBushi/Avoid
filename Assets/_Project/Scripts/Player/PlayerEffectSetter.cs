using System.Collections.Generic;
using UnityEngine;

public enum TypeEffect
{
    invulnerable,
    freezing,
    slowing,
    accelerating,
    destroying
}

public class PlayerEffectSetter : MonoBehaviour
{
    private List<PlayerEffect> _effects = new List<PlayerEffect>();

    private void Awake()
    {
        _effects.AddRange(GetComponentsInChildren<PlayerEffect>());
        for (int i = 0; i < _effects.Count; i++)
        {
            _effects[i].Hide();
        }
    }

    public void Play(TypeEffect typeAnimation)
    {
        ActivationEffect(true, typeAnimation);
    }

    public void Stop(TypeEffect typeAnimation)
    {
        ActivationEffect(false, typeAnimation);
    }

    private void ActivationEffect(bool isPlay, TypeEffect type)
    {
        for (int i = 0; i < _effects.Count; i++)
        {
            if (_effects[i].Type == type)
            {
                if (isPlay)
                    _effects[i].Show();
                else
                    _effects[i].Hide();

                break;
            }
        }
    }
}