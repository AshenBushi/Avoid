using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopButtonMoneyAD : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(WatchAd);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(WatchAd);
    }

    public void WatchAd()
    {
        AdManager.Instance.RewardedAd.OnAdClosed += OnAdClosedRewarded;
        AdManager.Instance.ShowRewardVideo();
    }

    private void OnAdClosedRewarded(object sender, EventArgs e)
    {
        Debug.Log("Rewarded Worked");
        AdManager.Instance.RewardedAd.OnAdClosed -= OnAdClosedRewarded;

        Bank.Instance.AddMoneyWithAnimation(50);
    }
}
