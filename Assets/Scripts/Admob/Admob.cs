using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using GoogleMobileAds.Api;

public class Admob : MonoBehaviour
{

    string App_ID = "ca-app-pub-8877564504785602~7729007477";

    string Banner_AD_ID = "ca-app-pub-8877564504785602/6623330433";
    string Rewarded_AD_ID = "ca-app-pub-8877564504785602/1081028015";

    private BannerView bannerView;
    private RewardBasedVideoAd rewardBasedVideo;

    public bool rewardAdFailedToShow = false;

    void Start()
    {
        MobileAds.Initialize(App_ID);
    }

    public void RequestBanner()
    {

        this.bannerView = new BannerView(Banner_AD_ID, AdSize.Banner, AdPosition.Bottom);

        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;    
    }

    public void RequestRewardBaseVideo()
    {
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideo.LoadAd(request, Rewarded_AD_ID);
    }

     public void ShowRewardAd()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
    }

    public void ShowBannerAD()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    //FOR EVENTS AND DELEGATES FOR ADS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {

    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }






    //Reward ad event
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        rewardAdFailedToShow = true;
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }
}
