using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomShaderGUI : ShaderGUI
{
    private MaterialEditor _materialEditor;
    private MaterialProperty[] _properties;
    private Material material;
    private bool preset;
    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        base.OnGUI(materialEditor,properties);
        _materialEditor = materialEditor;
        _properties = properties;
        material = materialEditor.target as Material;

        //最后一个参数代表，点击PreSet标签是否会收起或打开fold，ture管用，false不管用
        preset = EditorGUILayout.Foldout(preset, "PreSet",true);
        if (preset)
        {
            OpaquePreset();
            ClipPreset();
            FadePreset();
            TransparentPreset();
        }

    }

    private bool SetProperty(string name,float value)
    {
        //第三个参数代表，没有找到这个参数，不会报错
        MaterialProperty property = FindProperty(name, _properties,false);
        if (property != null)
        {
            FindProperty(name, _properties).floatValue = value;
            return true;
        }

        return false;
    }

    private void SetKeyWord(string name, bool enable)
    {
        if (enable)
        {
            material.EnableKeyword(name);
        }
        else
        {
            material.DisableKeyword(name);
        }
    }

    private void SetBoth(string name, string keyword, bool value)
    {
        if (SetProperty(name, value ? 1 : 0))
        {
            SetKeyWord(keyword, value);
        }
    }
    
    bool Clipping {
        set => SetBoth("_Clip", "_CLIPPING", value);
    }

    bool PremultiplyAlpha {
        set => SetBoth("_PremulAlpha", "_PREMULTIPLY_ALPHA", value);
    }

    BlendMode SrcBlend {
        set => SetProperty("_SrcBlend", (float)value);
    }

    BlendMode DstBlend {
        set => SetProperty("_DstBlend", (float)value);
    }

    bool ZWrite {
        set => SetProperty("_ZWrite", value ? 1f : 0f);
    }

    RenderQueue RenderQueue
    {
        set { material.renderQueue = (int)value; }
    }
    
    bool PresetButton (string name) {
        if (GUILayout.Button(name)) {
            _materialEditor.RegisterPropertyChangeUndo(name);
            return true;
        }
        return false;
    }
    
    //不透明，不透明度测试
    void OpaquePreset () {
        if (PresetButton("Opaque")) {
            Clipping = false;
            PremultiplyAlpha = false;
            SrcBlend = BlendMode.One;
            DstBlend = BlendMode.Zero;
            ZWrite = true;
            RenderQueue = RenderQueue.Geometry;
        }
    }
    
    //透明度混合
    void FadePreset () {
        if (PresetButton("Fade")) {
            Clipping = false;
            PremultiplyAlpha = false;
            SrcBlend = BlendMode.SrcAlpha;
            DstBlend = BlendMode.OneMinusSrcAlpha;
            ZWrite = false;
            RenderQueue = RenderQueue.Transparent;
        }
    }
    
    //透明度测试，漫反射不受透明度的影响，diffuse = diffuse
    void ClipPreset () {
        if (PresetButton("Clip")) {
            Clipping = true;
            PremultiplyAlpha = false;
            SrcBlend = BlendMode.One;
            DstBlend = BlendMode.Zero;
            ZWrite = true;
            RenderQueue = RenderQueue.AlphaTest;
        }
    }
    
    //透明度混合，预乘以透明度，也就是漫反射受透明度的影响，diffuse = diffuse * alpha
    void TransparentPreset () {
        if (PresetButton("Transparent")) {
            Clipping = false;
            PremultiplyAlpha = true;
            SrcBlend = BlendMode.One;
            DstBlend = BlendMode.OneMinusSrcAlpha;
            ZWrite = false;
            RenderQueue = RenderQueue.Transparent;
        }
    }
}
