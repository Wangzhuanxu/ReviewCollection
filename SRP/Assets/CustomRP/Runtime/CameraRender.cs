using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraRender
{
    private ScriptableRenderContext _context;
    private Camera _camera;
    
    CommandBuffer _buffer = new CommandBuffer();

    private CullingResults _results;
    public void Render(ScriptableRenderContext context, Camera camera)
    {
        this._camera = camera;
        this._context = context;
        if (!Cull())
        {
            return;
        }
        SetUp();
        DrawGeometry();
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
    
    private CameraClearFlags clearFlag;
    ShaderTagId _shaderTagId = new ShaderTagId("SRPDefaultUnlit");
    private void SetUp()
    {
        _context.SetupCameraProperties(_camera);
        clearFlag = _camera.clearFlags;
        _buffer.ClearRenderTarget(clearFlag <= CameraClearFlags.Depth,clearFlag <  CameraClearFlags.Depth,Color.blue);
        _buffer.name = _camera.name;
      //  DrawGeometry();
       // _buffer.DrawMesh(GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<MeshFilter>().mesh, Matrix4x4.identity, new Material(Shader.Find("Unlit/Color")));
        ExectureBuffer();
        _buffer.BeginSample(_camera.name);
 
    }

    private void DrawGeometry()
    {
        SortingSettings sort = new SortingSettings(_camera);
        sort.criteria = SortingCriteria.CommonOpaque;
        DrawingSettings settings = new DrawingSettings(_shaderTagId,sort);
        FilteringSettings filter =  new FilteringSettings(RenderQueueRange.opaque);
        //filter.renderQueueRange = RenderQueueRange.opaque;
        filter.layerMask = (1 << 2) | (1 << 1)| (1 << 3);
        _context.DrawRenderers(_results,ref settings,ref filter);
        _context.DrawSkybox(_camera);
    }

    private void Submit()
    {
        _buffer.EndSample(_camera.name);
        ExectureBuffer();
        _context.Submit();
    }

    private void ExectureBuffer()
    {
        _context.ExecuteCommandBuffer(_buffer);
        _buffer.Clear();
    }
}
