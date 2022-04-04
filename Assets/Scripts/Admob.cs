using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Admob : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private bool _testMode = true;
    private string _gameId;
    [SerializeField] private string _androidGameId;
    [SerializeField] private string _iOSGameId;

    private string _video = "Interstitial Android";

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;

        Advertisement.Initialize(_gameId, _testMode);
    }

    private void Awake()
    {
        InitializeAds();
    }

    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
