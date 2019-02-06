using UnityEngine;

namespace UnityEditor.Experimental.Rendering.HDPipeline
{
    static partial class HDRenderPipelineUI
    {
        static readonly GUIContent k_GeneralSectionTitle = EditorGUIUtility.TrTextContent("General");
        static readonly GUIContent k_RenderingSectionTitle = EditorGUIUtility.TrTextContent("Rendering");
        static readonly GUIContent k_LightingSectionTitle = EditorGUIUtility.TrTextContent("Lighting");
        static readonly GUIContent k_MaterialSectionTitle = EditorGUIUtility.TrTextContent("Material");
        static readonly GUIContent k_PostProcessSectionTitle = EditorGUIUtility.TrTextContent("Post-processing");
        static readonly GUIContent k_LightLoopSubTitle = EditorGUIUtility.TrTextContent("Light Loop");

        static readonly GUIContent k_CookiesSubTitle = EditorGUIUtility.TrTextContent("Cookies");
        static readonly GUIContent k_ReflectionsSubTitle = EditorGUIUtility.TrTextContent("Reflections");
        static readonly GUIContent k_SkySubTitle = EditorGUIUtility.TrTextContent("Sky");
        static readonly GUIContent k_DecalsSubTitle = EditorGUIUtility.TrTextContent("Decals");
        static readonly GUIContent k_ShadowSubTitle = EditorGUIUtility.TrTextContent("Shadow");
        static readonly GUIContent k_ShadowAtlasSubTitle = EditorGUIUtility.TrTextContent("Atlas");
        static readonly GUIContent k_ShadowFilteringQualitySubTitle = EditorGUIUtility.TrTextContent("Filtering Qualities");
        static readonly GUIContent k_DynamicResolutionSubTitle = EditorGUIUtility.TrTextContent("Dynamic resolution");

        static readonly GUIContent k_DefaultFrameSettingsContent = EditorGUIUtility.TrTextContent("Default Frame Settings For");

        static readonly GUIContent k_RenderPipelineResourcesContent = EditorGUIUtility.TrTextContent("Render Pipeline Resources", "Set of resources that need to be loaded when creating stand alone");
        static readonly GUIContent k_RenderPipelineEditorResourcesContent = EditorGUIUtility.TrTextContent("Render Pipeline Editor Resources", "Set of resources that need to be loaded for working in editor");
        static readonly GUIContent k_DiffusionProfileSettingsContent = EditorGUIUtility.TrTextContent("Diffusion Profile List");
        static readonly GUIContent k_SRPBatcher = EditorGUIUtility.TrTextContent("SRP Batcher", "If enabled, the render pipeline uses the SRP batcher.");
        static readonly GUIContent k_ShaderVariantLogLevel = EditorGUIUtility.TrTextContent("Shader Variant Log Level", "Controls the level logging in of shader variants information is outputted when a build is performed. Information will appear in the Unity console when the build finishes.");

        static readonly GUIContent k_SupportShadowMaskContent = EditorGUIUtility.TrTextContent("Shadow Mask", "Enable memory (Extra Gbuffer in deferred) and shader variant for shadow mask.");
        static readonly GUIContent k_SupportSSRContent = EditorGUIUtility.TrTextContent("Screen Space Reflection", "Enable memory use by SSR effect.");
        static readonly GUIContent k_SupportSSAOContent = EditorGUIUtility.TrTextContent("SSAO", "Enable memory use by SSAO effect.");
        static readonly GUIContent k_SupportedSSSContent = EditorGUIUtility.TrTextContent("Subsurface Scattering");
        static readonly GUIContent k_SSSSampleCountContent = EditorGUIUtility.TrTextContent("High quality", "This allows for better SSS quality. Warning: high performance cost, do not enable on consoles.");
        static readonly GUIContent k_SupportVolumetricContent = EditorGUIUtility.TrTextContent("Volumetrics", "Enable memory and shader variant for volumetric.");
        static readonly GUIContent k_VolumetricResolutionContent = EditorGUIUtility.TrTextContent("High quality", "Increase the resolution of volumetric lighting buffers. Warning: high performance cost, do not enable on consoles.");
        static readonly GUIContent k_SupportLightLayerContent = EditorGUIUtility.TrTextContent("LightLayers", "Enable light layers. In deferred this imply an extra render target in memory and extra cost.");
        static readonly GUIContent k_SupportLitShaderModeContent = EditorGUIUtility.TrTextContent("Supported Lit Shader Mode", "Remove all the memory and shader variant of GBuffer of non used mode. The renderer cannot be switch to non selected path anymore.");
        static readonly GUIContent k_MSAASampleCountContent = EditorGUIUtility.TrTextContent("MSAA Quality", "Allow to select the level of MSAA.");
        static readonly GUIContent k_SupportDecalContent = EditorGUIUtility.TrTextContent("Enable", "Enable memory and variant for decals buffer and cluster decals.");
        static readonly GUIContent k_SupportMotionVectorContent = EditorGUIUtility.TrTextContent("Motion Vectors", "Motion vector are use for Motion Blur, TAA, temporal re-projection of various effect like SSR.");
        static readonly GUIContent k_SupportRuntimeDebugDisplayContent = EditorGUIUtility.TrTextContent("Runtime debug display", "Remove all debug display shader variant only in the player. Allow faster build.");
        static readonly GUIContent k_SupportDitheringCrossFadeContent = EditorGUIUtility.TrTextContent("Dithering cross fade", "Remove all dithering cross fade shader variant only in the player. Allow faster build.");
        static readonly GUIContent k_SupportDistortion = EditorGUIUtility.TrTextContent("Distortion", "Remove all distortion shader variants only in the player. Allow faster build.");
        static readonly GUIContent k_SupportTransparentBackface = EditorGUIUtility.TrTextContent("Transparent Backface", "Remove all Transparent backface shader variants only in the player. Allow faster build.");
        static readonly GUIContent k_SupportTransparentDepthPrepass = EditorGUIUtility.TrTextContent("Transparent Depth Prepass", "Remove all Transparent Depth Prepass shader variants only in the player. Allow faster build.");
        static readonly GUIContent k_SupportTransparentDepthPostpass = EditorGUIUtility.TrTextContent("Transparent Depth Postpass", "Remove all Transparent Depth Postpass shader variants only in the player. Allow faster build.");
        static readonly GUIContent k_SupportRaytracing = EditorGUIUtility.TrTextContent("Support Realtime Raytracing");
        static readonly GUIContent k_EditorRaytracingFilterLayerMask = EditorGUIUtility.TrTextContent("Raytracing Filter Layer Mask for SceneView and Preview");

        const string k_CacheErrorFormat = "This configuration will lead to more than 2 GB reserved for this cache at runtime! ({0} requested) Only {1} element will be reserved instead.";
        const string k_CacheInfoFormat = "Reserving {0} in memory at runtime.";

        static readonly GUIContent k_CoockieSizeContent = EditorGUIUtility.TrTextContent("Cookie Size");
        static readonly GUIContent k_CookieTextureArraySizeContent = EditorGUIUtility.TrTextContent("Texture Array Size");
        static readonly GUIContent k_PointCoockieSizeContent = EditorGUIUtility.TrTextContent("Point Cookie Size");
        static readonly GUIContent k_PointCookieTextureArraySizeContent = EditorGUIUtility.TrTextContent("Cubemap Array Size");


        static readonly GUIContent k_CompressProbeCacheContent = EditorGUIUtility.TrTextContent("Compress Reflection Probe Cache");
        static readonly GUIContent k_CubemapSizeContent = EditorGUIUtility.TrTextContent("Reflection Cubemap Size");
        static readonly GUIContent k_ProbeCacheSizeContent = EditorGUIUtility.TrTextContent("Probe Cache Size");

        static readonly GUIContent k_CompressPlanarProbeCacheContent = EditorGUIUtility.TrTextContent("Compress Planar Reflection Probe Cache");
        static readonly GUIContent k_PlanarTextureSizeContent = EditorGUIUtility.TrTextContent("Planar Reflection Texture Size");
        static readonly GUIContent k_PlanarProbeCacheSizeContent = EditorGUIUtility.TrTextContent("Planar Probe Cache Size");

        static readonly GUIContent k_SupportFabricBSDFConvolutionContent = EditorGUIUtility.TrTextContent("Fabric BSDF Convolution");

        static readonly GUIContent k_SkyReflectionSizeContent = EditorGUIUtility.TrTextContent("Reflection Size");
        static readonly GUIContent k_SkyLightingOverrideMaskContent = EditorGUIUtility.TrTextContent("Lighting Override Mask", "This layer mask will define in which layers the sky system will look for sky settings volumes for lighting override");
        const string k_SkyLightingHelpBoxContent = "Be careful, Sky Lighting Override Mask is set to Everything. This is most likely a mistake as it serves no purpose.";

        static readonly GUIContent k_MaxDirectionalContent = EditorGUIUtility.TrTextContent("Max Directional Lights On Screen");
        static readonly GUIContent k_MaxPonctualContent = EditorGUIUtility.TrTextContent("Max Punctual Lights On Screen");
        static readonly GUIContent k_MaxAreaContent = EditorGUIUtility.TrTextContent("Max Area Lights On Screen");
        static readonly GUIContent k_MaxEnvContent = EditorGUIUtility.TrTextContent("Max Env Lights On Screen");
        static readonly GUIContent k_MaxDecalContent = EditorGUIUtility.TrTextContent("Max Decals On Screen");

        static readonly GUIContent k_ResolutionContent = EditorGUIUtility.TrTextContent("Resolution");
        static readonly GUIContent k_Map16bContent = EditorGUIUtility.TrTextContent("16-bit");
        static readonly GUIContent k_DynamicRescaleContent = EditorGUIUtility.TrTextContent("Dynamic Rescale", "Scale the shadow map size using the screen size of the light to leave more space for other shadows in the atlas");
        static readonly GUIContent k_MaxRequestContent = EditorGUIUtility.TrTextContent("Max Shadow on Screen", "Max shadow on screen (S) per frame, 1 point light = 6 S, 1 spot light = 1 S and the directional is 4 S");

        static readonly GUIContent k_DrawDistanceContent = EditorGUIUtility.TrTextContent("Draw Distance");
        static readonly GUIContent k_AtlasWidthContent = EditorGUIUtility.TrTextContent("Atlas Width");
        static readonly GUIContent k_AtlasHeightContent = EditorGUIUtility.TrTextContent("Atlas Height");
        static readonly GUIContent k_MetalAndAOContent = EditorGUIUtility.TrTextContent("Metal and AO properties");

        static readonly GUIContent k_Enabled = EditorGUIUtility.TrTextContent("Enabled");
        static readonly GUIContent k_MaxPercentage = EditorGUIUtility.TrTextContent("Max Screen Percentage");
        static readonly GUIContent k_MinPercentage = EditorGUIUtility.TrTextContent("Min Screen Percentage");
        static readonly GUIContent k_DynResType = EditorGUIUtility.TrTextContent("Dynamic Resolution Type");
        static readonly GUIContent k_UpsampleFilter = EditorGUIUtility.TrTextContent("Upscale filter");
        static readonly GUIContent k_ForceScreenPercentage = EditorGUIUtility.TrTextContent("Force Screen Percentage");
        static readonly GUIContent k_ForcedScreenPercentage = EditorGUIUtility.TrTextContent("Forced Screen Percentage");

        static readonly GUIContent k_LutSize = EditorGUIUtility.TrTextContent("Grading LUT Size");
        static readonly GUIContent k_LutFormat = EditorGUIUtility.TrTextContent("Grading LUT Format");
    }
}
