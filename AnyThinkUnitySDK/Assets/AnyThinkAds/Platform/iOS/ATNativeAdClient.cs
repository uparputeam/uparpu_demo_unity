﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyThinkAds.Common;
using AnyThinkAds.Api;
using AnyThinkAds.iOS;
using AnyThinkAds.ThirdParty.MiniJSON;

namespace AnyThinkAds.iOS {
	public class ATNativeAdClient : IATNativeAdClient {
		private ATNativeAdListener mlistener;
		public void loadNativeAd(string placementId, string mapJson) {
            Debug.Log("Unity:ATNativeAdClient::loadNativeAd()");
            ATNativeAdWrapper.setClientForPlacementID(placementId, this);
            ATNativeAdWrapper.loadNativeAd(placementId, mapJson);
        }

		public void setLocalExtra (string placementId,string localExtra){
			
		}

        public bool hasAdReady(string placementId) {
            Debug.Log("Unity:ATNativeAdClient::hasAdReady()");
			return ATNativeAdWrapper.isNativeAdReady(placementId);
        }

        public void setListener(ATNativeAdListener listener) {
            Debug.Log("Unity:ATNativeAdClient::setListener()");
            mlistener = listener;
        }

		public void renderAdToScene(string placementId, ATNativeAdView anyThinkNativeAdView) {	
            Debug.Log("Unity:ATNativeAdClient::renderAdToScene()");
            ATNativeAdWrapper.showNativeAd(placementId, anyThinkNativeAdView.toJSON());
        }

        public void cleanAdView(string placementId, ATNativeAdView anyThinkNativeAdView) {
			Debug.Log("Unity:ATNativeAdClient::cleanAdView()");
            ATNativeAdWrapper.removeNativeAdView(placementId);
        }

        public void onApplicationForces(string placementId, ATNativeAdView anyThinkNativeAdView) {
			Debug.Log("Unity:ATNativeAdClient::onApplicationForces()");
        }

        public void onApplicationPasue(string placementId, ATNativeAdView anyThinkNativeAdView) {
			Debug.Log("Unity:ATNativeAdClient::onApplicationPasue()");
        }

        public void cleanCache(string placementId) {
			Debug.Log("Unity:ATNativeAdClient::cleanCache()");
            ATNativeAdWrapper.clearCache();
        }

        //Callbacks
        public void onAdImpressed(string placementId, string callbackJson) {
            Debug.Log("Unity:ATNativeAdClient::onAdImpressed...unity3d.");
            if(mlistener != null) mlistener.onAdImpressed(placementId, new ATCallbackInfo(callbackJson));
        }

        public void onAdClicked(string placementId, string callbackJson) {
            Debug.Log("Unity:ATNativeAdClient::onAdClicked...unity3d.");
            if (mlistener != null) mlistener.onAdClicked(placementId, new ATCallbackInfo(callbackJson));
        }

        public void onAdCloseButtonClicked(string placementId, string callbackJson)
        {
            Debug.Log("Unity:ATNativeAdClient::onAdCloseButtonClicked...unity3d.");
            if (mlistener != null) mlistener.onAdCloseButtonClicked(placementId, new ATCallbackInfo(callbackJson));
        }

        public void onAdVideoStart(string placementId) {
            Debug.Log("Unity:ATNativeAdClient::onAdVideoStart...unity3d.");
            if (mlistener != null) mlistener.onAdVideoStart(placementId);
        }

        public void onAdVideoEnd(string placementId) {
            Debug.Log("Unity:ATNativeAdClient::onAdVideoEnd...unity3d.");
            if (mlistener != null) mlistener.onAdVideoEnd(placementId);
        }

        public void onAdVideoProgress(string placementId,int progress) {
            Debug.Log("Unity:ATNativeAdClient::onAdVideoProgress...progress[" + progress + "]");
            if (mlistener != null) mlistener.onAdVideoProgress(placementId, progress);
        }

        public void onNativeAdLoaded(string placementId) {
            Debug.Log("Unity:ATNativeAdClient::onNativeAdLoaded...unity3d.");
            if (mlistener != null) mlistener.onAdLoaded(placementId);
        }

        public void onNativeAdLoadFail(string placementId,string code, string msg) {
            Debug.Log("Unity:ATNativeAdClient::onNativeAdLoadFail...unity3d. code:" + code + " msg:" + msg);
            if (mlistener != null) mlistener.onAdLoadFail(placementId, code, msg);
        }
	}
}
