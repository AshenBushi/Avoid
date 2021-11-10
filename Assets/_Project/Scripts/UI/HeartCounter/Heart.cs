using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Heart : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void EnableHeart()
    {
        _animator.Play("Idle");
    }

    public void DisableHeart()
    {
        _animator.Play("DisableHeart");
    }
}
