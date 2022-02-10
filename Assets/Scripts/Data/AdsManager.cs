using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class AdsManager : Element
{
    public int chooseRune = -1;
    public bool rewardedLoad = false;

    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    //private string interstitialAd_ID = "ca-app-pub-3940256099942544/1033173712"; // Test ID
    //private string rewardedAd_ID = "ca-app-pub-3940256099942544/5224354917"; // Test ID
    private string interstitialAd_ID = "ca-app-pub-2508878903610572/5676849079";
    private string rewardedAd_ID = "ca-app-pub-2508878903610572/7536725650";

    private void Start()
    {
        MobileAds.Initialize((initStatus) =>
        {
            RequestInterstitial();
        });
    }

    public void RequestInterstitial()
    {
        if (this.interstitialAd != null)
            this.interstitialAd.Destroy();

        this.interstitialAd = new InterstitialAd(interstitialAd_ID);

        this.interstitialAd.OnAdClosed += InterstitialAdClosed;
        this.interstitialAd.OnAdLoaded += InterstitialAdLoaded;
        this.interstitialAd.OnAdFailedToLoad += InterstitialAdFailedToLoad;
        this.interstitialAd.OnAdOpening += InterstitialAdOpened;

        AdRequest adRequest = new AdRequest.Builder().Build();
        this.interstitialAd.LoadAd(adRequest);
    }

    public void RequestRewarded()
    {
        this.rewardedAd = new RewardedAd(rewardedAd_ID);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += RewardedAdClosed;
        this.rewardedAd.OnAdLoaded += RewardedAdLoaded;
        this.rewardedAd.OnAdFailedToLoad += RewardedAdFailedToLoad;
        this.rewardedAd.OnAdOpening += RewardedAdOpened;
        rewardedAd.OnAdFailedToShow += RewardedFaildeToShow;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }

    public void ShowInterstitialAD()
    {
        if (this.interstitialAd.IsLoaded())
            this.interstitialAd.Show();
    }

    public void ShowRewardedAD()
    {
        if (rewardedAd.IsLoaded() || rewardedAd != null)
            rewardedAd.Show();
    }

    public void ClearInterstitial()
    {
        if (this.interstitialAd != null)
            this.interstitialAd.Destroy();
    }


    // Events ADS Rewarded

    private void HandleUserEarnedReward(object sender, Reward reward)
    {
        string type = reward.Type;
        int amount = (int)reward.Amount;
        app.model.availableRunes[chooseRune] += 1;
        app.model.SaveData();
    }

    private void RewardedAdLoaded(object sender, EventArgs args)
    {
        rewardedLoad = true;
    }

    private void RewardedAdClosed(object sender, EventArgs args)
    {
        app.aux.Mute(false);
        RequestRewarded();
    }

    private void RewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        rewardedLoad = false;
    }

    private void RewardedFaildeToShow(object sender, EventArgs args)
    {

    }

    private void RewardedAdOpened(object sender, EventArgs args)
    {
        app.aux.Mute(true);
    }


    // Events ADS Interstitial

    private void InterstitialAdLoaded(object sender, EventArgs args)
    {

    }

    private void InterstitialAdClosed(object sender, EventArgs args)
    {
        app.aux.Mute(false);
    }

    private void InterstitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    private void InterstitialAdOpened(object sender, EventArgs args)
    {
        app.aux.Mute(true);
    }
}
