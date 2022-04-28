using GoogleMobileAds.Api;
using System;
using System.Collections;
using UnityEngine;

public class AdManager : Singleton<AdManager>
{
    [SerializeField] private float _delayBetweenInterstitial;

    private bool _isInterstitialShowed = false;

    public InterstitialAd Interstitial { get; private set; }
    public RewardedAd RewardedAd { get; private set; }

    protected override void Awake()
    {
        MakeGlobal();

        MobileAds.Initialize(initStatus => { });

        InitializeRewarded();
        InitializeInterstitial();
    }

    private void InitializeRewarded()
    {
#if UNITY_ANDROID
        const string rewardId = "ca-app-pub-4685532349433637/8313231959";
#elif UNITY_IPHONE
        const string rewardId = "";
#else
        const string rewardId = "unexpected_platform";
#endif

        var request = new AdRequest.Builder().Build();

        RewardedAd = new RewardedAd(rewardId);
        RewardedAd.OnAdClosed += OnRewardedClosed;
        RewardedAd.LoadAd(request);
    }

    private void InitializeInterstitial()
    {
#if UNITY_ANDROID
        const string interstitialId = "ca-app-pub-4685532349433637/4948702013";
#elif UNITY_IPHONE
        const string interstitialId = "";
#else
        const string interstitialId = "unexpected_platform";
#endif

        var request = new AdRequest.Builder().Build();

        Interstitial = new InterstitialAd(interstitialId);
        Interstitial.OnAdFailedToShow += HandleOnAdFailedToShow;
        Interstitial.OnAdClosed += OnInterstitialClosed;
        Interstitial.LoadAd(request);
    }

    private void HandleOnAdFailedToShow(object sender, AdErrorEventArgs e)
    {
        InitializeInterstitial();
    }

    private void OnInterstitialClosed(object sender, EventArgs e)
    {
        Debug.Log("Work");
        InitializeInterstitial();
        StartCoroutine(ReloadInterstitial());
    }

    private void OnRewardedClosed(object sender, EventArgs e)
    {
        Debug.Log("Work");
        InitializeRewarded();
    }

    private IEnumerator ReloadInterstitial()
    {
        _isInterstitialShowed = true;

        yield return new WaitForSeconds(_delayBetweenInterstitial);

        _isInterstitialShowed = false;
    }

    public bool ShowInterstitial()
    {
        if (!Interstitial.IsLoaded() || _isInterstitialShowed || SavingSystem.Instance.Data.DeathCount < 10) return false;

        Interstitial.Show();

        return true;
    }

    public bool ShowRewardVideo()
    {
        if (!RewardedAd.IsLoaded()) return false;

        RewardedAd.Show();

        return true;
    }
}
