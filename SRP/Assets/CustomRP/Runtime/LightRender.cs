using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightRender
{
    private const string BufferName = "Lighting Render";
    private const int MAX_DIRECTION_LIGHT_COUNT = 4; //与Light.hlsl中的MAX_DIRECTION_LIGHT_COUNT宏对应 
    CommandBuffer _commandBuffer = new CommandBuffer()
    {
        name = BufferName
    };

    private ScriptableRenderContext _context;
    private CullingResults _results;
    private ShadowSettings _shadowSettings;
    
    Vector4[] lightColors = new Vector4[MAX_DIRECTION_LIGHT_COUNT];
    Vector4[] lightDirs = new Vector4[MAX_DIRECTION_LIGHT_COUNT];

    private ShadowRender _shadow = new ShadowRender();
    public void Render(ScriptableRenderContext context,CullingResults results,ShadowSettings shadowSettings)
    {
        _results = results;
        _context = context;
        _shadowSettings = shadowSettings;
        _commandBuffer.BeginSample(BufferName);
        _shadow.SetUp(context,results,shadowSettings);
        SetUpLights();
       // _shadow.Render();
        _commandBuffer.EndSample(BufferName);
        ExecuteCommandBuffer();
    }

    public void CleanUp()
    {
        _shadow.CleanUp();
    }

    private void ExecuteCommandBuffer()
    {
        _context.ExecuteCommandBuffer(_commandBuffer);
        _commandBuffer.Clear();
    }

    private static int DirectionLightDirectionPropertyId = Shader.PropertyToID("DirectionLightDirection");
    private static int DirectionLightColorPropertyId = Shader.PropertyToID(("DirectionLightColor"));
    private static int DirectionLightCount = Shader.PropertyToID("DirectionLightCount");
    public void SetUpLights()
    {
        for (int i = 0; i < _results.visibleLights.Length; i++)
        {
            VisibleLight light = _results.visibleLights[i];
            if (light.lightType == LightType.Directional && i < MAX_DIRECTION_LIGHT_COUNT)
            {
                SetUpLightData(i,ref light);
            }
        }
        _commandBuffer.SetGlobalInt(DirectionLightCount,_results.visibleLights.Length);
        _commandBuffer.SetGlobalVectorArray(DirectionLightDirectionPropertyId,lightDirs);
        _commandBuffer.SetGlobalVectorArray(DirectionLightColorPropertyId,lightColors);
        
    }
    public void SetUpLightData(int index,ref VisibleLight light)
    {
        lightColors[index] = light.finalColor;
        //该矩阵的1，2，3列分别表示该物体的x，y，z轴在世界空间中的表示，而tranfrom.forward表示的是物体在世界空空间中的朝向，也就是z轴。
        lightDirs[index] = - light.localToWorldMatrix.GetColumn(2);
        _shadow.ReserveDirectionalShadows(light.light,index);
        // _commandBuffer.SetGlobalVector(DirectionLightColorPropertyId,light.color * light.intensity);
        // //光线的方向由物体指向光源方向，也就是俗称光来的方向
        // _commandBuffer.SetGlobalVector(DirectionLightDirectionPropertyId,-light.transform.forward);
    }
}
