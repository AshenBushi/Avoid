using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private int _health;

    private PlayerMovement _playerMovement;
    private Animator _animator;

    public int Health => _health;
    
    public event UnityAction OnTookDamage;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void Die()
    {
        UIManager.Instance.GameOverScreen.Show();
        UIManager.Instance.GameScreen.Hide();
        
        _enemySpawner.EndGame();

        Time.timeScale = 0;
    }
    
    public void TakeDamage(int damage)
    {
        SoundManager.Instance.PlaySound(Sound.TakeDamage);
        
        _health -= damage;
        
        _animator.Play("TakeDamage");
        
        OnTookDamage?.Invoke();

        if (_health <= 0)
        {
            Die();
        }
    }
}
