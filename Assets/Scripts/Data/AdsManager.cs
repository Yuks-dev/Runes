using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    private InterstitialAd interAd;
    private string InterAdID = "ca-app-pub-3940256099942544/1033173712";

    private void OnEnable()
    {
        interAd = new InterstitialAd(InterAdID);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interAd.LoadAd(adRequest);
    }

    public void ShowAd()
    {
        if (interAd.IsLoaded())
            interAd.Show();
    }

    private void Awake() => MobileAds.Initialize(initStatus => { });
}
