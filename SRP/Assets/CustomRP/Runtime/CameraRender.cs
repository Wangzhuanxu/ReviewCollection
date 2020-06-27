using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public partial class CameraRender
{
    private ScriptableRenderContext _context;
    private Camera _camera;
    
    CommandBuffer _buffer = new CommandBuffer();

    private CullingResults _results;
    
    private CameraClearFlags clearFlag;
    public void Render(ScriptableRenderContext context, Camera camera)
    {
        this._camera = camera;
        this._context = context;
        clearFlag = _camera.clearFlags; 
#if UNITY_EDITOR
        PrepareBufferName();
        PrepareForSceneWindow();
#endif
        if (!Cull() && clearFlag < CameraClearFlags.Depth)
        {
            return;
        }
        SetUp();
        DrawGeometry();

#if UNITY_EDITOR
        DrawUnsupportedShaders();
        DrawGizmos();
#endif
        Submit();
    }

    public bool Cull()
    {
        if (_camera.TryGetCullingParameters(out ScriptableCullingParameters _parameters))
        {
            _results = _context.Cull(ref _parameters);
            return true;
        }

        return false;
    }
    
    //支持的pass 的lightmode tag
    static ShaderTagId _shaderTagId = new ShaderTagId("SRPDefaultUnlit");
    private void SetUp()
    {
        //设置全局的vp矩阵，shader中用于矩阵变换
        _context.SetupCameraProperties(_camera);
        _buffer.ClearRenderTarget(clearFlag <= CameraClearFlags.Depth,clearFlag <  CameraClearFlags.Depth,
            clearFlag < CameraClearFlags.Depth ? _camera.backgroundColor.linear : _camera.backgroundColor.gamma);
      //  _buffer.name = SampleName;
      //  DrawGeometry();
       // _buffer.DrawMesh(GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<MeshFilter>().mesh, Matrix4x4.identity, new Material(Shader.Find("Unlit/Color")));
       //这里会运行一次CommandBuffer，对应的是上面那个 ClearRenderTarget
       ExectureBuffer();
        _buffer.BeginSample(SampleName);
 
    }

    private void DrawGeometry()
    {
        //opaque
        SortingSettings sort = new SortingSettings(_camera);
        sort.criteria = SortingCriteria.CommonOpaque;
        DrawingSettings settings = new DrawingSettings(_shaderTagId,sort);
        
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
