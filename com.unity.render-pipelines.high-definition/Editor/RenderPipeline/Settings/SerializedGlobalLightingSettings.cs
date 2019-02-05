using UnityEditor.Rendering;
using UnityEngine.Experimental.Rendering.HDPipeline;

namespace UnityEditor.Experimental.Rendering.HDPipeline
{
    class SerializedGlobalLightingSettings
    {
        public SerializedProperty root;

        public SerializedProperty cookieSize;
        public SerializedProperty cookieTexArraySize;
        public SerializedProperty pointCookieSize;
        public SerializedProperty cubeCookieTexArraySize;
        public SerializedProperty reflectionProbeCacheSize;
        public SerializedProperty reflectionCubemapSize;
        public SerializedProperty reflectionCacheCompressed;
        public SerializedProperty planarReflectionProbeCacheSize;
        public SerializedProperty planarReflectionCubemapSize;
        public SerializedProperty planarReflectionCacheCompressed;
        public SerializedProperty skyReflectionSize;
        public SerializedProperty skyLightingOverrideLayerMask;
        public SerializedProperty supportFabricConvolution;
        public SerializedProperty maxDirectionalLightsOnScreen;
        public SerializedProperty maxPunctualLightsOnScreen;
        public SerializedProperty maxAreaLightsOnScreen; 
        public SerializedProperty maxEnvLightsOnScreen;
        public SerializedProperty maxDecalsOnScreen;
        
        public SerializedProperty shadowAtlasResolution;
        public SerializedProperty shadowMapDepthBits;
        public SerializedProperty useDynamicViewportRescale;
        public SerializedProperty maxShadowRequests;
        public SerializedProperty shadowQuality;

        public SerializedGlobalLightingSettings(SerializedProperty root)
        {
            this.root = root;

            cookieSize = root.Find((GlobalLightingSettings s) => s.cookieSize);
            cookieTexArraySize = root.Find((GlobalLightingSettings s) => s.cookieTexArraySize);
            pointCookieSize = root.Find((GlobalLightingSettings s) => s.pointCookieSize);
            cubeCookieTexArraySize = root.Find((GlobalLightingSettings s) => s.cubeCookieTexArraySize);

            reflectionProbeCacheSize = root.Find((GlobalLightingSettings s) => s.reflectionProbeCacheSize);
            reflectionCubemapSize = root.Find((GlobalLightingSettings s) => s.reflectionCubemapSize);
            reflectionCacheCompressed = root.Find((GlobalLightingSettings s) => s.reflectionCacheCompressed);

            planarReflectionProbeCacheSize = root.Find((GlobalLightingSettings s) => s.planarReflectionProbeCacheSize);
            planarReflectionCubemapSize = root.Find((GlobalLightingSettings s) => s.planarReflectionTextureSize);
            planarReflectionCacheCompressed = root.Find((GlobalLightingSettings s) => s.planarReflectionCacheCompressed);

            skyReflectionSize = root.Find((GlobalLightingSettings s) => s.skyReflectionSize);
            skyLightingOverrideLayerMask = root.Find((GlobalLightingSettings s) => s.skyLightingOverrideLayerMask);
            supportFabricConvolution = root.Find((GlobalLightingSettings s) => s.supportFabricConvolution);

            maxDirectionalLightsOnScreen = root.Find((GlobalLightingSettings s) => s.maxDirectionalLightsOnScreen);
            maxPunctualLightsOnScreen = root.Find((GlobalLightingSettings s) => s.maxPunctualLightsOnScreen);
            maxAreaLightsOnScreen = root.Find((GlobalLightingSettings s) => s.maxAreaLightsOnScreen);
            maxEnvLightsOnScreen = root.Find((GlobalLightingSettings s) => s.maxEnvLightsOnScreen);
            maxDecalsOnScreen = root.Find((GlobalLightingSettings s) => s.maxDecalsOnScreen);

            shadowAtlasResolution = root.Find((GlobalLightingSettings s) => s.shadowAtlasResolution);
            shadowMapDepthBits = root.Find((GlobalLightingSettings s) => s.shadowMapsDepthBits);
            useDynamicViewportRescale = root.Find((GlobalLightingSettings s) => s.dynamicViewportRescale);
            maxShadowRequests = root.Find((GlobalLightingSettings s) => s.maxShadowRequests);
            shadowQuality = root.Find((GlobalLightingSettings s) => s.shadowQuality);
        }
    }
}
