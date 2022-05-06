using DG.Tweening;
using UnityEngine;

public enum EnemyMovementType
{
    Default,
    Lightning,
    Degrees90,
    Spiral
}

public class Enemy : Item
{
    [SerializeField] private EnemyMovementType _movementType;
    [SerializeField] private EnemyMovementHelper _movementHelperTemplate;
    [SerializeField] private float _movementDuration = 3f;
    [SerializeField] private float _rotationRadiusSpiral = 150f;

    private EnemyMovementHelper _movementHelper;
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

            if (_sequenceMove != null)
            {
                _sequenceMove.Kill();
                _sequenceMove = null;
            }

            if (_movementHelper != null)
            {
                _transform.SetParent(_defaultParent);
                Destroy(_movementHelper.gameObject);
            }
        }
    }

    public override void EndMoving()
    {
        if (_sequenceMove != null)
        {
            _sequenceMove.Kill();
            _sequenceMove = null;
        }

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
                LightningMovement();
                break;
            case EnemyMovementType.Degrees90:
                Degrees90Movement();
                break;
            case EnemyMovementType.Spiral:
                SpiralMovement();
                break;
        }
    }

    private void LightningMovement()
    {
        _mover.Kill();
        _defaultParent = _transform.parent;
        var fastDuration = _movementDuration / 4f;

        _movementHelper = Instantiate(_movementHelperTemplate, transform.parent);
        _movementHelper.transform.localPosition = new Vector3(-200f, -700f, 0);

        _transform.SetParent(_movementHelper.transform);

        _transform.localPosition = new Vector3(0, 0, 0);

        _sequenceMove = DOTween.Sequence();

        _sequenceMove.Append(_movementHelper.transform
                    .DOLocalMove(new Vector3(250, 70), fastDuration)
                    .SetEase(Ease.OutQuart)
                    .SetLink(gameObject));

        _sequenceMove.Append(_movementHelper.transform
                    .DOLocalMove(new Vector3(-250, 150), fastDuration / 2f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(gameObject));

        _sequenceMove.Append(_movementHelper.transform
                    .DOLocalMove(new Vector3(250, 250), fastDuration / 2f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(gameObject));

        _sequenceMove.Append(_movementHelper.transform
                    .DOLocalMove(new Vector3(-250, 650), fastDuration / 2f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(gameObject))
                    .OnComplete(() =>
                    {
                        _transform.SetParent(_defaultParent);
                        EndMoving();
                        gameObject.SetActive(false);
                    });
    }

    private void Degrees90Movement()
    {
        _mover.Kill();
        _defaultParent = _transform.parent;
        var fastDuration = _movementDuration / 4f;

        _movementHelper = Instantiate(_movementHelperTemplate, transform.parent);
        _movementHelper.transform.localPosition = new Vector3(-200f, -700f, 0);

        _transform.SetParent(_movementHelper.transform);
        _transform.localPosition = new Vector3(0, 0, 0);

        _sequenceMove = DOTween.Sequence();

        _sequenceMove.Append(_movementHelper.transform
                    .DOLocalMoveY(50, fastDuration)
                    .SetEase(Ease.OutQuart)
                    .SetLink(gameObject));

        _sequenceMove.Append(_movementHelper.transform
                    .DOLocalMoveX(250, fastDuration / 2f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(gameObject));

        _sequenceMove.Append(_movementHelper.transform
                    .DOLocalMoveY(300, fastDuration / 2f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(gameObject));

        _sequenceMove.Append(_movementHelper.transform
                    .DOLocalMoveX(-250, fastDuration / 2f)
                    .SetEase(Ease.OutQuart)
                    .SetLink(gameObject));

        _sequenceMove.Append(_movementHelper.transform
                    .DOLocalMoveY(650, fastDuration)
                    .SetEase(Ease.OutQuart)
                    .SetLink(gameObject)).OnComplete(() =>
                    {
                        _transform.SetParent(_defaultParent);
                        EndMoving();
                        gameObject.SetActive(false);
                    });
    }

    private void SpiralMovement()
    {
        _mover.Kill();

        _defaultParent = _transform.parent;

        _movementHelper = Instantiate(_movementHelperTemplate, transform.parent);
        _movementHelper.transform.localPosition = new Vector3(0, -600f, 0);

        _transform.SetParent(_movementHelper.transform);
        _transform.localPosition = new Vector3(0, _rotationRadiusSpiral, 0);

        _movementHelper.PlayAnimation(HelperAnimationType.Rotation);

        _movementHelper.transform
                    .DOLocalMoveY(650, _movementDuration)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject)
                    .OnComplete(() =>
                    {
                        _transform.SetParent(_defaultParent);
                        EndMoving();
                        gameObject.SetActive(false);
                    });
    }
}