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

    public override void Show()
    {
        base.Show();

        _score.text = _scoreCounter.Score.ToString();

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
        
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
}
