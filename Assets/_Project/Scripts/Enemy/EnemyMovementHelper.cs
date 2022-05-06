using UnityEngine;

public enum HelperAnimationType
{
    None,
    Rotation,
}

public class EnemyMovementHelper : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(HelperAnimationType animType)
    {
        switch (animType)
        {
            case HelperAnimationType.Rotation:
                _animator.Play("PatternRotation");
                break;
        }
    }
}
