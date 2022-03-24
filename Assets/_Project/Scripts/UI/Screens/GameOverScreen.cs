using Firebase.Analytics;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : UIScreen
{
    [SerializeField] private Player _player;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Button _continueButton;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _bestScore;

    private bool _isGameContinue = false;

    private void OnAdClosedInterstitial(object sender, EventArgs e)
    {
        Debug.Log("Interstitial Worked");

        AdManager.Instance.Interstitial.OnAdClosed -= OnAdClosedInterstitial;
        SceneManager.LoadScene(0);
    }

    private void OnAdClosedRewarded(object sender, EventArgs e)
    {
        Debug.Log("Rewarded Worked");

        AdManager.Instance.RewardedAd.OnAdClosed -= OnAdClosedRewarded;

        Disable();
    }

    public override void Enable()
    {
        base.Enable();

        if (_isGameContinue)
            _continueButton.gameObject.SetActive(false);

        _score.text = _scoreCounter.Score.ToString();

        SavingSystem.Instance.Data.DeathCount++;

        if (SavingSystem.Instance.Data.BestScore < _scoreCounter.Score)
        {
            SavingSystem.Instance.Data.BestScore = _scoreCounter.Score;
            SavingSystem.Instance.Save();
        }

        _bestScore.text = SavingSystem.Instance.Data.BestScore.ToString();

        FirebaseAnalytics.LogEvent("session_end_(" + _score + ")");
    }

    public override void Disable()
    {
        base.Disable();

        UIManager.Instance.GameScreen.Enable();
        SpawnersManager.Instance.StartSpawning();

        _player.MaxHeal();
    }

    public void RestartGame()
    {
        SoundManager.Instance.PlaySound(Sound.Button);

        if (AdManager.Instance.ShowInterstitial())
        {
            AdManager.Instance.Interstitial.OnAdClosed += OnAdClosedInterstitial;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ContinueGame()
    {
        if (_isGameContinue) return;

        AdManager.Instance.RewardedAd.OnAdClosed += OnAdClosedRewarded;
        AdManager.Instance.ShowRewardVideo();
        _isGameContinue = true;

        FirebaseAnalytics.LogEvent("ad_continue");
    }
}
