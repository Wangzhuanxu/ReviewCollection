using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Custom/RenderRP")]
public class CustomRenderPipelineAsset : RenderPipelineAsset
{
    public bool gpuInstancing;
    public bool dynamicBatch;
    public bool srpBatch;

    public ShadowSettings shadowSettings;
    protected override RenderPipeline CreatePipeline()
    {
        return new CustomRenderPipeline(gpuInstancing,dynamicBatch,srpBatch,shadowSettings);
    }
}
