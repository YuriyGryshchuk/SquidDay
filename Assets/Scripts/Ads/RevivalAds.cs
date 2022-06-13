using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class RevivalAds: MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    [SerializeField] AdsCore _adsCore;

    [SerializeField] private RestartSystem _restartSystem;   
    
    private string _id = "4792732";

    private string _adsMode = "Rewarded_Android";

    private void Start()
    {
        AdsLoad();
    }
    public void AdsShow()
    {
       ShowAds(_adsMode);
    }
    public void AdsLoad()
    {
        Advertisement.Load(_adsMode, this);
    }
    public void ShowAds(string adsMode)
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Show(adsMode, this);
        }
        else
        {
            Debug.Log("No!");
        }
    }
  
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
      
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        _restartSystem.Revival();
        Debug.Log('s');
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
