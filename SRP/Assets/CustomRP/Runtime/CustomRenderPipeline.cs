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
        //使用线性空间的颜色值，线性空间颜色值看起来更好看，更符合人眼
        GraphicsSettings.lightsUseLinearIntensity = true;
    }
}
