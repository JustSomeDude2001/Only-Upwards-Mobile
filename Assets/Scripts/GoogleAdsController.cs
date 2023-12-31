using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class GoogleAdsController : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    private float initial = 0;
    private float max = 0;
    [SerializeField]private GameObject player;
    [SerializeField]private Text text;
    [SerializeField]private string interstitialUnitId = "ca-app-pub-4645466233864773/8590354460";
    
    /// <summary>
    /// Final token is: "ca-app-pub-4645466233864773/8590354460"
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        initial = player.transform.position.y;
        EnableInterstitialAd();
        RequestConfiguration requestConfiguration = MobileAds.GetRequestConfiguration().ToBuilder()
            .SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.True).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > max) max = player.transform.position.y;
        text.text =  max.ToString("0.00");
        if(Time.timeSinceLevelLoad >= 180)ShowInterstitialAd();

        if(max- player.transform.position.y  >= 8)
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
