using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : UIScreen
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _bestScore;

    private void OnAdClosed(object sender, EventArgs e)
    {
        Debug.Log("Worked");
        
        AdManager.Instance.Interstitial.OnAdClosed -= OnAdClosed;
        SceneManager.LoadScene(0);
    }
    
    public override void Show()
    {
        base.Show();

        _score.text = _scoreCounter.Score.ToString();

        SavingSystem.Instance.Data.DeathCount++;
        
        if (SavingSystem.Instance.Data.BestScore < _scoreCounter.Score)
        {
            SavingSystem.Instance.Data.BestScore = _scoreCounter.Score;
            SavingSystem.Instance.Save();
        }

        _bestScore.text = SavingSystem.Instance.Data.BestScore.ToString();
    }

    public void RestartGame()
    {
        SoundManager.Instance.PlaySound(Sound.Button);

        if(AdManager.Instance.ShowInterstitial())
        {
            AdManager.Instance.Interstitial.OnAdClosed += OnAdClosed;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
