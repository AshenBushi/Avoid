using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    public StartScreen StartScreen => _startScreen;
    public GameScreen GameScreen => _gameScreen;
    public GameOverScreen GameOverScreen => _gameOverScreen;
}
