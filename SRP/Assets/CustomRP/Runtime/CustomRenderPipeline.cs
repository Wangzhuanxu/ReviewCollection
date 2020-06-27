using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomRenderPipeline : RenderPipeline
{
    private CameraRender _render = new CameraRender();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context">可以做很多事，比如设置全局的vp矩阵，shader中用于矩阵变换；执行CommandBuffer；设置渲染目标等</param>
    /// <param name="cameras"></param>
    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            _render.Render(context,cameras[i]);
        }
        
    }
}
