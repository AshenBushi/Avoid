using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum BonusType
{
    Invulnerable,
    Freezing,
    Slowing,
    Accelerating,
    Destroying,
    InvulnerableShort,
}

public class PlayerEffectSetter : MonoBehaviour
{
    [SerializeField] private List<PlayerEffect> _effects;

    private void Awake()
    {
        for (int i = 0; i < _effects.Count; i++)
        {
            _effects[i].Hide();
        }
    }

    private void Start()
    {
        ColorManager.Instance.OnPlayerSkinChange += SetEffectsSkins;
    }

    private void OnDisable()
    {
        ColorManager.Instance.OnPlayerSkinChange -= SetEffectsSkins;
    }

    public void Play(BonusType bonusTypeAnimation)
    {
        foreach (var effect in _effects.Where(effect => effect.BonusType == bonusTypeAnimation))
        {
            effect.Play();
            break;
        }
    }

    private void SetEffectsSkins(Sprite sprite)
    {
        for (int i = 0; i < _effects.Count; i++)
        {
            _effects[i].SetSprite(sprite);
        }
    }
}