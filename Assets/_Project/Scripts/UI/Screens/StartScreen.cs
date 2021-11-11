using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : UIScreen
{
    public void StartGame()
    {
        SoundManager.Instance.PlaySound(Sound.Button);
        
        Hide();
        
        UIManager.Instance.GameScreen.Show();

        SpawnersManager.Instance.StartSpawning();
    }
}
