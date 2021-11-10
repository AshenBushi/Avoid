using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : UIScreen
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private HealSpawner _healSpawner;

    public void StartGame()
    {
        SoundManager.Instance.PlaySound(Sound.Button);
        
        Hide();
        
        UIManager.Instance.GameScreen.Show();

        _enemySpawner.StartGame();
        _healSpawner.StartGame();
    }
}
