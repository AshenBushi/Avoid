using DG.Tweening;
using UnityEngine;

public class EnemyPatternMovementLightning : EnemyMovementPattern
{
    public EnemyPatternMovementLightning(Enemy enemy, EnemyMovementHelper helper, Sequence sequence, Transform defaultParent, float duration)
    {
        _enemy = enemy;
        _helper = helper;
        _sequence = sequence;
        _duration = duration;
        _defaultParent = defaultParent;
    }

    public override void MovementSideTop()
    {
        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, 150), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-250, 50), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, -150), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-250, -650), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject))
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideBottom()
    {
        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, -150), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-250, 50), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(250, 150), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-250, 650), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject))
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideLeft()
    {
        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-150, -150), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(0, 250), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(150, -150), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(550, 250), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject))
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideRight()
    {
        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(150, -150), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(0, 250), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-150, -150), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMove(new Vector3(-550, 250), _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject))
                    .OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }
}
