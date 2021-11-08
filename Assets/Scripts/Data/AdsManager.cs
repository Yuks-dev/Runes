using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class AdsManager : Element
{
    public Text message;
    public int chooseRune = -1;

    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;
    private string interstitialAd_ID = "ca-app-pub-3940256099942544/1033173712";
    private string rewardedAd_ID = "ca-app-pub-3940256099942544/5224354917";

    void Start()
    {
        MobileAds.Initialize((initStatus) => { });
        RequestInterstitial();
    }

    public void RequestInterstitial()
    {
        this.interstitialAd = new InterstitialAd(interstitialAd_ID);

        this.interstitialAd.OnAdClosed += HandleOnAdClosed;
        this.interstitialAd.OnAdLoaded += HandleOnAdLoaded;
        this.interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        this.interstitialAd.OnAdOpening += HandleOnAdOpened;

        AdRequest adRequest = new AdRequest.Builder().Build();
        this.interstitialAd.LoadAd(adRequest);
    }

    public void RequestRewarded()
    {
        this.rewardedAd = new RewardedAd(rewardedAd_ID);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleOnAdClosed;
        this.rewardedAd.OnAdLoaded += HandleOnAdLoaded;
        this.rewardedAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        this.rewardedAd.OnAdOpening += HandleOnAdOpened;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }

    public void HandleUserEarnedReward(object sender, Reward reward)
    {
        string type = reward.Type;
        int amount = (int)reward.Amount;
        app.model.availableRunes[chooseRune] += 1;
        app.model.SaveData();
    }

    public void ShowInterstitialAD()
    {
        if (this.interstitialAd.IsLoaded())
            this.interstitialAd.Show();
    }

    public void ShowRewardedAD()
    {
        if (this.rewardedAd != null)
            this.rewardedAd.Show();
    }

    public void ClearAds()
    {
        if (this.interstitialAd != null)
            this.interstitialAd.Destroy();
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        message.text = "Ad Loaded";
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        message.text = "Ad Closed";
        app.aux.Mute(false);
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        message.text = "Ad Failed To Load" + args.LoadAdError;
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        message.text = "Ad Opened";
        app.aux.Mute(true);
    }
}
