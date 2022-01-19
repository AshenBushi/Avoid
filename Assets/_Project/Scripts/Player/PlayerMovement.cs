using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _leftTopBorder;
    [SerializeField] private Vector2 _rightBottomBorder;

    private RectTransform _rectTransform;
    private bool _isCanMove = true;

    private Vector2 PlayerPosition => _rectTransform.localPosition;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void AllowMove()
    {
        _isCanMove = true;
    }

    public void DisallowMove()
    {
        _isCanMove = false;
    }

    public void Move(Vector2 delta)
    {
        if (!_isCanMove) return;

        var nextPosition = PlayerPosition + delta;

        if (nextPosition.x >= _rightBottomBorder.x || nextPosition.x <= _leftTopBorder.x ||
            nextPosition.y >= _leftTopBorder.y || nextPosition.y <= _rightBottomBorder.y) return;

        _rectTransform.localPosition = nextPosition;
    }
}
