using DG.Tweening;
using UnityEngine;

public class EnemyPatternMovementSpiral : EnemyMovementPattern
{
    public EnemyPatternMovementSpiral(Enemy enemy, EnemyMovementHelper helper, Transform defaultParent, float duration)
    {
        _enemy = enemy;
        _helper = helper;
        _duration = duration;
        _defaultParent = defaultParent;
    }

    public override void MovementSideTop()
    {
        _helper.transform
                    .DOLocalMove(new Vector3(400, -650, 0), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject)
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideBottom()
    {
        _helper.transform
                    .DOLocalMove(new Vector3(400, 650, 0), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject)
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideLeft()
    {
        _helper.transform
                    .DOLocalMove(new Vector3(650, -400, 0), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject)
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideRight()
    {
        _helper.transform
                   .DOLocalMove(new Vector3(-650, -400, 0), _duration)
                   .SetEase(Ease.Linear)
                   .SetLink(_enemy.gameObject)
                   .OnComplete(() =>
                   {
                       _enemy.EndMoving();
                   });
    }
}
