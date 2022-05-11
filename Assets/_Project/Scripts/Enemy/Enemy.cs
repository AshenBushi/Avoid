using DG.Tweening;
using UnityEngine;

public enum EnemyMovementType
{
    Default,
    Lightning,
    Angles,
    Spiral
}

public enum EnemyMovementSide
{
    Top,
    Bottom,
    Left,
    Right,
}

public class Enemy : Item
{
    [SerializeField] private EnemyMovementType _movementType;
    [SerializeField] private EnemyMovementHelper _movementHelperTemplate;
    [SerializeField] private float _movementDuration = 3f;
    [SerializeField] private float _rotationRadiusSpiral = 150f;

    private EnemyMovementHelper _movementHelper;
    private EnemyMovementPattern _movementPattern;
    private Sequence _sequenceMove;
    private Transform _defaultParent;

    public EnemyMovementType MovementType => _movementType;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            _mover.Kill();
            gameObject.SetActive(false);
            OnEndedMoving.RemoveAllListeners();

            if (_movementPattern != null)
                _movementPattern.KillSequence();

            if (_movementHelper != null)
            {
                _transform.SetParent(_defaultParent);
                Destroy(_movementHelper.gameObject);
            }
        }
    }

    public override void EndMoving()
    {
        gameObject.SetActive(false);

        if (_movementPattern != null)
            _movementPattern.KillSequence();

        if (_movementHelper != null)
        {
            _transform.SetParent(_defaultParent);
            Destroy(_movementHelper.gameObject);
        }

        OnEndedMoving?.Invoke(this);
    }

    protected override void Move()
    {
        switch (_movementType)
        {
            case EnemyMovementType.Default:
                base.Move();
                break;
            case EnemyMovementType.Lightning:
                SetLightningMovement();
                break;
            case EnemyMovementType.Angles:
                SetAnglesMovement();
                break;
            case EnemyMovementType.Spiral:
                SetSpiralMovement();
                break;
        }
    }

    public override void SetSpeedUp()
    {
        if (_movementPattern != null)
            _movementPattern.SetSequenceTimeScale(1.5f);

        base.SetSpeedUp();
    }

    public override void SetSpeedDown()
    {
        if (_movementPattern != null)
            _movementPattern.SetSequenceTimeScale(0.75f);

        base.SetSpeedDown();
    }

    private Vector3 GetPositionBySide(EnemyMovementSide side)
    {
        switch (side)
        {
            case EnemyMovementSide.Top:
                return new Vector3(-250f, 700f, 0);
            case EnemyMovementSide.Bottom:
                return new Vector3(-250f, -700f, 0);
            case EnemyMovementSide.Left:
                return new Vector3(-650f, 250f, 0);
            case EnemyMovementSide.Right:
                return new Vector3(650f, 250f, 0);
        }

        return new Vector3(-200f, -700f, 0);
    }

    private void SetLightningMovement()
    {
        _mover.Kill();
        _defaultParent = _transform.parent;

        var side = (EnemyMovementSide)Random.Range(0, 4);

        _movementHelper = Instantiate(_movementHelperTemplate, transform.parent);
        _movementHelper.transform.localPosition = GetPositionBySide(side);

        _transform.SetParent(_movementHelper.transform);
        _transform.localPosition = new Vector3(0, 0, 0);

        _sequenceMove = DOTween.Sequence();

        _movementPattern = new EnemyPatternMovementLightning(this, _movementHelper, _sequenceMove, _defaultParent, _movementDuration);

        switch (side)
        {
            case EnemyMovementSide.Top:
                _movementPattern.MovementSideTop();
                break;
            case EnemyMovementSide.Bottom:
                _movementPattern.MovementSideBottom();
                break;
            case EnemyMovementSide.Left:
                _movementPattern.MovementSideLeft();
                break;
            case EnemyMovementSide.Right:
                _movementPattern.MovementSideRight();
                break;
        }
    }

    private void SetAnglesMovement()
    {
        _mover.Kill();
        _defaultParent = _transform.parent;

        var side = (EnemyMovementSide)Random.Range(0, 4);

        _movementHelper = Instantiate(_movementHelperTemplate, transform.parent);
        _movementHelper.transform.localPosition = GetPositionBySide(side);

        _transform.SetParent(_movementHelper.transform);
        _transform.localPosition = new Vector3(0, 0, 0);

        _sequenceMove = DOTween.Sequence();

        _movementPattern = new EnemyPatternMovementAngles(this, _movementHelper, _sequenceMove, _defaultParent, _movementDuration);

        switch (side)
        {
            case EnemyMovementSide.Top:
                _movementPattern.MovementSideTop();
                break;
            case EnemyMovementSide.Bottom:
                _movementPattern.MovementSideBottom();
                break;
            case EnemyMovementSide.Left:
                _movementPattern.MovementSideLeft();
                break;
            case EnemyMovementSide.Right:
                _movementPattern.MovementSideRight();
                break;
        }
    }

    private void SetSpiralMovement()
    {
        _mover.Kill();

        _defaultParent = _transform.parent;

        var side = (EnemyMovementSide)Random.Range(0, 4);

        _movementHelper = Instantiate(_movementHelperTemplate, transform.parent);
        _movementHelper.transform.localPosition = GetPositionBySide(side);

        _transform.SetParent(_movementHelper.transform);
        _transform.localPosition = new Vector3(0, _rotationRadiusSpiral, 0);

        _movementHelper.PlayAnimation(HelperAnimationType.Rotation);

        _movementPattern = new EnemyPatternMovementSpiral(this, _movementHelper, _defaultParent, _movementDuration);

        switch (side)
        {
            case EnemyMovementSide.Top:
                _movementPattern.MovementSideTop();
                break;
            case EnemyMovementSide.Bottom:
                _movementPattern.MovementSideBottom();
                break;
            case EnemyMovementSide.Left:
                _movementPattern.MovementSideLeft();
                break;
            case EnemyMovementSide.Right:
                _movementPattern.MovementSideRight();
                break;
        }
    }
}