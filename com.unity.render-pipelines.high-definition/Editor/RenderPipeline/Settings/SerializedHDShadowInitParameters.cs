using UnityEditor.Rendering;
using UnityEngine.Experimental.Rendering.HDPipeline;

namespace UnityEditor.Experimental.Rendering.HDPipeline
{
    class SerializedHDShadowInitParameters
    {
        public SerializedProperty root;

        public SerializedProperty shadowAtlasResolution;
        public SerializedProperty shadowMapDepthBits;
        public SerializedProperty useDynamicViewportRescale;

        public SerializedProperty maxShadowRequests;

        public SerializedProperty shadowQuality;

        public SerializedHDShadowInitParameters(SerializedProperty root)
        {
            this.root = root;

            shadowAtlasResolution = root.Find((GlobalLightLoopSettings s) => s.shadowAtlasResolution);
            shadowMapDepthBits = root.Find((GlobalLightLoopSettings s) => s.shadowMapsDepthBits);
            useDynamicViewportRescale = root.Find((GlobalLightLoopSettings s) => s.dynamicViewportRescale);
            maxShadowRequests = root.Find((GlobalLightLoopSettings s) => s.maxShadowRequests);
            shadowQuality = root.Find((GlobalLightLoopSettings s) => s.shadowQuality);
        }
    }
}
