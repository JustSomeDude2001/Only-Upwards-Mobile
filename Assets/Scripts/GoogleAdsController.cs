using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAdsController : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    [SerializeField]private GameObject player;
    [SerializeField]private string interstitialUnitId = "ca-app-pub-3940256099942544/8691691433";
    
    /// <summary>
    /// Final token is: "ca-app-pub-4645466233864773/8590354460"
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        EnableInterstitialAd();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad >= 180)ShowInterstitialAd();

        if(player.transform.position.y <= -10)
        {
            ShowInterstitialAd();
        }
    }
    private void EnableInterstitialAd()
    {
        interstitialAd = new InterstitialAd(interstitialUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }
    public void ShowInterstitialAd() 
    {
        if (interstitialAd.IsLoaded()) {
            interstitialAd.Show();
        }
    }
}
