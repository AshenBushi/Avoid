using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    [SerializeField] private AnimationName _animation;
    [SerializeField] private float _duration;
    [SerializeField] private int _direction;
    [SerializeField] private Vector3 _shakeStrength;
    
    private Tween _tween;
    
    private void Start()
    {
        switch (_animation)
        {
            case AnimationName.Rotate:
                Rotate();
                break;
            case AnimationName.Shake:
                Shake();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Rotate()
    {
        _tween = transform.DORotate(new Vector3(0f, 0f, 360f * _direction), _duration, RotateMode.FastBeyond360);

        _tween.OnComplete(Rotate);
    }

    private void Shake()
    {
        _tween = transform.DOShakePosition(_duration, _shakeStrength, 0);
        
        _tween.OnComplete(Shake);
    }
}

public enum AnimationName
{
    Rotate,
    Shake
}