using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private int _maxHealth;

    private PlayerMovement _playerMovement;
    private Animator _animator;

    public int Health { get; private set; }

    public event UnityAction OnTookDamage;
    public event UnityAction OnHeal;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();

        Health = _maxHealth;
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
        
        Health -= damage;
        
        _animator.Play("TakeDamage");
        
        OnTookDamage?.Invoke();

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Heal()
    {
        if (Health + 1 <= _maxHealth)
        {
            Health++;
        }
        
        _animator.Play("Heal");
        
        OnHeal?.Invoke();
    }
}
