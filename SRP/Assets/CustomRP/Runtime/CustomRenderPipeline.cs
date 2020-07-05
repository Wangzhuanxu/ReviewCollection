using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomRenderPipeline : RenderPipeline
{
    private readonly CameraRender _render = new CameraRender();

    private readonly bool _gpuInstancing;
    private readonly bool _dynamicBatch;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context">可以做很多事，比如设置全局的vp矩阵，shader中用于矩阵变换；执行CommandBuffer；设置渲染目标等</param>
    /// <param name="cameras"></param>
    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            _render.Render(context,cameras[i],_gpuInstancing,_dynamicBatch);
        }
        
    }

    public CustomRenderPipeline(bool gpuInstancing, bool dynamicBatch,bool srpBatch)
    {
        this._gpuInstancing = gpuInstancing;
        this._dynamicBatch = dynamicBatch;
        GraphicsSettings.useScriptableRenderPipelineBatching = srpBatch;
    }
}
