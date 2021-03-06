﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public partial class CameraRender
{
    LightRender _lightRender = new LightRender();
    
    private ScriptableRenderContext _context;
    private Camera _camera;
    
    CommandBuffer _buffer = new CommandBuffer();

    private CullingResults _results;
    
    private CameraClearFlags clearFlag;

    private bool gpuInstancing;
    private bool dynamicBatch;
    public void Render(ScriptableRenderContext context, Camera camera,bool gpuInstancing,bool dynamicBatch,ShadowSettings shadowSettings)
    {
        this._camera = camera;
        this._context = context;
        this.gpuInstancing = gpuInstancing;
        this.dynamicBatch = dynamicBatch;
        clearFlag = _camera.clearFlags; 
#if UNITY_EDITOR
        PrepareBufferName();
        PrepareForSceneWindow();
#endif
        if (!Cull(shadowSettings) && clearFlag < CameraClearFlags.Depth) //depth为ui相机，只显示ui
        {
            return;
        }
        _buffer.BeginSample(SampleName);
        ExectureBuffer();
        _lightRender.Render(context,_results,shadowSettings);
        _buffer.EndSample(SampleName);
        SetUp();
        
        DrawGeometry();

#if UNITY_EDITOR
        DrawUnsupportedShaders();
        DrawGizmos();
#endif
        _lightRender.CleanUp();
        Submit();
    }

    public bool Cull(ShadowSettings shadowSettings)
    {
        if (_camera.TryGetCullingParameters(out ScriptableCullingParameters _parameters))
        {
            _parameters.shadowDistance = shadowSettings.maxDistance;
            _results = _context.Cull(ref _parameters);
            return true;
        }

        return false;
    }
    
    //支持的pass 的lightmode tag
    static ShaderTagId _unlitshaderTagId = new ShaderTagId("SRPDefaultUnlit");
    static ShaderTagId _litshaderTagId = new ShaderTagId("CustomLit");
    private void SetUp()
    {
        //设置全局的vp矩阵，shader中用于矩阵变换
        _context.SetupCameraProperties(_camera);
        _buffer.ClearRenderTarget(clearFlag <= CameraClearFlags.Depth,clearFlag ==  CameraClearFlags.SolidColor,
            clearFlag < CameraClearFlags.Depth ? _camera.backgroundColor.linear : _camera.backgroundColor.gamma);
      //  _buffer.name = SampleName;
      //  DrawGeometry();
       // _buffer.DrawMesh(GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<MeshFilter>().mesh, Matrix4x4.identity, new Material(Shader.Find("Unlit/Color")));
       //这里会运行一次CommandBuffer，对应的是上面那个 ClearRenderTarget
       ExectureBuffer();
        _buffer.BeginSample(SampleName);
        ExectureBuffer();
    }
 
    private void DrawGeometry()
    {
        //opaque
        SortingSettings sort = new SortingSettings(_camera);
        sort.criteria = SortingCriteria.CommonOpaque;
        DrawingSettings settings = new DrawingSettings(_unlitshaderTagId,sort);
        settings.SetShaderPassName(1,_litshaderTagId);
        settings.enableInstancing = gpuInstancing;
        settings.enableDynamicBatching = dynamicBatch;

        FilteringSettings filter =  new FilteringSettings(RenderQueueRange.opaque);
        //filter.renderQueueRange = RenderQueueRange.opaque;
        filter.layerMask = _camera.cullingMask;
        _context.DrawRenderers(_results,ref settings,ref filter);
        
        //skybox
        _context.DrawSkybox(_camera);

        sort.criteria = SortingCriteria.CommonTransparent;
        settings.sortingSettings = sort;
        filter.renderQueueRange = RenderQueueRange.transparent;
        _context.DrawRenderers(_results,ref settings,ref filter);
    }
    
    private void Submit()
    {
        _buffer.EndSample(SampleName);
        //这里会运行一次CommandBuffer，对应的是上面那个 BeginSample
        ExectureBuffer();
        _context.Submit();
    }

    private void ExectureBuffer()
    {
        _context.ExecuteCommandBuffer(_buffer);
        _buffer.Clear();
    }
}
