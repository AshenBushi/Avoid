using UnityEngine;

public enum TypeEffectAnimation
{
    invulnerable,
    freezing,
    slowing,
    accelerating,
    destroying
}

public class BonusEffectAnimationSetter : MonoBehaviour
{
    public void Play(Animator animator, TypeEffectAnimation typeAnimation)
    {
        animator.Play(typeAnimation switch
        {
            TypeEffectAnimation.invulnerable => "BonusInvulnerable",
            TypeEffectAnimation.freezing => "BonusFreezing",
            TypeEffectAnimation.slowing => "BonusSlowing",
            TypeEffectAnimation.accelerating => "BonusAccelerating",
            TypeEffectAnimation.destroying => "BonusDestroying",
            _ => null,
        });
    }
}