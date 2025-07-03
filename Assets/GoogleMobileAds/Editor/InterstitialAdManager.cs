using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialAdManager : MonoBehaviour
{
    // 전면 광고
    private InterstitialAd interstitialAd;

    // 리워드 광고
    private RewardedAd rewardedAd;

    // 전면 보상 광고
    private RewardedInterstitialAd interstitialAds;

    // 테스트용 전면 광고 ID
    private string adUnitId = "ca-app-pub-3940256099942544/1033173712"; 


    public Button showAdButton;

    void Start()
    {
        // Google Mobile Ads SDK 초기화
        MobileAds.Initialize(initStatus => 
        {
            Debug.Log("AdMob 초기화 완료: " + initStatus);

            // 초기화 후 광고 로드
            LoadInterstitialAd();
        });

        if (showAdButton != null)
        {
            showAdButton.onClick.AddListener(ShowInterstitialAd);
        }
    }

    // 전면 광고 로드 메서드
    public void LoadInterstitialAd()
    {
        // 광고 단위 ID (Android용 테스트 광고 ID)
        adUnitId = "ca-app-pub-3940256099942544/1033173712";

        // 전면 광고 요청
        AdRequest adRequest = new AdRequest();

        // 전면 광고 로드
        InterstitialAd.Load(adUnitId, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("광고 로드 실패: " + error);
                return;
            }

            Debug.Log("광고 로드 성공!");
            interstitialAd = ad;

            // 리워드 보상 처리
            // RewardedAd.Load(adUnitId, adRequest, OnAdLoaded);

            // 광고 닫힘 이벤트 처리
            interstitialAd.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("광고 닫힘. \n 재로드 시도 중...");
                LoadInterstitialAd();  // 광고가 닫히면 새로 로드 시도
            };

            // 광고 실패 이벤트 처리
            interstitialAd.OnAdFullScreenContentFailed += (AdError adError) =>
            {
                Debug.LogError("광고 실행 실패: " + adError.GetMessage());
            };
        });
    }

    private void OnAdLoaded(RewardedAd ad, LoadAdError error)
    {
        if (error != null)
        {
            Debug.LogError("불러오지 못했습니다.: " + error.GetMessage());
            return;
        }

        rewardedAd = ad;

        // 리워드 보상 이벤트 등록
        rewardedAd.Show((Reward reward) =>
        {
            // 여기에 보상 처리
        });

        // -> 전면 광고 리워드 보상 등록
        // interstitialAds.OnAdFullScreenContentClosed += 보상 함수;
    }

    // 전면 광고 표시 메서드
    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();  // 광고 표시
        }
    }
}