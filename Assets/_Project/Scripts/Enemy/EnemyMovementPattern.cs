using DG.Tweening;
using UnityEngine;

public abstract class EnemyMovementPattern
{
    protected Enemy _enemy;
    protected EnemyMovementHelper _helper;
    protected Sequence _sequence;
    protected Transform _defaultParent;
    protected float _duration;

    public void SetSequenceTimeScale(float timeScale)
    {
        if (_sequence == null || timeScale <= 0)
            return;

        _sequence.timeScale = timeScale;
    }

    public void KillSequence()
    {
        if (_sequence == null)
            return;

        _sequence.Kill();
        _sequence = null;
    }

    public abstract void MovementSideTop();

    public abstract void MovementSideBottom();

    public abstract void MovementSideLeft();

    public abstract void MovementSideRight();
}
