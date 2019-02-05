using System;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace UnityEngine.Experimental.Rendering.HDPipeline
{
    // RenderPipelineSettings define settings that can't be change during runtime. It is equivalent to the GraphicsSettings of Unity (Tiers + shader variant removal).
    // This allow to allocate resource or not for a given feature.
    // FrameSettings control within a frame what is enable or not(enableShadow, enableStereo, enableDistortion...).
    // HDRenderPipelineAsset reference the current RenderPipelineSettings used, there is one per supported platform(Currently this feature is not implemented and only one GlobalFrameSettings is available).
    // A Camera with HDAdditionalData has one FrameSettings that configures how it will render. For example a camera used for reflection will disable distortion and post-process.
    // Additionally, on a Camera there is another FrameSettings called ActiveFrameSettings that is created on the fly based on FrameSettings and allows modifications for debugging purpose at runtime without being serialized on disk.
    // The ActiveFrameSettings is registered in the debug windows at the creation of the camera.
    // A Camera with HDAdditionalData has a RenderPath that defines if it uses a "Default" FrameSettings, a preset of FrameSettings or a custom one.
    // HDRenderPipelineAsset contains a "Default" FrameSettings that can be referenced by any camera with RenderPath.Defaut or when the camera doesn't have HDAdditionalData like the camera of the Editor.
    // It also contains a DefaultActiveFrameSettings

    // RenderPipelineSettings represents settings that are immutable at runtime.
    // There is a dedicated RenderPipelineSettings for each platform
    [Serializable]
    public partial struct RenderPipelineSettings : IVersionable<RenderPipelineSettings.Version>, ISerializationCallbackReceiver
    {
        public enum SupportedLitShaderMode
        {
            ForwardOnly = 1 << 0,
            DeferredOnly = 1 << 1,
            Both = ForwardOnly | DeferredOnly
        }

        /// <summary>Default RenderPipelineSettings</summary>
        public static readonly RenderPipelineSettings @default = new RenderPipelineSettings()
        {
            supportShadowMask = true,
            supportSSAO = true,
            supportSubsurfaceScattering = true,
            supportVolumetrics = true,
            supportDistortion = true,
            supportTransparentBackface = true,
            supportTransparentDepthPrepass = true,
            supportTransparentDepthPostpass = true,
            supportedLitShaderMode = SupportedLitShaderMode.DeferredOnly,
            supportDecals = true,
            msaaSampleCount = MSAASamples.None,
            supportMotionVectors = true,
            supportRuntimeDebugDisplay = true,
            supportDitheringCrossFade = true,
            editorRaytracingFilterLayerMask = -1,
            lightLoopSettings = GlobalLightingSettings.@default,
            decalSettings = GlobalDecalSettings.@default,
            postProcessSettings = GlobalPostProcessSettings.@default,
            dynamicResolutionSettings = GlobalDynamicResolutionSettings.@default,
        };

        // Lighting
        public bool supportShadowMask;
        public bool supportSSR;
        public bool supportSSAO;
        public bool supportSubsurfaceScattering;
        public bool increaseSssSampleCount;
        public bool supportVolumetrics;
        public bool increaseResolutionOfVolumetrics;
        public bool supportLightLayers;
        public bool supportDistortion;
        public bool supportTransparentBackface;
        public bool supportTransparentDepthPrepass;
        public bool supportTransparentDepthPostpass;
        public SupportedLitShaderMode supportedLitShaderMode;

        // Engine
        public bool supportDecals;

        public MSAASamples msaaSampleCount;
        public bool supportMSAA
        {
            get
            {
                return msaaSampleCount != MSAASamples.None;
            }

        }

        public bool supportMotionVectors;
        public bool supportRuntimeDebugDisplay;
        public bool supportDitheringCrossFade;
        public bool supportRayTracing;
        public LayerMask editorRaytracingFilterLayerMask;

        public GlobalLightingSettings  lightLoopSettings;
        public GlobalDecalSettings      decalSettings;
        public GlobalPostProcessSettings postProcessSettings;
        public GlobalDynamicResolutionSettings dynamicResolutionSettings;
        

        #region Migration
        enum Version
        {
            Initial,
            MergedShadowSettingsInLightSettings
        }

        // Cannot use MigrationDescription with a struct. Use this as workaroud
        static void MigrateIfNeeded(RenderPipelineSettings i)
        {
            // initial => MergedShadowSettingsInLightSettings
#pragma warning disable 618
            if (i.m_ObsoleteHdShadowInitParams == null)
                return;

            i.lightLoopSettings.shadowAtlasResolution = i.m_ObsoleteHdShadowInitParams.shadowAtlasResolution;
            i.lightLoopSettings.maxShadowRequests = i.m_ObsoleteHdShadowInitParams.maxShadowRequests;
            i.lightLoopSettings.shadowMapsDepthBits = i.m_ObsoleteHdShadowInitParams.shadowMapsDepthBits;
            i.lightLoopSettings.dynamicViewportRescale = i.m_ObsoleteHdShadowInitParams.useDynamicViewportRescale;
            i.lightLoopSettings.shadowQuality = i.m_ObsoleteHdShadowInitParams.shadowQuality;

            // Free memory space
            i.m_ObsoleteHdShadowInitParams = null;
#pragma warning restore 618
        }

        [SerializeField]
        Version m_Version;
        Version IVersionable<Version>.version { get => m_Version; set => m_Version = value; }

        // Obsolete fields
#pragma warning disable 649 //never assigned
        [SerializeField, FormerlySerializedAs("hdShadowInitParams"), Obsolete("Kept for data migration")]
        ObsoleteHDShadowInitParameters m_ObsoleteHdShadowInitParams;

        [Serializable, Obsolete("Kept for data migration")]
        class ObsoleteHDShadowInitParameters
        {
            [Serialization.FormerlySerializedAs("shadowAtlasWidth")]
            public int shadowAtlasResolution;
            public int maxShadowRequests;
            public DepthBits shadowMapsDepthBits;
            public bool useDynamicViewportRescale;
            public HDShadowQuality shadowQuality;
        }
#pragma warning restore 649 //never assigned

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }
        void ISerializationCallbackReceiver.OnAfterDeserialize() => MigrateIfNeeded(this);
        #endregion
    }
}
