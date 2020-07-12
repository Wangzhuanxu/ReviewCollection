using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

public class ShadowRender
{
    private const string BufferName = "Shadow Render";
    private const int MaxShadowedDirectionalLightCount = 1;//最大拥有阴影灯光的数量
    CommandBuffer _commandBuffer = new CommandBuffer()
    {
        name = BufferName
    };

    private ScriptableRenderContext _context;
    private CullingResults _results;
    private ShadowSettings _shadowSettings;
    private int _shadowedDirectionalLightCount; //当前拥有阴影灯光的数量

    public struct ShadowedDirectionalLight
    {
        public int visibleLightIndex;
    }
    
    public ShadowedDirectionalLight[] ShadowedDirectionalLights = 
        new ShadowedDirectionalLight[MaxShadowedDirectionalLightCount];
    
    
    public void SetUp(ScriptableRenderContext context,CullingResults results,ShadowSettings shadowSettings)
    {
        _results = results;
        _context = context;
        _shadowSettings = shadowSettings;
        _shadowedDirectionalLightCount = 0;
    }

    static int dirShadowAtlasId = Shader.PropertyToID("_DirectionalShadowAtlas");
    public void Render()
    {
        if (_shadowedDirectionalLightCount > 0)
        {
            RenderDirectionalShadows();
        }
    }

    public void RenderDirectionalShadows()
    {
        int size =(int)_shadowSettings.directional._size;
        _commandBuffer.GetTemporaryRT(
            dirShadowAtlasId, size, size,
            16, FilterMode.Bilinear, RenderTextureFormat.Shadowmap
        );
        _commandBuffer.SetRenderTarget(
            dirShadowAtlasId,
            RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store
        );
        _commandBuffer.ClearRenderTarget(true,false,Color.clear);
        ExecuteCommandBuffer();
    }

    public void CleanUp()
    {
        if (_shadowedDirectionalLightCount > 0)
        {
            _commandBuffer.ReleaseTemporaryRT(dirShadowAtlasId);
            ExecuteCommandBuffer();
        }
    }

    private void ExecuteCommandBuffer()
    {
        _context.ExecuteCommandBuffer(_commandBuffer);
        _commandBuffer.Clear();
    }

    public void ReserveDirectionalShadows(Light light, int index)
    {
        if (_shadowedDirectionalLightCount < MaxShadowedDirectionalLightCount &&
            light.shadows != LightShadows.None && light.intensity > 0 &&
            _results.GetShadowCasterBounds(index,out Bounds outBounds))
        {
            ShadowedDirectionalLights[_shadowedDirectionalLightCount] = new ShadowedDirectionalLight()
            {
                visibleLightIndex = index
            };
            ++_shadowedDirectionalLightCount;
        }
    }
    
}
