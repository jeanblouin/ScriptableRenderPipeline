using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Serialization;

namespace UnityEngine.Experimental.Rendering.HDPipeline
{
    public partial struct RenderPipelineSettings : IVersionable<RenderPipelineSettings.Version>, ISerializationCallbackReceiver
    {
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
#pragma warning restore 649 //never assigned

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

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }
        void ISerializationCallbackReceiver.OnAfterDeserialize() => MigrateIfNeeded(this);
    }
}
