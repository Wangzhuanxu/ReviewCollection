using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

public class ShadowRender
{
    private const string BufferName = "Shadow Render";
    private const int MaxShadowedDirectionalLightCount  = 4;//最大拥有阴影灯光的数量
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

        _commandBuffer.BeginSample(BufferName);
        int splitCount = _shadowedDirectionalLightCount > 1 ? 2 : 1; //每行有几块
        int oneTileSize = size / splitCount;
        for (int i = 0; i < _shadowedDirectionalLightCount; i++)
        {
            RenderDirectionalShadows(i,splitCount,oneTileSize);
        }
        _commandBuffer.EndSample(BufferName);
        ExecuteCommandBuffer();
    }

    public void RenderDirectionalShadows(int index, int splitCount,int size)
    {
        ShadowedDirectionalLight light = ShadowedDirectionalLights[index];
        var shadowSetting = new ShadowDrawingSettings(_results,light.visibleLightIndex);
        //https://docs.unity3d.com/2019.1/Documentation/ScriptReference/Rendering.CullingResults.ComputeDirectionalShadowMatricesAndCullingPrimitives.html
        //利用光源的方向（-transform.forward）方向可以求出view matrix，nearclip 和 最远的阴影距离等可以求出project matrix等等
        _results.ComputeDirectionalShadowMatricesAndCullingPrimitives(light.visibleLightIndex, 0, 1, Vector3.zero,
            size, 0, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix,
            out ShadowSplitData shadowSplitData);
        shadowSetting.splitData = shadowSplitData;
        SetTileViewport(index,splitCount,size);
        _commandBuffer.SetViewProjectionMatrices(viewMatrix,projMatrix);
        ExecuteCommandBuffer();
        _context.DrawShadows(ref shadowSetting);
    }

    public void SetTileViewport(int index, int splitCount,int oneTileSize)
    {
        Vector2 offset = new Vector2(index % splitCount,index / splitCount); //行列
        _commandBuffer.SetViewport(new Rect(offset.x * oneTileSize, offset.y * oneTileSize, oneTileSize, oneTileSize));
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
