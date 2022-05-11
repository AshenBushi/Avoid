using DG.Tweening;
using UnityEngine;

public class EnemyPatternMovementAngles : EnemyMovementPattern
{
    public EnemyPatternMovementAngles(Enemy enemy, EnemyMovementHelper helper, Sequence sequence, Transform defaultParent, float duration)
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
                    .DOLocalMoveY(250, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveX(250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveY(50, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveX(-250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveY(-100, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveX(250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveY(-600, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject)).OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideBottom()
    {
        _sequence.Append(_helper.transform
                    .DOLocalMoveY(-100, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveX(250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveY(50, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveX(-250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveY(250, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveX(250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveY(600, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject)).OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideLeft()
    {
        _sequence.Append(_helper.transform
                   .DOLocalMoveX(-200, _duration / 4f)
                   .SetEase(Ease.OutQuart)
                   .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveY(-200, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveX(0, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveY(250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveX(150, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveY(-250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveX(300, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveY(250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveX(600, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject)).OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }

    public override void MovementSideRight()
    {
        _sequence.Append(_helper.transform
                  .DOLocalMoveX(200, _duration / 4f)
                  .SetEase(Ease.OutQuart)
                  .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveY(-200, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveX(0, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveY(250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveX(-150, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveY(-250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveX(-300, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));

        _sequence.Append(_helper.transform
                    .DOLocalMoveY(250, _duration / 5f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject));


        _sequence.Append(_helper.transform
                    .DOLocalMoveX(-600, _duration / 4f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(_enemy.gameObject)).OnComplete(() =>
                    {
                        _enemy.EndMoving();
                    });
    }
}
