using DG.Tweening;
using UnityEngine;

public class EnemyPatternMovementLightning : EnemyMovementPattern
{
    public EnemyPatternMovementLightning(Enemy enemy, EnemyMovementHelper helper, Sequence sequence, Transform defaultParent, float duration)
    {
        _enemy = enemy;
        _helper = helper;
        _sequence = sequence;
        _duration = duration / 3f;
        _defaultParent = defaultParent;
    }

    public override void MovementSideTop()
    {
        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, 250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-250, 50), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, -150), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-250, -350), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, -550), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject))
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideBottom()
    {
        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, -250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-250, -50), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, 150), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-250, 350), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, 550), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject))
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideLeft()
    {
        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-250, -250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-50, 250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(150, -250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(350, 250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(550, -250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject))
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideRight()
    {
        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, -250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(50, 250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-150, -250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-350, 250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-550, -250), _duration)
                    .SetEase(Ease.Linear)
                    .SetLink(_enemy.gameObject))
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }
}
