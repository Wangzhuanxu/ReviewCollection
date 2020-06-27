using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;

public partial class CameraRender
{
    
#if UNITY_EDITOR
    //不支持的pass 的lightmode tag
    static ShaderTagId[] legacyShaderTagIds = {
        new ShaderTagId("Always"),
        new ShaderTagId("ForwardBase"),
        new ShaderTagId("PrepassBase"),
        new ShaderTagId("Vertex"),
        new ShaderTagId("VertexLMRGBM"),
        new ShaderTagId("VertexLM")
    };
       //错误的material，物体使用不支持的shader时，被替换为使用改material
    static Material errorMaterial; 
    private void DrawUnsupportedShaders()
    {
        SortingSettings settings = new SortingSettings(_camera);
        DrawingSettings draw = new DrawingSettings(legacyShaderTagIds[0],settings);
        for (int i = 1; i < legacyShaderTagIds.Length; i++)
        {
            draw.SetShaderPassName(i,legacyShaderTagIds[i]);
        }
        //本次绘制的所有物体都使用该material
        if (errorMaterial == null)
        {
            errorMaterial = new Material(Shader.Find("Hidden/InternalErrorShader"));
        }
        draw.overrideMaterial = errorMaterial;
        FilteringSettings fiter = FilteringSettings.defaultValue;
        _context.DrawRenderers(_results,ref draw,ref fiter);
    }

    private void DrawGizmos()
    {
        if (Handles.ShouldRenderGizmos())
        {
            _context.DrawGizmos(_camera, GizmoSubset.PreImageEffects);
            _context.DrawGizmos(_camera, GizmoSubset.PostImageEffects);
        }
    }

    private void PrepareForSceneWindow()
    {
        if (_camera.cameraType == CameraType.SceneView)
        {
            ScriptableRenderContext.EmitWorldGeometryForSceneView(_camera);
        }
    }

    private string SampleName { get; set; }

    private void PrepareBufferName()
    {
        Profiler.BeginSample("Editor Only");
        _buffer.name = SampleName = _camera.name;
        Profiler.EndSample();
    }
    
#else
    const string SampleName = "Command Buffer";
#endif
}
