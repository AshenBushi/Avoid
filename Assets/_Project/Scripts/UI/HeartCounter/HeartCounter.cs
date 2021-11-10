using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _template;
    
    private List<Heart> _hearts = new List<Heart>();
    private int _currentHeart;
    
    public void Init()
    {
        if (_hearts.Count > 0)
        {
            foreach (var heart in _hearts)
            {
                Destroy(heart.gameObject);
            }
            
            _hearts.Clear();
        }

        for (var i = 0; i < _player.Health; i++)
        {
            _hearts.Add(Instantiate(_template, transform));
        }

        _currentHeart = _hearts.Count - 1;
    }

    private void Start()
    {
        Init();
    }
    
    private void OnEnable()
    {
        _player.OnTookDamage += OnTookDamage;
        _player.OnHeal += OnHeal;
    }

    private void OnDisable()
    {
        _player.OnTookDamage -= OnTookDamage;
        _player.OnHeal += OnHeal;
    }

    private void OnTookDamage()
    {
        _hearts[_currentHeart].DisableHeart();

        _currentHeart--;
    }
    
    private void OnHeal()
    {
        if(_currentHeart + 1 >= 5) return;
        
        _currentHeart++;
        
        _hearts[_currentHeart].EnableHeart();
    }
}
