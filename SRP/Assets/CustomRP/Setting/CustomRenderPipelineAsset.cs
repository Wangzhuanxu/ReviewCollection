using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Custom/RenderRP")]
public class CustomRenderPipelineAsset : RenderPipelineAsset
{
    public bool GpuInstancing;
    public bool DynamicBatch;
    public bool SrpBatch;
    protected override RenderPipeline CreatePipeline()
    {
        return new CustomRenderPipeline(GpuInstancing,DynamicBatch,SrpBatch);
    }
}
